using System;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Portals.ComponentFramework.Interfaces.Test.Harness;
using SmintIo.PortalsAPI.Frontend.Client.Generated;
using Xunit;

namespace Portals.ComponentFramework.Interfaces.Test.Integration
{
    [Collection(nameof(ComponentFrameworkFixtureCollection))]
    public class AssetsReadTests
    {
        private readonly ComponentFrameworkFixture _fixture;

        public AssetsReadTests(ComponentFrameworkFixture fixture)
        {
            _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

            PortalsAPIFEOpenApiClient = _fixture.PortalsAPIFEOpenApiClient;
        }

        public PortalsAPIFEOpenApiClient PortalsAPIFEOpenApiClient { get; }

        [Fact]
        public async Task GetAsset_ShouldReturn_ResultAsync()
        {
            PortalsAPIFEOpenApiClient.AccessToken.Should().NotBeNullOrEmpty();

            var getAssetRequest = new
            {
                AssetId = new
                {
                    Id = "123:image:00000000-0000-0000-0000-000000000000",
                    IsPageEvent = true
                }
            };

            var body = JsonConvert.SerializeObject(getAssetRequest);

            var backgroundTask = await PortalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContextAsync(
                body,
                portalUuid: "345",
                publicApiInterface: "IAssetsRead",
                methodName: "getAssetAsync",
                previewUuid: null,
                x_Frontend_Context_Url: null,
                x_Frontend_Context_Session_Id: null,
                culture: "en");

            if (backgroundTask?.State == BackgroundTaskStateEnum.Completed)
            {
                // var getAssetResponse = JsonConvert.DeserializeObject<GetAssetResponse>(backgroundTask.Result_string);

                // ...
            }
        }
    }
}
