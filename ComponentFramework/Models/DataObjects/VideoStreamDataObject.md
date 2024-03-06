Description
===========
This README describes the properties of `VideoStreamDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- Represents metadata information related to a video stream.

## Properties
- `BitRate`: string - The bitrate of the video stream.
- `Codec`: string - The codec used for the video stream.
- `DisplayAspectRatio`: string - The display aspect ratio of the video stream.
- `DurationInSeconds`: decimal? - The duration of the video stream in seconds.
- `Format`: string - The format of the video stream.
- `FrameCount`: int? - The total number of frames in the video stream.
- `FrameRate`: decimal? - The frame rate of the video stream.
- `Width`: decimal? - The width of the video stream in pixels.
- `Height`: decimal? - The height of the video stream in pixels.
- `Language`: string - The language of the video stream.
- `PixelAspectRatio`: decimal? - The pixel aspect ratio of the video stream.
- `Resolution`: int? - The resolution of the video stream.
- `StreamSize`: long? - The size of the video stream.
- `Rotation`: decimal? - The rotation of the video stream.
- `ScanType`: string - The scan type of the video stream.
- `RawData`: [DataObject](DataObject.md)[] - Raw data associated with the video stream.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH