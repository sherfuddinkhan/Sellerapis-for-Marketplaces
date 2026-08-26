namespace Marketplacesellerportal.Warehouses.DTOs
{
    public class WarehouseStatistics
    {
        public int TotalRecords { get; set; }

        public int ActiveWarehouses { get; set; }

        public int InactiveWarehouses { get; set; }

        public int DistinctSellers { get; set; }

        public int DistinctCustomers { get; set; }

        public int DistinctCities { get; set; }

        public int DistinctStates { get; set; }
    }
}
