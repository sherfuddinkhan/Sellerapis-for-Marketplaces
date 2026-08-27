namespace Marketplacesellerportal.SalesOrders.DTOs
{
    public class SalesOrderStatistics
    {
        public int TotalOrders { get; set; }

        public int PendingOrders { get; set; }

        public int ConfirmedOrders { get; set; }

        public int CompletedOrders { get; set; }

        public int CancelledOrders { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal AverageOrderAmount { get; set; }
    }
}
