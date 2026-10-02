using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("PurchaseOrders")]
    public class PurchaseOrder
    {
        [Key] public int PurchaseOrderId { get; set; }
        public int SellerId { get; set; }
        public int SupplierId { get; set; }
        public int CustomerId { get; set; }
        public int? WarehouseId { get; set; }

        [Required][MaxLength(200)] public string PurchaseOrderNumber { get; set; } = null!;
        [MaxLength(100)] public string? PurchaseOrderCode { get; set; }
        [MaxLength(100)] public string? VendorCode { get; set; }
        [MaxLength(200)] public string? VendorName { get; set; }
        [MaxLength(100)] public string? FacilityCode { get; set; } = "WH-TN-001";
        [MaxLength(20)] public string? Type { get; set; } = "CART";
        [MaxLength(50)] public string? Status { get; set; } = "CREATED";
        [MaxLength(100)] public string? StatusCode { get; set; }
        [MaxLength(100)] public string? VendorAgreementName { get; set; }
        [MaxLength(100)] public string? ChannelCode { get; set; } = "CUSTOM";
        [MaxLength(100)] public string? BatchId { get; set; }

        public DateTime? OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        [Column(TypeName = "decimal(18,2)")] public decimal? TotalAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? SubTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? TaxAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? DiscountAmount { get; set; }
        [MaxLength(10)] public string? CurrencyCode { get; set; } = "INR";

        public int? TotalItems { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? TotalQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? ReceivedQuantity { get; set; } = 0; // <-- YOU MISSED - ADD THIS
        public int? InflowReceiptsCount { get; set; }

        [MaxLength(100)] public string? VendorInvoiceNumber { get; set; }
        public DateTime? VendorInvoiceDate { get; set; }
        [MaxLength(1000)] public string? ShippingAddress { get; set; }
        [MaxLength(50)] public string? StateCode { get; set; } = "36";
        [MaxLength(20)] public string? CountryCode { get; set; } = "IN";
        [MaxLength(1000)] public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(100)] public string? CreatedBy { get; set; } = "System";
        [MaxLength(100)] public string? UpdatedBy { get; set; }
        [Timestamp] public byte[]? RowVersion { get; set; }

        // NOTMAPPED - ONLY FOR MISSING PROPERTIES, NO DUPLICATES
        [NotMapped] public string? POStatus => Status;
        [NotMapped] public string? ApprovalStatus => Status == "APPROVED" ? "APPROVED" : "PENDING";
        [NotMapped] public DateTime? ReceiptDate => ExpectedDeliveryDate;
        [NotMapped] public decimal? PendingQuantity => (TotalQuantity ?? 0) - (ReceivedQuantity ?? 0);
        [NotMapped] public string? DisplayVendorName => Supplier?.SupplierName ?? VendorName; // Renamed to avoid duplicate
        [NotMapped] public string? DisplayVendorCode => Supplier?.SupplierCode ?? VendorCode; // Renamed
        [NotMapped] public string? DisplayPurchaseOrderNumber => PurchaseOrderCode ?? PurchaseOrderNumber ?? $"PO-{PurchaseOrderId}";

        // NAVIGATION
        [ForeignKey(nameof(SupplierId))] public virtual Supplier? Supplier { get; set; }
        [ForeignKey(nameof(WarehouseId))] public virtual Warehouse? Warehouse { get; set; }
        public virtual ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
        public virtual ICollection<GoodsReceiptNote> GoodsReceiptNotes { get; set; } = new List<GoodsReceiptNote>();
    }
}