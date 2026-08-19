namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerGoodsReceiptNoteResponse
    {
        public int GoodsReceiptNoteId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public int? PurchaseOrderId { get; set; }

        public int? SupplierId { get; set; }

        public int? WarehouseId { get; set; }

        public string? GRNNumber { get; set; }

        public DateTime? ReceiptDate { get; set; }

        public string? Status { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
