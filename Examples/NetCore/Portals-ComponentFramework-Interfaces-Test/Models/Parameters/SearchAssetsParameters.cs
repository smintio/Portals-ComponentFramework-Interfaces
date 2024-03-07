namespace Portals.ComponentFramework.Interfaces.Test.Models.Parameters
{
    public class SearchAssetsParameters
    {
        public CurrentFiltersParameters CurrentFilters { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int ResourceAssetMode { get; set; }
    }
}
