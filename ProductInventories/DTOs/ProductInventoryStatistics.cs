namespace Marketplacesellerportal.ProductInventories.DTOs
{
    public class ProductInventoryStatistics
    {
        public int TotalInventoryRecords { get; set; }

        public decimal TotalQuantity { get; set; }

        public decimal TotalReservedQuantity { get; set; }

        public decimal TotalDamagedQuantity { get; set; }

        public decimal AvailableQuantity { get; set; }

        public int LowStockItems { get; set; }

        public int OutOfStockItems { get; set; }

        public int InStockItems { get; set; }

        public int DamagedItems { get; set; }

        public int ReservedItems { get; set; }
    }
}