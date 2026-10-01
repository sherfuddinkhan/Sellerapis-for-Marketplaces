using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class GoodsReceiptItem
    {
        [Key]
        public int GoodsReceiptItemId { get; set; }

        // REFERENCES
        public int GoodsReceiptNoteId { get; set; }
        public int PurchaseOrderItemId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }

        // LINE INFORMATION
        public int LineNumber { get; set; }

        // QUANTITY
        public decimal ReceivedQuantity { get; set; } = 0;
        public decimal AcceptedQuantity { get; set; } = 0;
        public decimal RejectedQuantity { get; set; } = 0;

        // PRICE / AMOUNT
        public decimal UnitPrice { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;

        // =========================================================
        // UNIWARE MANDATORY FIELDS - ALL COMPATIBLE
        // =========================================================

        [MaxLength(50)]
        public string? SkuCode { get; set; } = "TN-WBH-001";

        [MaxLength(50)]
        public string? ItemCode { get; set; } = "TN-WBH-001";

        [MaxLength(100)]
        public string? UniwareItemCode { get; set; } = "TN-WBH-001";

        [MaxLength(50)]
        public string? BatchCode { get; set; } = "BATCH-0928-A";

        [MaxLength(50)]
        public string? VendorBatchNumber { get; set; } = "VB-001";

        [MaxLength(50)]
        public string? VendorCode { get; set; } = "SUP-TN-001";

        [MaxLength(50)]
        public string? UniwareVendorCode { get; set; } = "SUP-TN-001";

        // Facility / Channel - Uniware needs this
        [MaxLength(50)]
        public string? FacilityCode { get; set; } = "TN-WH-01";

        [MaxLength(50)]
        public string? UniwareFacilityCode { get; set; } = "TN-WH-01";

        [MaxLength(50)]
        public string? ChannelCode { get; set; } = "CUSTOM";

        [MaxLength(50)]
        public string? ShelfCode { get; set; }

        [MaxLength(50)]
        public string? BinCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Mrp { get; set; } = 120;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Cost { get; set; } = 90;

        [Column(TypeName = "decimal(18,2)")]
        public decimal AdditionalCost { get; set; } = 0;

        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? SerialCodesJson { get; set; }

        [MaxLength(100)]
        public string? ItemDetailCode { get; set; } = "DETAIL-001";

        [MaxLength(50)]
        public string? UniwareSyncStatus { get; set; } = "Pending";

        // STATUS
        [MaxLength(100)]
        public string? Status { get; set; } = "Accepted";

        [MaxLength(1000)]
        public string? Remarks { get; set; }

        // NAVIGATION
        [ForeignKey(nameof(GoodsReceiptNoteId))]
        public GoodsReceiptNote? GoodsReceiptNote { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
    }
}