namespace Marketplacesellerportal.PurchaseOrderItems.DTOs
{
    public class PurchaseOrderItemStatistics
    {
        public int TotalItems { get; set; }

        public int DistinctPurchaseOrders { get; set; }

        public int DistinctProducts { get; set; }

        public int DistinctSellers { get; set; }
      
        public decimal TotalQuantity { get; set; }

        public decimal TotalAmount { get; set; }
        public int DistinctSuppliers { get; set; }

        public decimal AverageAmount { get; set; }

        public decimal AverageQuantity { get; set; }
    }
}
