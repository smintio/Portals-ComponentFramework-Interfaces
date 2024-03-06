﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Portals.ComponentFramework.Interfaces.Test.Authentication
{
    public class LoopbackHttpListener : IDisposable
    {
        const int DefaultTimeout = 60 * 5; // 5 mins (in seconds)

        readonly IWebHost _host;
        readonly TaskCompletionSource<string?> _source = new TaskCompletionSource<string?>();
        readonly string _url;

        public string Url => _url;

        public LoopbackHttpListener(int port, string? path = null)
        {
            path = path ?? string.Empty;

            if (path.StartsWith("/"))
                path = path.Substring(1);

            _url = $"http://127.0.0.1:{port}/{path}";

            _host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(_url)
                .Configure(Configure)
                .Build();

            _host.Start();
        }

        public void Dispose()
        {
#pragma warning disable VSTHRD110 // Observe result of async calls
            Task.Run(async () =>
#pragma warning restore VSTHRD110 // Observe result of async calls
            {
                await Task.Delay(500);

                _host.Dispose();
            });
        }

        void Configure(IApplicationBuilder app)
        {
            app.Run(async ctx =>
            {
                if (ctx.Request.Method == "GET")
                {
                    await SetResultAsync(ctx.Request.QueryString.Value, ctx);
                }
                else if (ctx.Request.Method == "POST")
                {
                    if (ctx.Request.ContentType == null || !ctx.Request.ContentType.Equals("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase))
                    {
                        ctx.Response.StatusCode = 415;
                    }
                    else
                    {
                        using (var sr = new StreamReader(ctx.Request.Body, Encoding.UTF8))
                        {
                            var body = await sr.ReadToEndAsync();
                            await SetResultAsync(body, ctx);
                        }
                    }
                }
                else
                {
                    ctx.Response.StatusCode = 405;
                }
            });
        }

        private async Task SetResultAsync(string? value, HttpContext ctx)
        {
            try
            {
                ctx.Response.StatusCode = 200;
                ctx.Response.ContentType = "text/html";

                await ctx.Response.WriteAsync("<h1>You can now return to the application.</h1>" +
                    "<script type=\"text/javascript\">" +
                        "setTimeout(() => { self.close() }, 2000);" +
                    "</script>");

                await ctx.Response.Body.FlushAsync();

                _source.TrySetResult(value);
            }
            catch
            {
                ctx.Response.StatusCode = 400;
                ctx.Response.ContentType = "text/html";

                await ctx.Response.WriteAsync("<h1>Invalid request.</h1>" +
                    "<script type=\"text/javascript\">" +
                        "setTimeout(() => { self.close() }, 2000);" +
                    "</script>");

                await ctx.Response.Body.FlushAsync();
            }
        }

        public Task<string?> WaitForCallbackAsync(int timeoutInSeconds = DefaultTimeout)
        {
#pragma warning disable VSTHRD110 // Observe result of async calls
            Task.Run(async () =>
#pragma warning restore VSTHRD110 // Observe result of async calls
            {
                await Task.Delay(timeoutInSeconds * 1000);

                _source.TrySetCanceled();
            });

            return _source.Task;
        }
    }
}
