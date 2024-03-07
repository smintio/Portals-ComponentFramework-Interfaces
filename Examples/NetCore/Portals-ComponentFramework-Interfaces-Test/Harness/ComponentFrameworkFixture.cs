using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Portals.ComponentFramework.Interfaces.Test.Authentication;
using Portals.ComponentFramework.Interfaces.Test.Models;
using SmintIo.PortalsAPI.Frontend.Client.Generated;
using Xunit;

namespace Portals.ComponentFramework.Interfaces.Test.Harness
{
    public class ComponentFrameworkFixture : IAsyncLifetime
    {
        private readonly IConfiguration _configuration;

        private HttpClient _httpClient;

        public ComponentFrameworkFixture()
        {
            var executingAssemblyLocation = AppContext.BaseDirectory;

            var configurationBasePath = Path.GetDirectoryName(executingAssemblyLocation)!;

            _configuration = new ConfigurationBuilder()
               .SetBasePath(configurationBasePath)
               .AddJsonFile("appsettings.json", false)
               .AddJsonFile("appsettings.local.json", true)
               .AddEnvironmentVariables()
               .Build();

            BindSections(_configuration);
        }

        public ComponentFrameworkOptions ComponentFrameworkOptions { get; protected set; } = new ComponentFrameworkOptions();

        public PortalsAPIFEOpenApiClient PortalsAPIFEOpenApiClient { get; protected set; }

        public async Task InitializeAsync()
        {
            var accessToken = await IdentityProvider.GetAccessTokenAsync(_configuration);

            // Ideally use IHttpClientFactory.

            _httpClient = new HttpClient();

            var apiUrl = _configuration["SmintIo:ApiUrl"];

            if (string.IsNullOrEmpty(apiUrl))
            {
                throw new Exception("SmintIo API URL is empty");
            }

            PortalsAPIFEOpenApiClient = new PortalsAPIFEOpenApiClient(_httpClient)
            {
                BaseUrl = apiUrl,
                AccessToken = accessToken
            };
        }

        public Task DisposeAsync()
        {
            _httpClient?.Dispose();

            return Task.CompletedTask;
        }

        private void BindSections(IConfiguration configuration)
        {
            configuration.GetSection(ComponentFrameworkOptions.Name).Bind(ComponentFrameworkOptions);
        }
    }
}