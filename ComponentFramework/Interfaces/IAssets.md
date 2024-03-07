Description
===========

An asset is usually a file-based record, such as an image, a video or a document. Assets also can be composed of other assets (composable assets).

All asset-related functionality within the Smint.io Portal component framework is grouped into different data adapter interfaces. These different data adapter interfaces encapsulate specific functionalities related to reading, searching, downloading assets.

At the top level, the `IAssets` data adapter interface serves as the parent data adapter interface, inheriting all other more specific asset-related data adapter interfaces.

All method outcomes are processed asynchronously and wrapped in a background task.

For more information on how background tasks are handled in Smint.io, please refer to the [background tasks documentation](../../BackgroundTasks/Endpoints/BackgroundTask.md).

To maintain brevity, we will solely specify which methods are either long-running or immediately executed. 

# IAssets

The `IAssets` data adapter interface provides methods to access assets in Smint.io Portals.

## Inherited interfaces

- [IAssetsRead](#IAssetsRead): Data adapter interface for reading assets.
- [IAssetsSearch](#IAssetsSearch): Data adapter interface for searching assets.
- [IAssetsReadRandom](#IAssetsReadRandom): Data adapter interface for reading assets randomly.

---

## IAssetsRead

The `IAssetsRead` data adapter interface provides methods for reading assets.

Methods are only available when `Query asset details` permission is granted.

### Methods

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

##### Example

- GetAssetAsync API call via C# client can be found [here](../../Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/Integration/IAssetsReadTests.cs#L17).

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

##### Example

- GetAssetsAsync API call via C# client can be found [here](../../Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/Integration/IAssetsReadTests.cs#L55).

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

## IAssetsSearch

The `IAssetsSearch` data adapter interface provides methods to search for assets in Smint.io Portals.

Methods are only available when `Query asset details` and `Search assets` permission are granted.

### Methods

#### GetFeatureSupportAsync

Returns the supported features of the specific underlying `IAssetsSearch` implementation.

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
##### Example

- GetFeatureSupportAsync API call via C# client can be found [here](../../Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/Integration/IAssetsSearchTests.cs#L17).

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

##### Example

- GetFormItemDefinitionAllowedValuesAsync API call via C# client can be found [here](../../Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/Integration/IAssetsSearchTests.cs#L60).

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

##### Example

- SearchAssetsAsync API call via C# client can be found [here](../../Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/Integration/IAssetsSearchTests.cs#L43).
- 
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

## IAssetsReadRandom

The `IAssetsReadRandom` data adapter interface provides methods for retrieving random assets in Smint.io Portals.

Methods are only available when `Query asset details` permission is granted.

### Methods

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

##### Example

- GetRandomAssetsAsync API call via C# client can be found [here](../../Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/Integration/IAssetsReadRandomTests.cs#L17).

### Common enumerations

#### ContentType enum

An enum representing the content type of assets.

- `Image`: Specifies that the asset type is an image.
- `Document`: Specifies that the asset type is a document.
- `Video`: Specifies that the asset type is a video.
- `Audio`: Specifies that the asset type is an audio file.

#### ResourceAssetMode enum

An enum specifying how to handle resource asset data adapters.

- `AssetsOnly`: Specifies that only assets should be retrieved.
- `ResourceAssetsOnly`: Specifies that only resource assets should be retrieved.
- `AssetsAndResourceAssets`: Specifies that both assets and resource assets should be retrieved.