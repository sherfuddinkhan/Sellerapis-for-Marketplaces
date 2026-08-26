namespace Marketplacesellerportal.StockLedgers.DTOs
{
    public class StockLedgerFilters
    {
        public IEnumerable<string> TransactionTypes { get; set; }
            = new List<string>();

        public IEnumerable<int> SellerIds { get; set; }
            = new List<int>();

        public IEnumerable<int> CustomerIds { get; set; }
            = new List<int>();

        public IEnumerable<int> ProductIds { get; set; }
            = new List<int>();

        public IEnumerable<int> WarehouseIds { get; set; }
            = new List<int>();
    }
}


