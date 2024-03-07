namespace Portals.ComponentFramework.Interfaces.Test.Models
{
    public class ComponentFrameworkOptions
    {
        public const string Name = "App";

        public string PortalUrl { get; set; }

        public string PortalUuid { get; set; }

        public string SearchPortalComponentUuid { get; set; }

        public string RandomSearchPortalComponentUuid { get; set; }

        public string RandomSearchComponentConfigurationUuid { get; set; }

        public string ImageAssetId { get; set; }

        public string VideoAssetId { get; set; }

        public string DocumentAssetId { get; set; }

        public string SearchFilterId { get; set; }

        public string SearchFilterValue { get; set; }
    }
}
