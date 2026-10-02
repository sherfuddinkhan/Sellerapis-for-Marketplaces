namespace Marketplacesellerportal.GoodsReceiptItems.DTOs
{
    public class CreateGoodsReceiptItemDto
    {
        public int GoodsReceiptNoteId { get; set; }
        public int PurchaseOrderItemId { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
        public int LineNumber { get; set; }

        // Uniware mandatory
        public string SkuCode { get; set; } = "TN-WBH-001";
        public string? BatchCode { get; set; } = "BATCH-0928-A";
        public string? VendorCode { get; set; } = "SUP-TN-001";
        public string? VendorBatchNumber { get; set; }

        public decimal ReceivedQuantity { get; set; }
        public decimal AcceptedQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Mrp { get; set; }
        public decimal? Cost { get; set; }

        // For IMEI / Serial tracking - replaces GrnItemDTOs table
        public List<string>? SerialCodes { get; set; }

        public string? Remarks { get; set; }

        // =========================================================
        // ADDED MISSING FIELDS - WITHOUT DELETING YOURS
        // =========================================================
        public string? ItemCode { get; set; }
        public string? FacilityCode { get; set; }
        public string? ChannelCode { get; set; }
        public string? BinCode { get; set; }
        public string? ShelfCode { get; set; }
        public string? UniwareSyncStatus { get; set; }
        public decimal RejectedQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AdditionalCost { get; set; }
        public string? ItemDetailCode { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Status { get; set; } = "Accepted";
        public string? SerialCodesJson { get; set; }
    }
}