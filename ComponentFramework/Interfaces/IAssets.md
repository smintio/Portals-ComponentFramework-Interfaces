Description
===========

Assets represents images, video, documents and others on the user interface.

The management of assets within a Smint.io Portal is organized into distinct actions, each represented by its own interface. These interfaces encapsulate specific functionalities related to reading, searching, downloading assets.

At the top level, the `IAssets` interface serves as the parent interface, inheriting all other assets-related interfaces.

All action outcomes are processed asynchronously and wrapped in a background task.
For more information on how background tasks are handled in Smint.io, please refer to the [background tasks documentation](../../BackgroundTasks/Endpoints/GetReadme.md).

To maintain brevity, we will solely specify which actions are either long-running or immediately executed. 

# IAssets Interface

The `IAssets` interface provides actions to access assets in Smint.io Portals.

## Child Interfaces

- [IAssetsRead](#IAssetsRead-Interface): Interface for reading assets.
- [IAssetsSearch](#IAssetsSearch-Interface): Interface for searching assets.
- [IAssetsReadRandom](#IAssetsReadRandom-Interface): Interface for reading assets randomly.

---

## IAssetsRead Interface

The `IAssetsRead` interface provides actions for reading assets.

Actions are only available when `Query asset details` permission is granted.

### Actions

#### GetAssetAsync

Retrieves details of a single asset based on the provided parameters.

##### Parameters

- An object containing parameters for retrieving the asset.
    - `AssetId` (AssetIdentifier): The identifier of the asset.
    - `ShareId` (string, optional): Optional share ID to access the asset.
    - `ShareSecret` (string, optional): Optional share secret to access the asset.
    - `IsPageEvent` (bool, optional): Indicates if this is a page event.

##### Input

```
'["{\\\"assetId\\\":{\\\"id\\\":\\\"123:image:00000000-0000-0000-0000-000000000000\\\"},\\\"isPageEvent\\\":true}"]'
```

##### Output

- Utilizes immediate execution through the background task mechanism.
- The `result_string` property will contain a returned [AssetDataObject](../Models/DataObjects/AssetDataObject.md), which returns details of the asset.

```JSON
{
    "assetDataObject": {
        "uuid": "123:image:00000000-0000-0000-0000-000000000000",
        "properties": [
            // ...
        ]
    }
}
```

<details>
  <summary>
    Example GetAssetAsync API call via C# client
  </summary>

```dotnet
using SmintIo.PortalsAPI.Frontend.Client.Generated;
// ...

try
{
    var httpClient = _httpClientFactory.CreateClient();

    var portalsAPIFEOpenApiClient = new PortalsAPIFEOpenApiClient(httpClient)
    {
        BaseUrl = "https://demo.portalsapife.smint.io/frontend/v1",
        AccessToken = "..."
    };

    var getAssetRequest = new
    {
        AssetId = new
        {
            Id = "123:image:00000000-0000-0000-0000-000000000000",
            IsPageEvent = true
        }
    };

    var body = JsonConvert.SerializeObject(getAssetRequest);

    BackgroundTask backgroundTask = null;

    try
    {
        backgroundTask = await portalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContextAsync(
            body,
            portalUuid: "345",
            publicApiInterface: "IAssetsRead",
            methodName: "getAssetAsync",
            previewUuid: null,
            x_Frontend_Context_Url: null,
            x_Frontend_Context_Session_Id: null,
            culture: "en").ConfigureAwait(false);
    }
    catch (ApiException<Error> apiException)
    {
        // ... 
    }

    if (backgroundTask?.State == BackgroundTaskStateEnum.Completed)
    {
        var getAssetResponse = JsonConvert.DeserializeObject<GetAssetResponse>(backgroundTask.Result_string);

        // ...
    }
}
catch (HttpRequestException hre)
{
    // ...
}
```

</details>

#### GetAssetsAsync

Retrieves details of multiple assets based on the provided parameters.

##### Parameters

- An object containing parameters for retrieving assets.
  - `AssetIds` (AssetIdentifier[]): An array of asset identifiers.
  - `ShareId` (string, optional): Optional share ID to access the assets.
  - `ShareSecret` (string, optional): Optional share secret to access the assets.

##### Input

```
'["{\\\"assetIds\\\":[{\\\"id\\\":\\\"123:image:00000000-0000-0000-0000-000000000000\\\"},{\\\"id\\\":\\\"123:video:00000000-0000-0000-0000-000000000000\\\"}]}"]'
```

##### Output

- Returns the UUID of the background operation. The background task must be queried until its state is completed. Then the `result_string` will contain a returned [AssetDataObject](../Models/DataObjects/AssetDataObject.md) array, which returns details of the assets.

```JSON
{
  "assetDataObjects": [
    {
      "uuid": "123:image:00000000-0000-0000-0000-000000000000",
      "properties": [
        // ...
      ]
      
    },
    {
      "uuid": "123:video:00000000-0000-0000-0000-000000000000",
      "properties": [
        // ...
      ]
    }
  ]
}
```

<details>
  <summary>
    Example GetAssetsAsync API call via C# client
  </summary>

```dotnet
using SmintIo.PortalsAPI.Frontend.Client.Generated;
// ...

try
{
    var httpClient = _httpClientFactory.CreateClient();

    var portalsAPIFEOpenApiClient = new PortalsAPIFEOpenApiClient(httpClient)
    {
        BaseUrl = "https://demo.portalsapife.smint.io/frontend/v1",
        AccessToken = "..."
    };

    var getAssetsRequest = new
    {
        AssetIds = new[]
        {
            new
            {
                Id = "123:image:00000000-0000-0000-0000-000000000000"
            },
            new
            {
                Id = "123:video:00000000-0000-0000-0000-000000000000"
            }
        }
    };

    var body = JsonConvert.SerializeObject(getAssetsRequest);

    try
    {
        var backgroundTask = await portalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContextAsync(
            body,
            portalUuid: "123",
            publicApiInterface: "IAssetsRead",
            methodName: "getAssetsAsync",
            previewUuid: null,
            x_Frontend_Context_Url: null,
            x_Frontend_Context_Session_Id: null,
            culture: "en").ConfigureAwait(false);

        // Please note that 'GetBackgroundTaskAsync' can be called repeatedly until the background task is completed

        backgroundTask = await portalsAPIFEOpenApiClient.GetBackgroundTaskAsync(backgroundTask.Uuid).ConfigureAwait(false);        

        if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
        {
            var assetsResponse = JsonConvert.DeserializeObject<GetAssetsResponse>(backgroundTask.Result_string);

            // ...
        }
    }
    catch (ApiException<Error> apiException)
    {
        // ... 
    }
}
catch (HttpRequestException hre)
{
    // ...
}
```

</details>

#### GetResourceAssetAsync

Retrieves details of a single resource asset based on the provided parameters.

##### Parameters

The same parameters as `GetAssetAsync`.

##### Input

It accepts the same input as `GetAssetAsync`.

##### Output

It outputs the same as `GetAssetAsync`.

#### GetResourceAssetsAsync

Retrieves details of multiple resource assets based on the provided parameters.

##### Parameters

The same parameters as `GetAssetsAsync`.

##### Input

It accepts the same input as `GetAssetsAsync`.

##### Output

It outputs the same as `GetAssetsAsync`.

---

## IAssetsSearch Interface

The `IAssetsSearch` interface provides actions to search for assets in Smint.io Portals.

Actions are only available when `Query asset details` and `Search assets` permission are granted.

### Actions

#### GetFeatureSupportAsync

Returns the supported features for the `IAssetsSearch` interface.

##### Input

```
'[]'
```

##### Output

- Utilizes immediate execution through the background task mechanism.
- The `result_string` property will contain a returned object, which returns details of the supported search features.

```JSON
{
    "uuid": "00000000-0000-0000-0000-000000000000",
    "state": "completed",
    "finished_percentage": 100,
    "total_steps": 1,
    "succeeded_steps": 1,
    "failed_steps": 0,
    "result_string": "{\"isRandomAccessSupported\":true,\"isFullTextSearchProposalsSupported\":false,\"isFolderNavigationSupported\":false}"
}
```

<details>
  <summary>
    Example GetFeatureSupportAsync API call via C# client
  </summary>

```dotnet
using SmintIo.PortalsAPI.Frontend.Client.Generated;
// ...

try
{
    var httpClient = new HttpClient();

    var portalsAPIFEOpenApiClient = new PortalsAPIFEOpenApiClient(httpClient)
    {
        BaseUrl = "https://demo.portalsapife.smint.io/frontend/v1",
        AccessToken = "..."
    };

    try
    {
        var backgroundTask = await portalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContextAsync(
              body: null,
              portalUuid: "123",
              publicApiInterface: "IAssetsSearch",
              methodName: "getFeatureSupportAsync",
              previewUuid: null,
              x_Frontend_Context_Url: null,
              x_Frontend_Context_Session_Id: null,
              culture: "en").ConfigureAwait(false);

        backgroundTask = await portalsAPIFEOpenApiClient.GetBackgroundTaskAsync(backgroundTask.Uuid).ConfigureAwait(false);

        if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
        {

            // ...
        }
    }
    catch (ApiException<Error> apiException)
    {
        // ... 
    }
}
catch (HttpRequestException hre)
{
    // ...
}

```

</details>

#### GetFormItemDefinitionAllowedValuesAsync

Returns the allowed values for a form item definition

##### Parameters

- An object containing parameters for retrieving allowed values.
  - `SearchQueryString` (string): Text entered by the user to match against searchable fields of the assets.
  - `CurrentFilters` (FormFieldValuesModel): Filters selected by the user.
  - `ContentType` (ContentType, optional): The content types of the assets to return.
  - `ResourceAssetMode` (ResourceAssetMode, optional): Specifies how to handle resource asset data adapters.
  - `AssetCategory` (string): The asset category of the asset to return.
  - `SearchResultSetUuid` (string, optional): The UUID of the last search result, for endless scrolling, if supported.
  - `FormItemDefinitionId` (string): The form item definition ID to get the allowed values for.
  - `FormItemDefinitionQueryString` (string): Text entered by the user to match against the list of allowed values.
  - `MaxResultCount` (int?, optional): The max result count.

##### Input

```
["{\"currentFilters\":{\"values\":[{\"id\":\"smintIoHub:dataAdapterInstanceKey\",\"dataType\":\"string\",\"stringValue\":\"da:12\"}]},\"formItemDefinitionQueryString\":\"Sunglasses\",\"maxResultCount\":5,\"resourceAssetMode\":0}"]
```

##### Output

- Utilizes immediate execution through the background task mechanism.
- The `result_string` property will contain a returned object, which returns details of the allowed values.

```JSON
{
    "allowedValues": [
        {
            "value": {
                "stringValue": "{\"kind\":\"AggregationFilter\",\"aggregationName\":\"descriptiveKeyword.descriptiveKeywords._refId\",\"filter\":{\"kind\":\"NestedFilter\",\"path\":\"descriptiveKeyword.descriptiveKeywords\",\"filter\":{\"kind\":\"TermFilter\",\"field\":\"descriptiveKeyword.descriptiveKeywords._refId\"}}}",
                "dataType": "string"
            },
            "name": {
                "x-default": "Sunglasses"
            },
            "count": 23
        }
    ],
    "allowedValuesTotalCount": 1
}
```

<details>
  <summary>
    Example GetFormItemDefinitionAllowedValuesAsync API call via C# client
  </summary>

```dotnet
using SmintIo.PortalsAPI.Frontend.Client.Generated;
// ...

try
{
    var httpClient = new HttpClient();

    var portalsAPIFEOpenApiClient = new PortalsAPIFEOpenApiClient(httpClient)
    {
        BaseUrl = "https://demo.portalsapife.smint.io/frontend/v1",
        AccessToken = "..."
    };

    var getFormItemDefinitionAllowedValuesRequest = new
    {
        CurrentFilters = new[]
        {
            new 
            {
                Values = new[]
                {
                    new
                    {
                        Id = "smintIoHub:dataAdapterInstanceKey",
                        DataType = "string",
                        StringValue = "da:123"
                    },
                }
            }                
        },
        FormItemDefinitionId = "innerNested-descriptiveKeyword.descriptiveKeywords._refId",
        FormItemDefinitionQueryString = "Sunglasses",
        MaxResultCount = 5,
        RresourceAssetMode = ResourceAssetMode.AssetsOnly
    };

    var body = JsonConvert.SerializeObject(getFormItemDefinitionAllowedValuesRequest);

    try
    {
        var backgroundTask = await portalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPageConfigurationAsync(
            body,
            portalUuid: "123",
            pcUuid: "456",
            propertyName: "assetsSearch",
            pi: 0,
            methodName: "getFormItemDefinitionAllowedValuesAsync",
            previewUuid: null,
            x_Frontend_Context_Url: null,
            x_Frontend_Context_Session_Id: null,
            culture: "en").ConfigureAwait(false);

        backgroundTask = await portalsAPIFEOpenApiClient.GetBackgroundTaskAsync(backgroundTask.Uuid).ConfigureAwait(false);

        if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
        {

            // ...
        }
    }
    catch (ApiException<Error> apiException)
    {
        // ... 
    }
}
catch (HttpRequestException hre)
{
    // ...
}

```

</details>

#### GetFormItemDefinitionAllowedValuesResourceAssetsAsync

Returns the allowed values for a form item definition for a resource asset type.

##### Parameters

The same parameters as `GetFormItemDefinitionAllowedValuesAsync` with an additional
- `ResourceAssetType` (string): The resource asset type of the resource assets to return.

##### Input

It accepts the same input as `GetFormItemDefinitionAllowedValuesAsync`.

##### Output

It outputs the same as `GetFormItemDefinitionAllowedValuesAsync`.

#### SearchAssetsAsync

Searches for assets based on the provided parameters.

##### Parameters

- An object containing parameters for searching assets.
  - `ParentFolderIds` (FolderIdentifier[], optional): Optional list of parent folder IDs to search within. Only supported if `IsFolderNavigationSupported` is true.
  - `ProductIds` (ProductIdentifier[], optional): Optional list of product IDs to search within.
  - `QueryString` (string): Text entered by the user to match against searchable fields of the assets.
  - `CurrentFilters` (FormFieldValuesModel): Filters selected by the user, usually targeting groups membership of the assets.
  - `ContentType` (ContentType, optional): The content type of the assets to return.
  - `ResourceAssetMode` (ResourceAssetMode, optional): Specifies how to handle resource asset data adapters.
  - `AssetCategory` (string): The asset category of the assets to return.
  - `SearchResultSetUuid` (string, optional): The UUID of the last search result, for endless scrolling, if supported.
  - `Page` (int?, optional): The page number, zero-based.
  - `PageSize` (int?, optional): The page size.

##### Input 

```JSON
[
  {
    "currentFilters": {
      "values": [
        {
          "id": "innerNested-oochialBrandAssets.campaign.name",
          "dataType": "string_array",
          "stringArrayValue": [
            {
              "kind": "AggregationFilter",
              "aggregationName": "oochialBrandAssets.campaign.name",
              "filter": {
                "kind": "NestedFilter",
                "path": "oochialBrandAssets.campaign",
                "filter": {
                  "kind": "TermFilter",
                  "field": "oochialBrandAssets.campaign.name",
                  "term": "Aviators"
                }
              }
            }
          ]
        }
      ]
    },
    "page": 0,
    "pageSize": 50,
    "resourceAssetMode": 0
  }
]
```

##### Output

- Utilizes immediate execution through the background task mechanism.
- The `result_string` property will contain a returned object, which returns details of the searched values.

```JSON
{
  "details": {
    "currentPage": 0,
    "currentItemsPerPage": 2,
    "maxPages": 1,
    "totalResults": 2,
    "hasMoreResults": false
  },
  "filterModel": {
    "formGroupDefinitions": [
      // ...
    ]
  },
  "assetDataObjects": [
    // ...
  ]
}
```

<details>
  <summary>
    Example SearchAssetsAsync API call via C# client
  </summary>

```dotnet
using SmintIo.PortalsAPI.Frontend.Client.Generated;
// ...

try
{
    var httpClient = new HttpClient();

    var portalsAPIFEOpenApiClient = new PortalsAPIFEOpenApiClient(httpClient)
    {
        BaseUrl = "https://demo.portalsapife.smint.io/frontend/v1",
        AccessToken = "..."
    };

    var getAssetsSearchRequest = new[]
    {
        new 
        {
            CurrentFilters = new
            {
                Values = new[]
                {
                    new
                    {
                        Id = "innerNested-oochialBrandAssets.campaign.name",
                        DataType = "string_array",
                        StringArrayValue = new[]
                        {
                            new
                            {
                                Kind = "AggregationFilter",
                                AggregationName = "oochialBrandAssets.campaign.name",
                                Filter = new
                                {
                                    Kind = "NestedFilter",
                                    Path = "oochialBrandAssets.campaign",
                                    Filter = new {
                                        Kind = "TermFilter",
                                        Field = "oochialBrandAssets.campaign.name",
                                        Term = "Aviators"
                                    }
                                }
                            }
                        }
                    },
                }
            },
            Page = 0,
            PageSize = 50,
            RresourceAssetMode = ResourceAssetMode.AssetsOnly
        }
    };

    var body = JsonConvert.SerializeObject(getAssetsSearchRequest);

    try
    {
        var backgroundTask = await portalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForPageConfigurationAsync(
            body,
            portalUuid: "123",
            pcUuid: "456",
            propertyName: "assetsSearch",
            pi: 0,
            methodName: "searchAssetsAsync",
            previewUuid: null,
            x_Frontend_Context_Url: null,
            x_Frontend_Context_Session_Id: null,
            culture: "en").ConfigureAwait(false);

        backgroundTask = await portalsAPIFEOpenApiClient.GetBackgroundTaskAsync(backgroundTask.Uuid).ConfigureAwait(false);

        if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
        {

            // ...
        }
    }
    catch (ApiException<Error> apiException)
    {
        // ... 
    }
}
catch (HttpRequestException hre)
{
    // ...
}

```

</details>

#### SearchResourceAssetsAsync

Searches for assets based on the provided parameters for a resource asset type.

##### Parameters

The same parameters as `SearchAssetsAsync` with an additional
- `ResourceAssetType` (string): The resource asset type of the resource assets to return.

##### Input

It accepts the same input as `SearchAssetsAsync`.

##### Output

It outputs the same as `SearchAssetsAsync`.

---

## IAssetsReadRandom Interface

The `IAssetsReadRandom` interface provides actions for retrieving random assets in Smint.io Portals.

Actions are only available when `Query asset details` permission is granted.

### Actions

#### GetRandomAssetsAsync

Retrieves a random asset based on the provided parameters.

This feature is only available when `isRandomAccessSupported` is true when `GetFeatureSupportAsync` is called.

##### Parameters

- An object containing parameters for retrieving random assets.
  - `ContentType` (ContentType, optional): The content type of the assets to return. If not set, defaults to image.
  - `ResourceAssetMode` (ResourceAssetMode, optional): Specifies how to handle resource asset data adapters.
  - `AssetCategory` (string): The asset category of the assets to return.
  - `Max` (int, optional): The maximum number of image assets to return. Defaults to 1.

##### Input

```
["{\"contentType\":0,\"max\":1}"]
```

##### Output

- Utilizes immediate execution through the background task mechanism.
- The `result_string` property will contain a returned [AssetDataObject](../Models/DataObjects/AssetDataObject.md) array, which returns details of the assets.

```JSON
{
  "assetDataObjects": [
    {
      "uuid": "123:image:00000000-0000-0000-0000-000000000000",
      "properties": [
        // ...
      ]      
    }
  ]
}
```

<details>
  <summary>
    Example GetRandomAssetsAsync API call via C# client
  </summary>

```dotnet
using SmintIo.PortalsAPI.Frontend.Client.Generated;
// ...

try
{
    var httpClient = _httpClientFactory.CreateClient();

    var portalsAPIFEOpenApiClient = new PortalsAPIFEOpenApiClient(httpClient)
    {
        BaseUrl = "https://demo.portalsapife.smint.io/frontend/v1",
        AccessToken = "..."
    };

    var getRandomAssetsRequest = new
    {
        ContentType = ContentType.Image,
        Max = 1
    };

    var body = JsonConvert.SerializeObject(getRandomAssetsRequest);

    try
    {
        var backgroundTask = await portalsAPIFEOpenApiClient.ExecuteDataAdapterConfigurationPublicApiInterfaceMethodForComponentConfigurationAsync(
            body,
            portalUuid: "123",
            pcUuid: "456",
            ccUuid: "789",
            propertyName: "backgroundImageRandomAsset",
            pi: 0,
            methodName: "getRandomAssetsAsync",
            previewUuid: null,
            x_Frontend_Context_Url: null,
            x_Frontend_Context_Session_Id: null,
            culture: "en").ConfigureAwait(false);

        if (backgroundTask.State == BackgroundTaskStateEnum.Completed)
        {
            var randomAssetsResponse = JsonConvert.DeserializeObject<GetRandomAssetsResponse>(backgroundTask.Result_string);

            // ...
        }
    }
    catch (ApiException<Error> apiException)
    {
        // ... 
    }
}
catch (HttpRequestException hre)
{
    // ...
}
```

</details>

### Common Enumerations

#### ContentType Enum

An enum representing the content type of assets.

- `Image`: Specifies that the asset type is an image.
- `Document`: Specifies that the asset type is a document.
- `Video`: Specifies that the asset type is a video.
- `Audio`: Specifies that the asset type is an audio file.

#### ResourceAssetMode Enum

An enum specifying how to handle resource asset data adapters.

- `AssetsOnly`: Specifies that only assets should be retrieved.
- `ResourceAssetsOnly`: Specifies that only resource assets should be retrieved.
- `AssetsAndResourceAssets`: Specifies that both assets and resource assets should be retrieved.