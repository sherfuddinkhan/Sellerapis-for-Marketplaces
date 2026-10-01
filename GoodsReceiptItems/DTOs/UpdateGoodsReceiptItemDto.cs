namespace Marketplacesellerportal.GoodsReceiptItems.DTOs
{
    public class UpdateGoodsReceiptItemDto
    {
        // Foreign Keys - same as Create
        public int GoodsReceiptNoteId { get; set; }
        public int? PurchaseOrderItemId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public int ProductId { get; set; }
        public int LineNumber { get; set; }

        // Uniware Codes
        public string? SkuCode { get; set; }
        public string? ItemCode { get; set; }
        public string? BatchCode { get; set; }
        public string? VendorBatchNumber { get; set; }
        public string? VendorCode { get; set; }
        public string? ItemDetailCode { get; set; }

        // Quantities
        public decimal ReceivedQuantity { get; set; }
        public decimal AcceptedQuantity { get; set; }
        public decimal RejectedQuantity { get; set; }

        // Prices
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? Mrp { get; set; }
        public decimal? Cost { get; set; }
        public decimal AdditionalCost { get; set; }

        // Dates
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        // Other
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public List<string>? SerialCodes { get; set; }
    }
}
