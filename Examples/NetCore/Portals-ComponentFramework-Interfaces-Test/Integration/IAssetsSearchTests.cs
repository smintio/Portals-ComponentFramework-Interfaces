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
    public class IAssetsSearchTests(ComponentFrameworkFixture fixture) : IAssetsTests(fixture)
    {
        [Fact]
        public Task GetFeatureSupport_ShouldReturn_ResultAsync()
        {
            return ExecuteAsync(async () =>
            {
                var backgroundTask = await PortalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContextAsync(
                    body: "[]",
                    portalUuid: ComponentFrameworkOptions.PortalUuid,
                    publicApiInterface: "IAssetsSearch",
                    methodName: "getFeatureSupportAsync",
                    previewUuid: null,
                    x_Frontend_Context_Url: null,
                    x_Frontend_Context_Session_Id: null,
                    culture: "en");

                if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
                {
                    backgroundTask.Result_string.Should().NotBeNullOrEmpty();

                    var getAssetsSearchFeatureSupportResult = JsonConvert.DeserializeObject<GetAssetsSearchFeatureSupportResult>(backgroundTask.Result_string);

                    getAssetsSearchFeatureSupportResult.Should().NotBeNull();
                }
            });
        }

        [Fact]
        public async Task SearchAssets_ShouldReturn_ResultAsync()
        {
            var searchAssetsParameters = new SearchAssetsParameters
            {
                CurrentFilters = new CurrentFiltersParameters
                {
                    Values = []
                },
                Page = 0,
                PageSize = 50,
                ResourceAssetMode = 0
            };

            await AssertSearchAssetsAsync(searchAssetsParameters);
        }

        [Fact]
        public async Task SearchAssets_Using_Filter_ShouldReturn_ResultAsync()
        {
            var searchAssetsParameters = new SearchAssetsParameters
            {
                CurrentFilters = new CurrentFiltersParameters
                {
                    Values =
                    [
                        new  ValueParameters
                        {
                            Id = "smintIoHub:dataAdapterInstanceKey",
                            DataType = "string",
                            StringValue = ComponentFrameworkOptions.SearchFilterDataAdapterInstance
                        },
                        new ValueParameters
                        {
                            Id = ComponentFrameworkOptions.SearchFilterId,
                            DataType = "string_array",
                            StringArrayValue = [ComponentFrameworkOptions.SearchFilterValue]
                        },
                    ]
                },
                Page = 0,
                PageSize = 50,
                ResourceAssetMode = 0
            };

            await AssertSearchAssetsAsync(searchAssetsParameters);
        }

        private Task AssertSearchAssetsAsync(SearchAssetsParameters searchAssetsParameters)
        {
            return ExecuteAsync(async () =>
            {
                var body = GetSerializedBody(searchAssetsParameters);

                var backgroundTask = await PortalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPageConfigurationAsync(
                    body,
                    portalUuid: ComponentFrameworkOptions.PortalUuid,
                    pcUuid: ComponentFrameworkOptions.SearchPortalComponentUuid,
                    propertyName: "assetsSearch",
                    pi: ComponentFrameworkOptions.PropertyIndex,
                    methodName: "searchAssetsAsync",
                    previewUuid: null,
                    x_Frontend_Context_Url: null,
                    x_Frontend_Context_Session_Id: null,
                    culture: "en");

                if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
                {
                    backgroundTask.Result_string.Should().NotBeNullOrEmpty();

                    var searchAssetsResult = JsonConvert.DeserializeObject<SearchAssetsResult>(backgroundTask.Result_string);

                    searchAssetsResult.Should().NotBeNull();

                    searchAssetsResult.AssetDataObjects.Should().NotBeNullOrEmpty();
                    searchAssetsResult.AssetDataObjects.Should().HaveCountGreaterThan(0);

                    foreach (var assetDataObject in searchAssetsResult.AssetDataObjects)
                    {
                        assetDataObject.Should().NotBeNull();
                    }

                    searchAssetsResult.Details.Should().NotBeNull();

                    searchAssetsResult.FilterModel.Should().NotBeNull();
                    searchAssetsResult.FilterModel.FormGroupDefinitions.Should().NotBeNullOrEmpty();

                    foreach (var formGroupDefinition in searchAssetsResult.FilterModel.FormGroupDefinitions)
                    {
                        formGroupDefinition.Should().NotBeNull();
                    }
                }
            });
        }
    }
}
