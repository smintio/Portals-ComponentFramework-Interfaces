Description
===========
This README describes the properties of `AssetDataObject`.

Current version of this document is: 1.0.0 (as of 5th of March, 2024)

- An object representing an asset and its metadata.

## Properties

- `Name`: [LocalizedStringsModel](..//Common/LocalizedStringsModel.md) - The name of the asset.
- `Description`: [LocalizedStringsModel](../Common/LocalizedStringsArrayModel.md) - The description of the asset.
- `ContentType`: [ContentTypeEnumDataObject](ContentTypeEnumDataObject.md) - The type of content the asset represents.
- `CompositeAssetType`: [CompositeAssetTypeEnumDataObject](CompositeAssetTypeEnumDataObject.md) - The type of composite asset.
- `AssetCategories`: [AssetCategoryEnumDataObject](AssetCategoryEnumDataObject.md) - The categories the asset belongs to.
- `FileMetadata`: [FileMetadataDataObject](FileMetadataDataObject.md) - Metadata associated with the file.
- `ImageMetadata`: [ImageMetadataDataObject](ImageMetadataDataObject.md) - Metadata associated with an image asset.
- `AudioMetadata`: [AudioMetadataDataObject](AudioMetadataDataObject.md) - Metadata associated with an audio asset.
- `VideoMetadata`: [VideoMetadataDataObject](VideoMetadataDataObject.md) - Metadata associated with a video asset.
- `DocumentMetadata`: [DocumentMetadataDataObject](DocumentMetadataDataObject.md) - Metadata associated with a document asset.
- `VectorMetadata`: [VectorMetadataDataObject](VectorMetadataDataObject.md) - Metadata associated with a vector asset.
- `PressReleaseMetadata`: [CompositeAssetPressReleaseMetadataDataObject](CompositeAssetPressReleaseMetadataDataObject.md) - Metadata associated with a composite asset press release.
- `LargeThumbnailUrl`: string - URL to a large thumbnail of the asset.
- `MediumThumbnailUrl`: string - URL to a medium-sized thumbnail of the asset.
- `SmallThumbnailUrl`: string - URL to a small thumbnail of the asset.
- `PreviewThumbnailUrl`: string - URL to a preview thumbnail of the asset.
- `PlaybackLargeUrl`: string - URL for large playback of the asset.
- `PlaybackSmallUrl`: string - URL for small playback of the asset.
- `PlaybackStreamingUrl`: string - URL for streaming playback of the asset.
- `PdfPreviewUrl`: string - URL for previewing a PDF version of the asset.
- `Indicator`: [IndicatorDataObject](IndicatorDataObject.md) - Indicator associated with the asset.
- `ThumbnailAspectRatio`: decimal? - Aspect ratio of the thumbnail.
- `ThumbnailAlignment`: [AlignmentEnumDataObject](AlignmentEnumDataObject.md) - Alignment of the thumbnail.
- `IsThumbnailLargeAvailable`: bool? - Indicates if a large thumbnail is available.
- `IsThumbnailMediumAvailable`: bool? - Indicates if a medium-sized thumbnail is available.
- `IsThumbnailSmallAvailable`: bool? - Indicates if a small thumbnail is available.
- `IsThumbnailPreviewAvailable`: bool? - Indicates if a preview thumbnail is available.
- `IsPlaybackLargeAvailable`: bool? - Indicates if large playback is available.
- `IsPlaybackSmallAvailable`: bool? - Indicates if small playback is available.
- `IsPlaybackStreamingAvailable`: bool? - Indicates if streaming playback is available.
- `PlaybackStreamingMediaType`: string - Media type for streaming playback.
- `IsPdfPreviewAvailable`: bool? - Indicates if a PDF preview is available.
- `LocalizedTags`: [LocalizedStringsArrayModel](../Common/LocalizedStringsArrayModel.md) - Localized tags associated with the asset.
- `Version`: string - Version of the asset.
- `RawData`: [DataObject](DataObject.md)[] - Raw data associated with the asset.
- `RawDataHierarchy`: [HierarchyEntryDataObject[]](HierarchyEntryDataObject.md) - Hierarchy entry data associated with the asset.
- `PermissionUuids`: string[] - UUIDs associated with permissions for the asset.
- `ParentFolderIds`: string[] - IDs of parent folders containing the asset.
- `RelatedAssets`: [RelatedAssetsDataObject](RelatedAssetsDataObject.md)[] - Related assets associated with the asset.
- `CreatedAt`: DateTimeOffset? - Date and time the asset was created.
- `ModifiedAt`: DateTimeOffset? - Date and time the asset was last modified.
- `CreatedBy`: string - Creator of the asset.
- `ModifiedBy`: string - Last modifier of the asset.
- `ETag`: string - ETag associated with the asset.
- `MetadataLayers`: [EnumDataObject](EnumDataObject.md)[] - Metadata layers associated with the asset.
- `Flag`: [FlagEnumDataObject](FlagEnumDataObject.md) - Flag associated with the asset.
- `TotalCommentCount`: int? - Total count of comments associated with the asset.
- `PathForUrl`: [LocalizedStringsModel](../Common/LocalizedStringsModel.md) - Path for the URL of the asset.
- `PublishFrom`: DateTimeOffset? - Date and time from which the asset is published.
- `PublishUntil`: DateTimeOffset? - Date and time until which the asset is published.
- `ExternalId`: string - External ID associated with the asset.

Contributors
============

- Reinhard Holzner, Smint.io GmbH
- Yosif Velev, Smint.io GmbH