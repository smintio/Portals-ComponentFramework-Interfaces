Description
===========
This repository offers comprehensive documentation for utilizing Smint.io Portals component framework data adapter interfaces and corresponding methods, with a focus on accommodating third-party developers.

Current version of this document is: 1.0.1 (as of 7h of March, 2024)

## Smint.io Portals Frontend API

The Smint.io Portals component framework is available through the `Smint.io Portals Frontend API`, which is a REST-based API.

Pre-built API clients for the Smint.io Portals Frontend API for C# and TypeScript are available on demand.

Access to the pre-built API clients is restricted. Get in contact with Smint.io and request access.
Access will be granted to either Smint.io Solution Partners or to all our Smint.io Portals Enterprise plan customers.

Also note that, if you want to us the pre-built API clients, you will need an account with Microsoft Visual 
Studio cloud offerings (Azure DevOps), as the API clients are hosted there.

For calling any Smint.io Portals Frontend API endpoints, a bearer token is required. The bearer token can be acquired by using the industry standard OAuth2 protocol.

A C# example of acquiring an access token is available [here](/Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/Harness/ComponentFrameworkFixture.cs#L56).

## Smint.io Portals Payload API

If, upfront, more information about the user and the portal is required, the `Smint.io Portals Payload API`, which is also REST-based API, can be used to query details, including e.g. the base URL of the Smint.io Portals Frontend API, if it is not known already.

Access to the pre-built API clients is restricted. Get in contact with Smint.io and request access.
Access will be granted to either Smint.io Solution Partners or to all our Smint.io Portals Enterprise plan customers.

Also note that, if you want to us the pre-built API clients, you will need an account with Microsoft Visual 
Studio cloud offerings (Azure DevOps), as the API clients are hosted there.

For calling any Smint.io Portals Payload API endpoints, a bearer token is required. The bearer token can be acquired by using the industry standard OAuth2 protocol.

A C# example for using the Smint.io Portals Payload API is available [here](/Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/Harness/ComponentFrameworkFixture.cs#L64).

## Swagger page

You can find the Swagger documentation for both the Smint.io Portals Frontend API and the Smint.io Portals Payload API API by following these steps:

- Log into your Smint.io Portals backend
- Click the user icon
- Navigate to Help > Swagger docs
- Select the desired API from the definition selection dropdown

The methods required from the Smint.io Portals Frontend API are documented in section *Component framework* of this page.

Please note that the [DataObject](/ComponentFramework/Models/DataObjects/DataObject.md) parts of the API are based on a serialization of the DataObject objects that you can also find in the Smint.io Portals Frontend API Swagger docs - so you can refer to those.

## Component framework

### Endpoints

These are the REST endpoints needed for calling the Smint.io Portals component framework:

- [Portal level](ComponentFramework/Endpoints/PortalLevel.md)
- [Page level](ComponentFramework/Endpoints/PageLevel.md)
- [UI component level](ComponentFramework/Endpoints/UiComponentLevel.md)
- [Upload file](ComponentFramework/Endpoints/UploadFile.md)

### Standard data adapter interfaces

Detailed coverage for each standard Smint.io Portals component framework data adapter interface and its methods is provided [here](/ComponentFramework/Interfaces/README.md).

### Examples

Examples of using the pre-built C# Smint.io Portals Frontend API client can be found [here](/Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/).

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH