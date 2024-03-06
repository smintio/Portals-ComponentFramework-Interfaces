Description
===========

A set of API methods is not tied to a specific page or UI component configuration, but is available in the overall portal context. Use this endpoint to call those methods.

The complete list of supported public API interfaces can be found [here](../Interfaces/README.md)

Swagger documentation can be found [here](https://portals-development.smint.io:40443/apidocs/index.html?urls.primaryName=Smint.io%20Portals%20Frontend%20API#operations-Component_framework-executeDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContext).

Current version of this document is: 1.0.0 (as of 29th of February, 2024)

## Usage

An example scenario utilizing this endpoint would be when requesting `assets`, `collections` or `shared links`. In such cases, the interface would be `IAssetsRead` with the method name `getAssetAsync`, `ICollectionsSearch` with  method name `searchCollectionsAsync` or alternatively `ISharesSearch` with method name `searchSharesAsync`

## Signature

POST `/portals/{portalUuid}/portalsContext/{publicApiInterface}/execute/{methodName}`

## Mandatory Parameters

- `portalUuid` - The portal UUID
- `publicApiInterface` - The API interface to be called e.g. `IAssetsRead`, `ICollectionsSearch`, `ISharesSearch` and others
- `methodName` - The method name to be called of the data adapter public API e.g. `getAssetAsync`, `searchCollectionsAsync`, `searchSharesAsync` and others

## Optional Parameters

- `culture` - The culture that should be used to resolve language-specific content e.g. `en`, `de` or others
- `previewUuid` - The preview UUID

## Headers

- `X-Frontend-Context-Url` - The current frontend URL
- `X-Frontend-Context-Session-Id` - The current session ID

## Payload

The request body is encoded as an escaped string. While this endpoint is designed to be generic and can accept any string input, it is important to note that each public API method requires the data to be formatted in a specific manner.

In the example usage scenario, the `searchCollectionsAsync` method anticipates input parameters including a query string, page number, page size, sorting criteria, and direction.

```
["{\"queryString\":\"Recent\",\"page\":1,\"pageSize\":16,\"sortBy\":\"createdAt\",\"sortDirection\":1}"]
```

In this scenario, the backend will retrieve collections containing the keyword 'Recent' in their name, sorted by creation date in descending order, with a page size of 16. The query string can also accept null, resulting in the retrieval of all collections based on paging.

<details>
  <summary>
    The unescaped sample JSON payload appears as follows
  </summary>

```JSON
[
  {
      "queryString": "Recent",
      "page": 1,
      "pageSize": 16,
      "sortBy": "createdAt",
      "sortDirection": 1
  }
]
```

</details>

## Response

The response is encapsulated within a `BackgroundTask` result, as detailed in the Schema section of the Swagger documentation. If the background task's state is marked as completed, it will contain an escaped string result.

```JSON
{
    "uuid": "...",
    "state": "completed",
    "finished_percentage": 100,
    "total_steps": 1,
    "succeeded_steps": 1,
    "failed_steps": 0,
    "result_string": "'{\"collections\":...}'"
}
```

<details>
  <summary>
    The unescaped sample JSON result string
  </summary>

```JSON
{
  "collections": [
    {
      "collectionId": "10",
      "name": "Recent photos",
      "previews": {
        "preview": [
          {
            "largeThumbnailUrl": "...",
            "previewThumbnailUrl": "..."
          },
          {
            "largeThumbnailUrl": "...",
            "previewThumbnailUrl": "..."
          }
        ]
      },
      "totalCommentCount": 1
    }
  ],
  "details": {
    "totalResults": 1
  }
}
```

The example response shows that a collection with id '10' called 'Recent photos' is returned, which has two assets with their respective thumbnail URLs
</details>

## Error Handling

In the Swagger documentation, you can find the status codes and error codes associated with the API operations. In case of errors, appropriate HTTP status codes will be returned along with error details in the response body.

### Example Error Response

```json
{
  "error_code": "string",
    "error_message": "string",
    "error_details": {
      "uuid": "string",
      "name": "string"
    }  
  }
```

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH
