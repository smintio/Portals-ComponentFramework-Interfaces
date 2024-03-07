using System.Collections.Generic;
using SmintIo.PortalsAPI.Frontend.Client.Generated;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Results
{
    public class GetRandomAssetsResult
    {
        public ICollection<DataObject> AssetDataObjects { get; set; }
    }
}
