Description
===========

Calls component framework methods based on a certain page configuration and a certain component configuration.

Swagger documentation can be found at `https://{tenant}.smint.io/apidocs/index.html` or see how to get the full URL [here](../../README.md#swagger-page).
- Replace `{tenant}` with the target environment e.g. `demo`
- Select `Smint.io Portals Frontend Api` from the definition selection dropdown
- Find and expand `Component framework`
- Expand `Calls component framework methods`

Current version of this document is: 1.0.0 (as of 29th of February, 2024)

## Usage

If a certain data adapter configuration is assigned to a specific UI component configuration on a specific page configuration, this method need to be used to call API methods of that data adapter configuration.

## Signature

POST `/portals/{portalUuid}/pageConfigurations/{pcUuid}/componentConfigurations/{ccUuid}/{propertyName}/{pi}/execute/{methodName}`

## Mandatory Parameters

- `portalUuid` - The portal UUID
- `pcUuid` - The page configuration UUID
- `ccUuid` - The UI component configuration UUID
- `propertyName` - The page configuration property name e.g. `backgroundImageRandomAsset`
- `pi` - The property index within the UI component configuration
- `methodName` - The method name to be called of the data adapter public API e.g. `getRandomAssetsAsync`

## Optional Parameters

- `culture` - The culture that should be used to resolve language-specific content e.g. `en`, `de` or others
- `previewUuid` - The preview UUID

## Headers

- `X-Frontend-Context-Url` - The current frontend URL
- `X-Frontend-Context-Session-Id` - The current session ID

## Payload

The request body is in the form of an escaped string.

Since the nature of this endpoint is generic it can accept any string, 
however each public API method is expecting the data to be in a specific format.

Based on the usage example scenario the `getRandomAssetsAsync` method will expect an asset content type and the maximum number of assets to return.

```
["{\"contentType\":0,\"max\":1}"]
```

In this case, the backend will return a random asset for the requested content type.

<details>
  <summary>
    The non escaped sample JSON payload looks like this
  </summary>

```JSON
[
    {
    "contentType": 0,
    "max": 1
    }
]
```

</details>

## Response

The returned response is wrapped in a `BackgroundTask` result as listed in the `Schema` section in the Swagger documentation.

If the background task has state completed, will contain an escaped string result.

```JSON
{
    "uuid": "...",
    "state": "completed",
    "finished_percentage": 100,
    "total_steps": 1,
    "succeeded_steps": 1,
    "failed_steps": 0,
    "result_string": "'{\"assetDataObject\":...}'"
}
```

<details>
  <summary>
    The non escaped sample JSON result string
  </summary>

```JSON
{
  "assetDataObject": {
    "uuid": "123:image:AVFgSgVHUP18jI2wRx0w",
    "properties": [
        // ...
    ]
  }
}
```

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
