using System.Collections.Generic;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Parameters
{
    public class InitiateAssetsDownloadForAssetsParameters
    {
        public ICollection<AssetIdentifierParameters> AssetIds { get; set; }

        public ICollection<AssetDownloadItemParameters> AssetDownloadItems { get; set; }

        public bool ImmediatelyDownload { get; set; }
    }
}
