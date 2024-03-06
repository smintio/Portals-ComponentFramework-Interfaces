Description
===========

Calls component framework methods based on a certain page configuration.

Swagger documentation can be found [here](https://portals-development.smint.io:40443/apidocs/index.html?urls.primaryName=Smint.io%20Portals%20Frontend%20API#operations-Component_framework-executeDataAdapterConfigurationPublicApiInterfaceMethodForPortalsContext).

Current version of this document is: 1.0.0 (as of 29th of February, 2024)

## Usage

If a certain data adapter configuration is assigned to a specific page configuration, this method need to be used to call API methods of that data adapter configuration.

## Signature

POST `/portals/{portalUuid}/pageConfigurations/{pcUuid}/{propertyName}/{pi}/execute/{methodName}`

## Mandatory Parameters

- `portalUuid` - The portal UUID
- `pcUuid` - The page configuration UUID
- `propertyName` - The page configuration property name e.g. `assetsSearch`
- `pi` - The property index within the configuration
- `methodName` - The method name to be called of the data adapter public API e.g. `getAssetAsync`

## Optional Parameters

- `culture` - The culture that should be used to resolve language-specific content e.g. `en`, `de` or others
- `previewUuid` - The preview UUID

## Headers

- `X-Frontend-Context-Url` - The current frontend URL
- `X-Frontend-Context-Session-Id` - The current session ID

## Payload

The request body is in the form of an escaped string.
Since the nature of this endpoint is generic it can accept any string, however each 
public API method is expecting the data to be in a specific format.

Based on the usage example scenario the `getAssetAsync` method will expect an asset identifier.

```
["{\"assetId\":{\"id\":\"123:image:AVFgSgVHUP18jI2wRx0w\"}}"]
```

In this case, the backend will return an asset with the requested ID if found.

<details>
  <summary>
    The non escaped sample JSON payload looks like this
  </summary>

```JSON
[
  {
      "assetId": {
          "id": "123:image:AVFgSgVHUP18jI2wRx0w"
      }
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
