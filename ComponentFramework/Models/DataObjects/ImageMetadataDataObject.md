Description
===========
This README describes the properties of `ImageMetadataDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- Represents metadata associated with an image.

## Properties
- `Width`: int? - The width of the image in pixels.
- `Height`: int? - The height of the image in pixels.
- `WidthInInch`: decimal? - The width of the image in inches.
- `HeightInInch`: decimal? - The height of the image in inches.
- `WidthInCm`: decimal? - The width of the image in centimeters.
- `HeightInCm`: decimal? - The height of the image in centimeters.
- `ColorSpace`: string - The color space of the image.
- `ColorProfile`: string - The color profile of the image.
- `BitsPerPixel`: int? - The number of bits per pixel.
- `BitsPerChannel`: int? - The number of bits per color channel.
- `Channels`: string - The channels of the image.
- `PixelFormat`: string - The pixel format of the image.
- `HasAlpha`: bool? - Indicates if the image has an alpha channel.
- `IsIndexed`: bool? - Indicates if the image is indexed.
- `IsExtended`: bool? - Indicates if the image is extended.
- `HorizontalResolution`: decimal? - The horizontal resolution of the image.
- `VerticalResolution`: decimal? - The vertical resolution of the image.
- `Resolution`: int? - The resolution of the image.
- `TotalFrames`: int? - The total number of frames in the image.
- `TotalUnspecifiedTiffExtraChannels`: int? - The total number of unspecified TIFF extra channels in the image.
- `HasExifData`: bool? - Indicates if the image has Exif data.
- `HasIptcData`: bool? - Indicates if the image has IPTC data.
- `HasAdobeResourceData`: bool? - Indicates if the image has Adobe resource data.
- `HasXmpData`: bool? - Indicates if the image has XMP data.
- `UncompressedSizeInBytes`: long? - The uncompressed size of the image in bytes.
- `CameraMake`: string - The make of the camera used to capture the image.
- `CameraModel`: string - The model of the camera used to capture the image.
- `ExposureDenominator`: decimal? - The exposure denominator of the image.
- `ExposureNumerator`: decimal? - The exposure numerator of the image.
- `FNumber`: decimal? - The F number of the image.
- `FocalLength`: decimal? - The focal length of the image.
- `Iso`: int? - The ISO value of the image.
- `Orientation`: int? - The orientation of the image.
- `CaptureDate`: DateTimeOffset? - The capture date of the image.
- `Quality`: decimal? - The quality of the image.
- `DominantColor`: string - The dominant color of the image.
- `Transparency`: bool? - Indicates if the image has transparency.
- `Aperture`: decimal? - The aperture value of the image.
- `MaxAperture`: decimal? - The maximum aperture value of the image.
- `MeteringMode`: string - The metering mode of the image.
- `ExposureBias`: int? - The exposure bias of the image.
- `ExposureMode`: string - The exposure mode of the image.
- `ExposureTime`: decimal? - The exposure time of the image.
- `FlashUsed`: bool? - Indicates if flash was used while capturing the image.
- `Lens`: string - The lens used to capture the image.
- `WhiteBalance`: string - The white balance of the image.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH