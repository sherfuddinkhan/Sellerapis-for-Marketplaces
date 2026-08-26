namespace Marketplacesellerportal.Models
{
    public class SalesOrderItem
    {
        public int SalesOrderItemId { get; set; }

        public int SalesOrderId { get; set; }

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }


        // =====================================================
        // NAVIGATION PROPERTIES
        // These do NOT create new columns by themselves
        // =====================================================

        public SalesOrder? SalesOrder { get; set; }

        public Product? Product { get; set; }
    }
}

