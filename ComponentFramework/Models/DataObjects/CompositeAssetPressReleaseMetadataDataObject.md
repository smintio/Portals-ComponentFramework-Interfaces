Description
===========
This README describes the properties of `CompositeAssetPressReleaseMetadataDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- Represents metadata information related to a composite asset press release.

## Properties
- `Title`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - The title of the press release.
- `Summary`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - The summary of the press release.
- `Date`: DateTimeOffset? - The date of the press release.
- `Time`: string - The time of the press release.
- `Location`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - The location of the press release.
- `TextBlock1`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - The first text block of the press release.
- `TextBlock2`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - The second text block of the press release.
- `QuoteText`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - The quoted text of the press release.
- `QuoteOrigin`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - The origin of the quoted text.
- `About`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - Information about the press release.
- `ContactName`: string - The name of the contact person.
- `ContactAddress`: string - The address of the contact person.
- `ContactEmailAddress`: string - The email address of the contact person.
- `ContactPhoneNumber`: string - The phone number of the contact person.
- `Link1`: [LinkDataObject](LinkDataObject.md) - Link associated with the press release.
- `Link2`: [LinkDataObject](LinkDataObject.md) - Link associated with the press release.
- `Link3`: [LinkDataObject](LinkDataObject.md) - Link associated with the press release.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH