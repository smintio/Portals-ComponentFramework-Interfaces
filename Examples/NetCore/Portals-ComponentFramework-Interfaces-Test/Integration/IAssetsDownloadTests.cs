using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Portals.ComponentFramework.Interfaces.Test.Harness;
using Portals.ComponentFramework.Interfaces.Test.Models.Parameters;
using Portals.ComponentFramework.Interfaces.Test.Models.Results;
using SmintIo.PortalsAPI.Frontend.Client.Generated;
using Xunit;

namespace Portals.ComponentFramework.Interfaces.Test.Integration
{
    [Collection(nameof(ComponentFrameworkFixtureCollection))]
    public class IAssetsDownloadTests(ComponentFrameworkFixture fixture) : IAssetsTests(fixture)
    {
        [Fact]
        public Task GetAssetsDownloadsForAssets_ShouldReturn_ResultAsync()
        {
            return ExecuteAsync(async () =>
            {
                var getAssetsDownloadsForAssetsParameters = new GetAssetsDownloadsForAssetsParameters
                {
                    AssetIds =
                    [
                        new AssetIdentifierParameters
                        {
                            Id = ComponentFrameworkOptions.ImageAssetId
                        }
                    ]
                };

                var getAssetsDownloadsResult = await GetAssetsDownloadsResultAsync(getAssetsDownloadsForAssetsParameters).ConfigureAwait(false);

                getAssetsDownloadsResult.Should().NotBeNull();

                getAssetsDownloadsResult.AssetDownloadGroups.Should().NotBeNullOrEmpty();
                getAssetsDownloadsResult.AssetDownloadGroups.Should().HaveCountGreaterThan(0);

                foreach (var assetDownloadGroupResult in getAssetsDownloadsResult.AssetDownloadGroups)
                {
                    assetDownloadGroupResult.Should().NotBeNull();

                    assetDownloadGroupResult.GroupId.Should().NotBeNullOrEmpty();
                    assetDownloadGroupResult.GroupName.Should().NotBeNullOrEmpty();

                    foreach (var assetDownloadItem in assetDownloadGroupResult.AssetDownloadItems)
                    {
                        assetDownloadItem.Should().NotBeNull();

                        assetDownloadItem.Description.Should().NotBeNullOrEmpty();
                    }
                }
            });
        }

        [Fact]
        public Task InitiateAssetsDownload_ShouldReturn_ResultAsync()
        {
            return ExecuteAsync(async () =>
            {
                var imageAssetIdentifierParameters = new AssetIdentifierParameters
                {
                    Id = ComponentFrameworkOptions.ImageAssetId
                };

                var getAssetsDownloadsForAssetsParameters = new GetAssetsDownloadsForAssetsParameters
                {
                    AssetIds = [imageAssetIdentifierParameters]
                };

                var getAssetsDownloadsResult = await GetAssetsDownloadsResultAsync(getAssetsDownloadsForAssetsParameters).ConfigureAwait(false);

                getAssetsDownloadsResult.Should().NotBeNull();

                var assetDownloadItemParameters = getAssetsDownloadsResult
                    .AssetDownloadGroups.FirstOrDefault()?
                    .AssetDownloadItems.FirstOrDefault()?
                    .ToAssetDownloadItemParameters();

                if (assetDownloadItemParameters == null)
                {
                    return;
                }

                var initiateAssetsDownloadForAssetsParameters = new InitiateAssetsDownloadForAssetsParameters
                {
                    AssetIds = [imageAssetIdentifierParameters],
                    AssetDownloadItems = [assetDownloadItemParameters],
                    ImmediatelyDownload = true
                };

                var body = GetSerializedBody(initiateAssetsDownloadForAssetsParameters);

                var backgroundTask = await PortalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContextAsync(
                    body,
                    portalUuid: ComponentFrameworkOptions.PortalUuid,
                    publicApiInterface: "IAssetsDownload",
                    methodName: "initiateAssetsDownloadForAssetsAsync",
                    previewUuid: null,
                    x_Frontend_Context_Url: null,
                    x_Frontend_Context_Session_Id: null,
                    culture: "en").ConfigureAwait(false);

                while (backgroundTask.State == BackgroundTaskStateEnum.In_progress)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));

                    backgroundTask = await PortalsAPIFEOpenApiClient.GetBackgroundTaskAsync(backgroundTask.Uuid);
                }

                if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
                {
                    var initiateAssetsDownloadResult = JsonConvert.DeserializeObject<InitiateAssetsDownloadResult>(backgroundTask.Result_string);

                    initiateAssetsDownloadResult.Should().NotBeNull();
                    initiateAssetsDownloadResult.AssetDownloadUrl.Should().NotBeNull();
                    initiateAssetsDownloadResult.AssetDownloadUrl.Url.Should().NotBeNullOrEmpty();
                }
            });
        }

        private async Task<GetAssetsDownloadsResult> GetAssetsDownloadsResultAsync(GetAssetsDownloadsForAssetsParameters getAssetsDownloadsForAssetsParameters)
        {
            var body = GetSerializedBody(getAssetsDownloadsForAssetsParameters);

            var backgroundTask = await PortalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContextAsync(
                body,
                portalUuid: ComponentFrameworkOptions.PortalUuid,
                publicApiInterface: "IAssetsDownload",
                methodName: "getAssetsDownloadsForAssetsAsync",
                previewUuid: null,
                x_Frontend_Context_Url: null,
                x_Frontend_Context_Session_Id: null,
                culture: "en").ConfigureAwait(false);

            while (backgroundTask.State == BackgroundTaskStateEnum.In_progress)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                backgroundTask = await PortalsAPIFEOpenApiClient.GetBackgroundTaskAsync(backgroundTask.Uuid);
            }

            if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
            {
                var getAssetsDownloadsResult = JsonConvert.DeserializeObject<GetAssetsDownloadsResult>(backgroundTask.Result_string);

                return getAssetsDownloadsResult;
            }

            return null;
        }
    }
}