namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerPurchaseOrderItemResponse
    {
        public int PurchaseOrderItemId { get; set; }

        public int PurchaseOrderId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }
        public decimal? TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }
   
        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
