using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Portals.ComponentFramework.Interfaces.Test.Models;
using SmintIo.PortalsAPI.Frontend.Client.Generated;
using SmintIo.PortalsFEPortal.Client.Generated;
using Xunit;

namespace Portals.ComponentFramework.Interfaces.Test.Harness
{
    public class ComponentFrameworkFixture : IAsyncLifetime
    {
        private readonly IConfiguration _configuration;

        // Ideally use IHttpClientFactory.

        private HttpClient _portalsFePortalHttpClient = new();
        private HttpClient _portalsApiFeHttpClient = new();

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
            if (string.IsNullOrEmpty(ComponentFrameworkOptions.PortalUrl))
            {
                throw new Exception("Portal URL is empty");
            }

            var portalsFePortalUriBuilder = new UriBuilder(ComponentFrameworkOptions.PortalUrl)
            {
                Path = "/portal/v1"
            };

            var portalsFEPortalOpenApiClient = new PortalsFEPortalOpenApiClient(_portalsFePortalHttpClient)
            {
                BaseUrl = portalsFePortalUriBuilder.ToString()
            };

            var portalsPayload = await portalsFEPortalOpenApiClient.GetPortalsPayloadAsync(culture: "en");            

            PortalsAPIFEOpenApiClient = new PortalsAPIFEOpenApiClient(_portalsApiFeHttpClient)
            {
                BaseUrl = portalsPayload.Current_tenant.Backend_api_url,
                AccessToken = portalsPayload.Current_user.Access_token
            };

            ComponentFrameworkOptions.PortalUuid = portalsPayload.Current_portal_info.Uuid;
            ComponentFrameworkOptions.SearchPortalComponentUuid = portalsPayload.Current_portal_info.Page_router_infos.FirstOrDefault(pri => string.Equals(pri.Page_type, "page-type-assets-search"))?.Uuid;
        }

        public Task DisposeAsync()
        {
            _portalsFePortalHttpClient?.Dispose();
            _portalsApiFeHttpClient?.Dispose();

            return Task.CompletedTask;
        }

        private void BindSections(IConfiguration configuration)
        {
            configuration.GetSection(ComponentFrameworkOptions.Name).Bind(ComponentFrameworkOptions);
        }
    }
}