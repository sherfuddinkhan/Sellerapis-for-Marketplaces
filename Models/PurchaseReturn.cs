namespace Marketplacesellerportal.Models
{
    public class PurchaseReturn
    {
        public int PurchaseReturnId { get; set; }

        public int PurchaseOrderId { get; set; }
        public int SellerId { get; set; }
       

        public DateTime? UpdatedDate { get; set; }
        public int CustomerId { get; set; }
        public int GoodsReceiptNoteId { get; set; }

        public int SupplierId { get; set; }

        public string PurchaseReturnNumber { get; set; } = string.Empty;

        public DateTime? ReturnDate { get; set; }

        public string? Reason { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
