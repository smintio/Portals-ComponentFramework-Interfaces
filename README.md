Description
===========
This repository offers comprehensive documentation for utilizing Smint.io component framework interfaces and corresponding methods, with a focus on accommodating third-party developers.

Current version of this document is: 1.0.0 (as of 28th of February, 2024)

## Accessing Documentation

Smint.io component framework API documentation is available on Swagger, but access is restricted.
Please note that you will be requested to sign a Non-Disclosure Agreement (NDA) before gaining access. 
To request access, please contact [Smint.io](mailto:support@smint.io).

Also note that you will need an account with Microsoft Visual Studio cloud offerings (Azure DevOps), as the SDKs are hosted there.

## Swagger Page

If access is granted, you can find the Swagger documentation URL by following these steps:

- Log into `Smint.io Portals Backend`
- Click the user icon
- Navigate to Help > Swagger docs
- Select `Smint.io Portals Frontend API` from the definition selection dropdown

The methods required from the Smint.io Portals Frontend API are documented in section 'Component Framework' of this page.

Please note that the [DataObject](/ComponentFramework/Models/DataObjects/DataObject.md) parts of the API are based on a serialization of the DataObject objects that you can also find in the Smint.io Portals Frontend API Swagger Docs - so you can refer to that.

## Component Framework Section

Generic endpoints for the Smint.io Portals component framework.

### Endpoints

- [Portals context level methods](ComponentFramework/Endpoints/PortalContextLevelReadme.md)
- [Upload file](ComponentFramework/Endpoints/UploadFileReadme.md)
- [Page configuration generic methods](ComponentFramework/Endpoints/PageConfigurationGenericReadme.md)
- [Component configuration generic methods](ComponentFramework/Endpoints/ComponentConfigurationGenericReadme.md)

### Interfaces Coverage

Detailed coverage for each component framework interface and its methods is provided [here](/ComponentFramework/Interfaces/README.md).

### Examples

Examples of using the C# public API client can be found [here](/Examples/NetCore/Portals-ComponentFramework-Interfaces-Test/).

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH