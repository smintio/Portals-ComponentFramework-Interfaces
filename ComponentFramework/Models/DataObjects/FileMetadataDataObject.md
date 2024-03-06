Description
===========
This README describes the properties of `FileMetadataDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- Represents metadata information related to a file.

## Properties
- `Name`: [LocalizedStringsModel](..//Common/LocalizedStringsModel.md) - The name of the file.
- `Description`: [LocalizedStringsModel](..//Common/LocalizedStringsModel.md) - The description of the file.
- `FileExtension`: string - The extension of the file.
- `FileName`: string - The name of the file including the extension.
- `FilePath`: string - The path of the file.
- `FileSizeInBytes`: long? - The size of the file in bytes.
- `MediaType`: string - The media type of the file.
- `Sha1Hash`: string - The SHA-1 hash of the file.
- `Language`: string - The language of the file.
- `Author`: string - The author of the file.
- `Creator`: string - The creator of the file.
- `Publisher`: string - The publisher of the file.
- `Company`: string - The company associated with the file.
- `Title`: string - The title of the file.
- `RawData`: [DataObject](DataObject.md)[] - Raw data associated with the file.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH