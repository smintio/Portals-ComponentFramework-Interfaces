using System.Collections.Generic;
using SmintIo.PortalsAPI.Frontend.Client.Generated;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Results
{
    public class GetAssetsResult
    {
        public ICollection<DataObject> AssetDataObjects { get; set; }
    }
}
