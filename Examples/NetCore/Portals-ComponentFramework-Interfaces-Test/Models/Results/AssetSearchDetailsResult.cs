namespace Portals.ComponentFramework.Interfaces.Test.Models.Results
{
    public class AssetSearchDetailsResult
    {
        public string SearchResultSetId { get; set; }

        public int? CurrentPage { get; set; }

        public int? CurrentItemsPerPage { get; set; }

        public int? MaxPages { get; set; }

        public int? TotalResults { get; set; }

        public bool? HasMoreResults { get; set; }

        public string DataAdapterInstanceKey { get; set; }
    }
}
