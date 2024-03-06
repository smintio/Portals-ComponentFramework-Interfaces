Description
===========
This README describes the properties of `AudioStreamDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- Represents metadata information related to an audio stream.

## Properties
- `BitRate`: string - The bitrate of the audio stream.
- `BitRateMode`: string - The bitrate mode of the audio stream.
- `Channels`: string - The channels of the audio stream.
- `ChannelPositions`: string - The channel positions of the audio stream.
- `Codec`: string - The codec used for the audio stream.
- `DurationInSeconds`: decimal? - The duration of the audio stream in seconds.
- `Format`: string - The format of the audio stream.
- `Language`: string - The language of the audio stream.
- `Resolution`: int? - The resolution of the audio stream.
- `SamplingRate`: int? - The sampling rate of the audio stream.
- `StreamSize`: long? - The size of the audio stream.
- `RawData`: [DataObject](DataObject.md)[] - Raw data associated with the audio stream.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH