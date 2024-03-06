Description
===========

Upload a file for later use in component framework.

Learn more about how to access the Swagger documentation for this method [here](../../README.md#swagger-page).

Current version of this document is: 1.0.0 (as of 29th of February, 2024)

## Usage

For uploading files for later use in the component framework.

An example scenario could involve parsing data directly sourced from a CSV or Excel file.

## Signature

POST `/portals/{portalUuid}/portalsContext/uploadFile`

## Mandatory parameters

- `portalUuid` - The portal UUID

## Payload

The body should be 'multipart/form-data' containing the file data as part of the request.

## Response

The returned response is in JSON format containing the UUID of the newly uploaded file, for further reference.

```JSON
{
    "uuid": "AVFgSgVHUP18jI2wRx0w"
}
```

## Error handling

In the Swagger documentation, you can find the status codes and error codes associated with the API operations. In case of errors, appropriate HTTP status codes will be returned along with error details in the response body.

### Example error response

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
