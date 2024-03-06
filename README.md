Description
===========
This repository offers comprehensive documentation for utilizing Smint.io Portals component framework data adapter interfaces and corresponding methods, with a focus on accommodating third-party developers.

Current version of this document is: 1.0.0 (as of 28th of February, 2024)

## Smint.io Portals Frontend API

The Smint.io Portals component framework is available through the `Smint.io Portals Frontend API`, which is a REST-based API.

Pre-built API clients for the Smint.io Portals Frontend API for C# and TypeScript are available on demand.

For calling any Smint.io Portals Frontend API endpoints, a bearer token is required. The bearer token can be acquired by using the industry standard OAuth2 protocol.

## Smint.io Portals Payload API

If, upfront, more information about the user and the portal is required, the `Smint.io Portals Payload API`, which is also REST-based API, can be used to query details, including e.g. the base URL of the Smint.io Portals Frontend API, if it is not known already.

Pre-built API clients for the Smint.io Portals Payload API for C# and TypeScript are available on demand.

For calling any Smint.io Portals Payload API endpoints, a bearer token is required. The bearer token can be acquired by using the industry standard OAuth2 protocol.

## Accessing documentation

The documentation for both the Smint.io Portals Frontend API and the Smint.io Portals Payload API is available on Swagger, but access is restricted.

Please note that you will be requested to sign a Non-Disclosure Agreement (NDA) before gaining access. 
To request access, please contact [Smint.io](mailto:support@smint.io).

Also note that, if you want to us the pre-built API clients, you will need an account with Microsoft Visual 
Studio cloud offerings (Azure DevOps), as the API clients are hosted there.

## Swagger page

If access is granted, you can find the Swagger documentation for both the Smint.io Portals Frontend API and the Smint.io Portals Payload API API by following these steps:

- Log into your Smint.io Portals backend
- Click the user icon
- Navigate to Help > Swagger docs
- Select the desired API from the definition selection dropdown

The methods required from the Smint.io Portals Frontend API are documented in section *Component framework* of this page.

Please note that the [DataObject](/ComponentFramework/Models/DataObjects/DataObject.md) parts of the API are based on a serialization of the DataObject objects that you can also find in the Smint.io Portals Frontend API Swagger docs - so you can refer to those.

## Component framework

### Endpoints

These are the generic REST endpoints needed for calling the Smint.io Portals component framework:

- [Portals context level methods](ComponentFramework/Endpoints/PortalContextLevelReadme.md)
- [Page template generic methods](ComponentFramework/Endpoints/PageConfigurationGenericReadme.md)
- [UI component generic methods](ComponentFramework/Endpoints/ComponentConfigurationGenericReadme.md)
- [Upload file](ComponentFramework/Endpoints/UploadFileReadme.md)

### Standard data adapter interfaces

Detailed coverage for each standard Smint.io Portals component framework data adapter interface and its methods is provided [here](/ComponentFramework/Interfaces/README.md).

### Examples

Examples of using the pre-built C# Smint.io Portals Frontend API client can be found [here](/Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/).

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH