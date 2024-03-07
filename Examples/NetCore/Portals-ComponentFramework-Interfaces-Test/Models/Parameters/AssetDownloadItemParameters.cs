using System.Collections.Generic;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Parameters
{
    public class AssetDownloadItemParameters
    {
        public string GroupId { get; set; }

        public string ItemId { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }

        public int FileSizeInBytes { get; set; }

        public bool SelectedByDefault { get; set; }

        public bool MaxAssetCountExceeded { get; set; }

        public ICollection<string> AssetIds { get; set; }
    }
}
