namespace Marketplacesellerportal.StockMovements.DTOs
{
    public class StockMovementStatistics
    {
        public int TotalMovements { get; set; }

        public int TotalInMovements { get; set; }

        public int TotalOutMovements { get; set; }

        public decimal TotalQuantity { get; set; }

        public decimal TotalInQuantity { get; set; }

        public decimal TotalOutQuantity { get; set; }

        public int TotalSellers { get; set; }

        public int TotalCustomers { get; set; }

        public int TotalProducts { get; set; }

        public int TotalWarehouses { get; set; }
    }
}
