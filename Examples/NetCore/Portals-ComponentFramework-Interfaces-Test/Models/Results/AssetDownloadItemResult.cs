using System.Collections.Generic;
using Portals.ComponentFramework.Interfaces.Test.Models.Parameters;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Results
{
    public class AssetDownloadItemResult
    {
        public string GroupId { get; set; }

        public string ItemId { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }

        public int FileSizeInBytes { get; set; }

        public bool SelectedByDefault { get; set; }

        public bool MaxAssetCountExceeded { get; set; }

        public ICollection<string> AssetIds { get; set; }

        public AssetDownloadItemParameters ToAssetDownloadItemParameters()
            => new()
            {
                GroupId = GroupId,
                ItemId = ItemId,
                Description = Description,
                Count = Count,
                FileSizeInBytes = FileSizeInBytes,
                SelectedByDefault = SelectedByDefault,
                MaxAssetCountExceeded = MaxAssetCountExceeded,
                AssetIds = AssetIds
            };
    }
}
