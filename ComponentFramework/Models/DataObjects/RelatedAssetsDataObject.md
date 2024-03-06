Description
===========
This README describes the properties of `RelatedAssetsDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- Represents metadata information related to a vector asset.

## Properties
- `Type`: [RelationshipTypeEnumDataObject](RelationshipTypeEnumDataObject.md) - The type of relationship.
- `AssetIds`: string[] - Array of asset IDs.
- `SearchAssetsSpecJson`: string - JSON string representing search asset specifications.
- `Caption`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - The caption associated with the related assets.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH