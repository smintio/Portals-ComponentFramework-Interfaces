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
        private const string _baseUrl = "https://demo.portalsapife.smint.io/frontend/v1";

        private readonly IConfiguration _configuration;

        private HttpClient _httpClient;

        public ComponentFrameworkFixture()
        {
            _configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
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

            PortalsAPIFEOpenApiClient = new PortalsAPIFEOpenApiClient(_httpClient)
            {
                BaseUrl = _baseUrl,
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