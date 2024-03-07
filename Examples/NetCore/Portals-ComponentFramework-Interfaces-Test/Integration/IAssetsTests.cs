using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Portals.ComponentFramework.Interfaces.Test.Harness;
using Portals.ComponentFramework.Interfaces.Test.Models;
using SmintIo.PortalsAPI.Frontend.Client.Generated;

namespace Portals.ComponentFramework.Interfaces.Test.Integration
{
    public abstract class IAssetsTests
    {
        public IAssetsTests(ComponentFrameworkFixture fixture)
        {
            ArgumentNullException.ThrowIfNull(fixture);

            PortalsAPIFEOpenApiClient = fixture.PortalsAPIFEOpenApiClient;
            ComponentFrameworkOptions = fixture.ComponentFrameworkOptions;
        }

        protected PortalsAPIFEOpenApiClient PortalsAPIFEOpenApiClient { get; }

        protected ComponentFrameworkOptions ComponentFrameworkOptions { get; }

        protected static async Task ExecuteAsync(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch (ApiException<Error>)
            {
                // Handle exception
            }
        }

        protected static string GetSerializedBody(object obj)
        {
            var serializedRequest = JsonConvert.SerializeObject(obj);
            var doubleEscaped = serializedRequest.Replace("\"", "\\\"");

            var body = $"['{doubleEscaped}']";

            return body;
        }
    }
}
