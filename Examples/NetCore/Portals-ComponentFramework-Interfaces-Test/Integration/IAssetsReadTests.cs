using System;
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
    public class IAssetsReadTests(ComponentFrameworkFixture fixture) : IAssetsTests(fixture)
    {
        [Fact]
        public Task GetAsset_ShouldReturn_ResultAsync()
        {
            return ExecuteAsync(async () =>
            {
                var getAssetParameters = new GetAssetParameters
                {
                    AssetId = new AssetIdentifierParameters
                    {
                        Id = ComponentFrameworkOptions.ImageAssetId
                    },
                    IsPageEvent = true
                };

                var body = GetSerializedBody(getAssetParameters);

                var backgroundTask = await PortalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContextAsync(
                    body,
                    portalUuid: ComponentFrameworkOptions.PortalUuid,
                    publicApiInterface: "IAssetsRead",
                    methodName: "getAssetAsync",
                    previewUuid: null,
                    x_Frontend_Context_Url: null,
                    x_Frontend_Context_Session_Id: null,
                    culture: "en");

                if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
                {
                    backgroundTask.Result_string.Should().NotBeNullOrEmpty();

                    var getAssetResult = JsonConvert.DeserializeObject<GetAssetResult>(backgroundTask.Result_string);

                    getAssetResult.Should().NotBeNull();
                    getAssetResult.AssetDataObject.Should().NotBeNull();
                }
            });
        }

        [Fact]
        public Task GetAssets_ShouldReturn_ResultAsync()
        {
            return ExecuteAsync(async () =>
            {
                var getAssetsParameters = new GetAssetsParameters
                {
                    AssetIds =
                    [
                        new AssetIdentifierParameters
                        {
                            Id = ComponentFrameworkOptions.ImageAssetId
                        },
                        new AssetIdentifierParameters
                        {
                            Id = ComponentFrameworkOptions.VideoAssetId
                        }
                    ]
                };

                var body = GetSerializedBody(getAssetsParameters);

                var backgroundTask = await PortalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContextAsync(
                    body,
                    portalUuid: ComponentFrameworkOptions.PortalUuid,
                    publicApiInterface: "IAssetsRead",
                    methodName: "getAssetsAsync",
                    previewUuid: null,
                    x_Frontend_Context_Url: null,
                    x_Frontend_Context_Session_Id: null,
                    culture: "en");

                while (backgroundTask.State == BackgroundTaskStateEnum.In_progress)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));

                    backgroundTask = await PortalsAPIFEOpenApiClient.GetBackgroundTaskAsync(backgroundTask.Uuid);
                }

                if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
                {
                    backgroundTask.Result_string.Should().NotBeNullOrEmpty();

                    var getAssetsResult = JsonConvert.DeserializeObject<GetAssetsResult>(backgroundTask.Result_string);

                    getAssetsResult.Should().NotBeNull();

                    getAssetsResult.AssetDataObjects.Should().NotBeNullOrEmpty();
                    getAssetsResult.AssetDataObjects.Should().HaveCountGreaterThan(0);

                    foreach (var assetDataObject in getAssetsResult.AssetDataObjects)
                    {
                        assetDataObject.Should().NotBeNull();
                    }
                }
            });
        }
    }
}
