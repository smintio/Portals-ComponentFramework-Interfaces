using System.Collections.Generic;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Results
{
    public class GetAssetsDownloadsResult
    {
        public ICollection<AssetDownloadGroupResult> AssetDownloadGroups { get; set; }
    }
}
