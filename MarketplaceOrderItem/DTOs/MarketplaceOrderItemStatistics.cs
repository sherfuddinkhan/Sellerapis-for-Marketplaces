namespace Marketplacesellerportal.MarketplaceOrderItems.DTOs
{
    public class MarketplaceOrderItemStatistics
    {
        public int TotalItems { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalUnitPrice { get; set; }

        public decimal TotalTaxAmount { get; set; }

        public decimal TotalShippingAmount { get; set; }

        public decimal TotalDiscountAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public int DistinctOrders { get; set; }

        public int DistinctProducts { get; set; }

        public int DistinctListings { get; set; }

        public int DistinctSellers { get; set; }

        public int DistinctCustomers { get; set; }

        public int PendingCount { get; set; }

        public int ShippedCount { get; set; }

        public int DeliveredCount { get; set; }

        public int CancelledCount { get; set; }
    }
}
