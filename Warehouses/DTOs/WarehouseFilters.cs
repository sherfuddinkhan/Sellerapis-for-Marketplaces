namespace Marketplacesellerportal.Warehouses.DTOs
{
    public class WarehouseFilters
    {
        public IEnumerable<int> SellerIds { get; set; }
            = new List<int>();

        public IEnumerable<int> CustomerIds { get; set; }
            = new List<int>();

        public IEnumerable<string> Cities { get; set; }
            = new List<string>();

        public IEnumerable<string> States { get; set; }
            = new List<string>();

        public IEnumerable<string> Countries { get; set; }
            = new List<string>();

        public IEnumerable<string> Statuses { get; set; }
            = new List<string>();
    }
}
