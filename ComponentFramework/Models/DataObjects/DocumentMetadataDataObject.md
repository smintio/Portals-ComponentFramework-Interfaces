Description
===========
This README describes the properties of `DocumentMetadataDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- Represents metadata information related to a document asset.

## Properties
- `ApplicationName`: string - The name of the application used to create the document.
- `ApplicationVersion`: string - The version of the application used to create the document.
- `CharacterCount`: int? - The total number of characters in the document.
- `CharacterCountWithSpaces`: int? - The total number of characters including spaces in the document.
- `LineCount`: int? - The total number of lines in the document.
- `PageCount`: int? - The total number of pages in the document.
- `SlideCount`: int? - The total number of slides in the document.
- `ParagraphCount`: int? - The total number of paragraphs in the document.
- `RevisionNumber`: int? - The revision number of the document.
- `Titles`: string[] - Array of titles in the document.
- `ImageTitles`: string[] - Array of image titles in the document.
- `EpsMetadata`: [EpsMetadataDataObject](EpsMetadataDataObject.md) - Metadata associated with EPS files in the document.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH