namespace Marketplacesellerportal.SalesOrderItems.DTOs
{
    public class SalesOrderItemStatistics
    {
        public int TotalItems { get; set; }
        public int DistinctSalesOrders { get; set; }
        public int DistinctProducts { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal AverageUnitPrice { get; set; }
    }
}


