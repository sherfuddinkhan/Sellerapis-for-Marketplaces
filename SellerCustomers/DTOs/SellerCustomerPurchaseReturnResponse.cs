namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerPurchaseReturnResponse
    {
        public int PurchaseReturnId { get; set; }

        // Seller / Customer
        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        // References
        public int? PurchaseOrderId { get; set; }
        public int? GoodsReceiptNoteId { get; set; }
        public int? SupplierId { get; set; }

        // Return identification
        public string? PurchaseReturnNumber { get; set; }

        // Return financial information
        public decimal TotalAmount { get; set; }

        // Return information
        public string? ReturnReason { get; set; }
        public string? Status { get; set; }
        public DateTime? ReturnDate { get; set; }

        // Audit
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}