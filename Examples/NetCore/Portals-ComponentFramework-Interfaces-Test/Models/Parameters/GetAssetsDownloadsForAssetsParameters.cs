using System.Collections.Generic;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Parameters
{
    public class GetAssetsDownloadsForAssetsParameters
    {
        public ICollection<AssetIdentifierParameters> AssetIds { get; set; }
    }
}
