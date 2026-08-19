namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerPurchaseReturnResponse
    {
        public int PurchaseReturnId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public int? PurchaseOrderId { get; set; }
        public int? ProductId { get; set; }
        public int? SupplierId { get; set; }

        public decimal Quantity { get; set; }

        public string? ReturnReason { get; set; }

        public string? Status { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
