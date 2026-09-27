using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("GoodsReceiptNotes")]
    public class GoodsReceiptNote
    {
        [Key] public int GoodsReceiptNoteId { get; set; }

        [Required] public int PurchaseOrderId { get; set; }
        [Required] public int SellerId { get; set; } = 6;
        [Required] public int CustomerId { get; set; } = 3;
        public int? SupplierId { get; set; }
        public int? WarehouseId { get; set; }

        // GRN Core
        [Required][MaxLength(200)] public string GRNNumber { get; set; } = null!;
        [MaxLength(100)] public string? GrnCode { get; set; }
        [MaxLength(50)] public string? Status { get; set; } = "RECEIVED";
        [MaxLength(1000)] public string? Remarks { get; set; }
        public DateTime? ReceiptDate { get; set; } = DateTime.UtcNow;

        // Uniware - 15 APIs
        [MaxLength(100)] public string? FacilityCode { get; set; } = "WH-TN-001";
        [MaxLength(100)] public string? UniwareFacilityCode { get; set; }
        [MaxLength(100)] public string? VendorCode { get; set; } = "SUP-TN-001";
        [MaxLength(100)] public string? VendorInvoiceNumber { get; set; }
        public DateTime? VendorInvoiceDate { get; set; } = DateTime.UtcNow;
        [MaxLength(100)] public string? InflowReceiptCode { get; set; }
        [MaxLength(50)] public string? GrnType { get; set; } = "REGULAR";
        [MaxLength(50)] public string? QcStatus { get; set; } = "PENDING";
        [MaxLength(50)] public string? PutawayStatus { get; set; } = "PENDING";
        [MaxLength(100)] public string? ChannelCode { get; set; } = "CUSTOM";
        [MaxLength(100)] public string? PurchaseOrderCode { get; set; }
        [MaxLength(100)] public string? BatchId { get; set; }
        public bool? IsBulkUpload { get; set; } = false;
        [MaxLength(50)] public string? BulkUploadStatus { get; set; }

        // Financial
        [Column(TypeName = "decimal(18,2)")] public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? SubTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? TaxAmount { get; set; }
        [MaxLength(10)] public string? CurrencyCode { get; set; } = "INR";

        // Quantity
        [Column(TypeName = "decimal(18,2)")] public decimal TotalQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal ReceivedQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal RejectedQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? AcceptedQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? PendingQuantity { get; set; }

        // Audit
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(100)] public string? CreatedBy { get; set; } = "System";
        [MaxLength(100)] public string? UpdatedBy { get; set; }
        [Timestamp] public byte[]? RowVersion { get; set; }

        // Navigation
        [ForeignKey(nameof(PurchaseOrderId))] public PurchaseOrder? PurchaseOrder { get; set; }
        [ForeignKey(nameof(WarehouseId))] public Warehouse? Warehouse { get; set; }
        [ForeignKey(nameof(SupplierId))] public Supplier? Supplier { get; set; }
        public ICollection<GoodsReceiptItem>? GoodsReceiptItems { get; set; } = new List<GoodsReceiptItem>();

        // ================= NOTMAPPED - SINGLE DEFINITION ONLY =================
        [NotMapped] public decimal PendingQCQuantity => ReceivedQuantity - (AcceptedQuantity ?? ReceivedQuantity) - RejectedQuantity;
        [NotMapped] public bool IsFacilityCodeMatch => string.Equals(FacilityCode, UniwareFacilityCode, StringComparison.OrdinalIgnoreCase);
        [NotMapped] public bool IsQCPending => QcStatus == "PENDING";
        [NotMapped] public bool IsPutawayPending => PutawayStatus == "PENDING";

        // Aliases for DTO mapping - ONE each
        [NotMapped] public string? PurchaseOrderNumber => PurchaseOrderCode ?? $"PO-{PurchaseOrderId}";
        [NotMapped] public string? GRNStatus => Status;
        [NotMapped] public string? WarehouseCode => Warehouse?.WarehouseCode ?? FacilityCode;
        [NotMapped] public string? LocationCode => FacilityCode; // Warehouse.LocationCode doesn't exist
        [NotMapped] public string? VendorName => Supplier?.SupplierName ?? VendorCode;

        // Use bool? to match your DTO which is bool?
        [NotMapped] public bool? IsQCRequired => QcStatus != null;
        [NotMapped] public bool? IsQCDone => QcStatus == "PASSED" || QcStatus == "FAILED";
    }
}