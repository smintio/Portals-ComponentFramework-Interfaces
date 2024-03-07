using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Portals.ComponentFramework.Interfaces.Test.Harness;
using Portals.ComponentFramework.Interfaces.Test.Models;
using Portals.ComponentFramework.Interfaces.Test.Models.Parameters;
using Portals.ComponentFramework.Interfaces.Test.Models.Results;
using SmintIo.PortalsAPI.Frontend.Client.Generated;
using Xunit;

namespace Portals.ComponentFramework.Interfaces.Test.Integration
{
    [Collection(nameof(ComponentFrameworkFixtureCollection))]
    public class IAssetsReadRandomTests(ComponentFrameworkFixture fixture) : IAssetsTests(fixture)
    {
        [Fact]
        public Task GetRandomAsset_ShouldReturn_ResultAsync()
        {
            return ExecuteAsync(async () =>
            {
                var getRandomAssetsParameters = new GetRandomAssetsParameters
                {
                    ContentType = 0,
                    Max = 1
                };

                var body = GetSerializedBody(getRandomAssetsParameters);

                var backgroundTask = await PortalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForComponentConfigurationAsync(
                     body,
                     portalUuid: ComponentFrameworkOptions.PortalUuid,
                     pcUuid: ComponentFrameworkOptions.RandomSearchPortalComponentUuid,
                     ccUuid: ComponentFrameworkOptions.RandomSearchComponentConfigurationUuid,
                     propertyName: "backgroundImageRandomAsset",
                     pi: ComponentFrameworkOptions.PropertyIndex,
                     methodName: "getRandomAssetsAsync",
                     previewUuid: null,
                     x_Frontend_Context_Url: null,
                     x_Frontend_Context_Session_Id: null,
                     culture: "en");

                if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
                {
                    backgroundTask.Result_string.Should().NotBeNullOrEmpty();

                    var getRandomAssetsResult = JsonConvert.DeserializeObject<GetRandomAssetsResult>(backgroundTask.Result_string);

                    getRandomAssetsResult.Should().NotBeNull();

                    getRandomAssetsResult.AssetDataObjects.Should().NotBeNullOrEmpty();
                    getRandomAssetsResult.AssetDataObjects.Should().HaveCountGreaterThan(0);

                    foreach (var assetDataObject in getRandomAssetsResult.AssetDataObjects)
                    {
                        assetDataObject.Should().NotBeNull();
                    }
                }
            });
        }
    }
}
