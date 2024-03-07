using System.Collections.Generic;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Results
{
    public class AssetDownloadGroupResult
    {
        public string GroupId { get; set; }

        public string GroupName { get; set; }

        public ICollection<AssetDownloadItemResult> AssetDownloadItems { get; set; }
    }
}
