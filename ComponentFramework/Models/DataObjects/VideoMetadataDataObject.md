Description
===========
This README describes the properties of `VideoMetadataDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- Represents metadata information related to a video asset.

## Properties
- `Width`: int? - The width of the video in pixels.
- `Height`: int? - The height of the video in pixels.
- `DurationInSeconds`: decimal? - The duration of the video in seconds.
- `Format`: string - The format of the video.
- `Codec`: string - The codec used for the video.
- `OverallBitrate`: int? - The overall bitrate of the video.
- `VideoStreams`: [VideoStreamDataObject](VideoStreamDataObject.md)[] - Array of video streams.
- `AudioStreams`: [AudioStreamDataObject](AudioStreamDataObject.md)[] - Array of audio streams.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH