using System.Collections.Generic;
using SmintIo.PortalsAPI.Frontend.Client.Generated;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Results
{
    public class SearchAssetsResult
    {
        public ICollection<DataObject> AssetDataObjects { get; set; }

        public AssetSearchDetailsResult Details { get; set; }

        public FilterResult FilterModel { get; set; }
    }
}
