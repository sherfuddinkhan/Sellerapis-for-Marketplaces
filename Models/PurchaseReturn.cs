namespace Marketplacesellerportal.Models
{
    public class PurchaseReturn
    {
        // Primary Key
        public int PurchaseReturnId { get; set; }

        // References
        public int PurchaseOrderId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int GoodsReceiptNoteId { get; set; }
        public int SupplierId { get; set; }

        // Return Identification
        public string PurchaseReturnNumber { get; set; } = string.Empty;

        // Return Details
        public DateTime? ReturnDate { get; set; }
        public string? Reason { get; set; }

        // Financial Information
        public decimal? TotalAmount { get; set; }

        // Status
        public string? Status { get; set; }

        // Audit
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}