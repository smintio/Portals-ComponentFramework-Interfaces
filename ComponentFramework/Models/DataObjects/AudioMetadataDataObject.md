Description
===========
This README describes the properties of `AudioMetadataDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- Represents metadata information related to an audio asset.

## Properties
- `AudioStreams`: [AudioStreamDataObject](AudioStreamDataObject.md)[] - Array of audio streams.
- `Album`: string - The album name.
- `AlbumArtist`: string - The album artist.
- `Artist`: string - The artist.
- `Composers`: string - The composers.
- `Copyright`: string - Copyright.
- `DiscNumber`: int? - The disc number.
- `DiscCount`: int? - The total number of discs.
- `Genre`: string - The genre of the audio.
- `Drm`: bool? - Indicates if the audio has digital rights management.
- `VariableBitrateEncoding`: bool? - Indicates if the audio uses variable bitrate encoding.
- `Title`: string - The title of the audio.
- `TrackNumber:` int? - The track number.
- `TrackCount`: int? - The total number of tracks.
- `Year`: int? - The year the audio was released.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH