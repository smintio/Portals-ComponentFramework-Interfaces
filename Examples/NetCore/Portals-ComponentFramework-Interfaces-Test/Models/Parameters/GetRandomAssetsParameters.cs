namespace Portals.ComponentFramework.Interfaces.Test.Models.Parameters
{
    public class GetRandomAssetsParameters
    {
        public int ContentType { get; set; }

        public int ResourceAssetMode { get; set; }

        public string AssetCategory { get; set; }

        public int Max { get; set; } = 1;
    }
}
