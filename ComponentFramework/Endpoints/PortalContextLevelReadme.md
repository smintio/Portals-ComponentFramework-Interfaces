Description
===========

Some data adapter methods are not tied to the configuration of a specific UI component or page, but are tied to the overall portal context. Use this endpoint to call those methods.

Learn more about how to access the Swagger documentation for this method [here](../../README.md#swagger-page).

The complete list of standard data adapter interfaces and methods can be found [here](../Interfaces/README.md)

Current version of this document is: 1.0.0 (as of 29th of February, 2024)

## Usage

An example scenario utilizing this endpoint would be when requesting `assets`, `collections` or `shared links`. In such cases, the data adapter interface would be `IAssetsRead` with the method name `getAssetAsync`, `ICollectionsSearch` with method name `searchCollectionsAsync`, or alternatively `ISharesSearch` with method name `searchSharesAsync`

## Signature

POST `/portals/{portalUuid}/portalsContext/{publicApiInterface}/execute/{methodName}`

## Mandatory Parameters

- `portalUuid` - The portal UUID
- `publicApiInterface` - The name of the data adapter interface to be called, e.g. `IAssetsRead`, `ICollectionsSearch`, `ISharesSearch`
- `methodName` - The name of the method to be called, e.g. `getAssetAsync`, `searchCollectionsAsync`, `searchSharesAsync`

## Optional Parameters

- `culture` - The culture that should be used to resolve language-specific content e.g. `en`, `de` or others
- `previewUuid` - The preview UUID

## Headers

- `X-Frontend-Context-Url` - The current frontend URL
- `X-Frontend-Context-Session-Id` - The current session ID

## Payload

The request body is encoded as an escaped string. 

Since the nature of this endpoint is generic it can accept any string, however each 
method called is expecting the data to be in a specific format.

For example, the `searchCollectionsAsync` method anticipates input parameters including a query string, page number, page size, sorting criteria, and direction.

```
["{\"queryString\":\"Recent\",\"page\":1,\"pageSize\":16,\"sortBy\":\"createdAt\",\"sortDirection\":1}"]
```

In this case, the backend will retrieve collections containing the keyword 'Recent' in their name, sorted by creation date in descending order, with a page size of 16. The query string can also accept null, resulting in the retrieval of all collections based on paging.

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
