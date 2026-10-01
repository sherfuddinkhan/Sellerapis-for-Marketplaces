namespace Marketplacesellerportal.GoodsReceiptItems.DTOs
{
    public class GoodsReceiptItemDto
    {
        public int GoodsReceiptItemId { get; set; }
        public int GoodsReceiptNoteId { get; set; }
        public int? PurchaseOrderItemId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public int ProductId { get; set; }
        public int LineNumber { get; set; }

        // SKU / Batch / Vendor
        public string? SkuCode { get; set; }
        public string? ItemCode { get; set; }
        public string? BatchCode { get; set; }
        public string? VendorBatchNumber { get; set; }
        public string? VendorCode { get; set; }

        // ===== ADD THESE 8 MISSING COLUMNS =====
        public string? FacilityCode { get; set; }
        public string? UniwareFacilityCode { get; set; }
        public string? ChannelCode { get; set; }
        public string? UniwareItemCode { get; set; }
        public string? UniwareVendorCode { get; set; }
        public string? BinCode { get; set; }
        public string? ShelfCode { get; set; }
        public string? UniwareSyncStatus { get; set; }

        public decimal ReceivedQuantity { get; set; }
        public decimal AcceptedQuantity { get; set; }
        public decimal RejectedQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? Mrp { get; set; }
        public decimal? Cost { get; set; }
        public decimal AdditionalCost { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? ItemDetailCode { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public List<string>? SerialCodes { get; set; }
        public string? SerialCodesJson { get; set; }
    }
}