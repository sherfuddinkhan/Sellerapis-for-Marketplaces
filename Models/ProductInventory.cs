using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ProductInventories")]
    public class ProductInventory
    {
        [Key] public int ProductInventoryId { get; set; }
        [Required] public int SellerId { get; set; } = 6;
        [Required] public int CustomerId { get; set; } = 3;
        [Required] public int ProductId { get; set; }
        public int? WarehouseId { get; set; } = 1;
        public int? LocationId { get; set; } = 2;

        public decimal? Quantity { get; set; } = 100;
        public decimal? ReservedQuantity { get; set; } = 5;
        public decimal? DamagedQuantity { get; set; } = 2;
        public decimal? InTransitQuantity { get; set; } = 0;
        public decimal? OpenSaleQuantity { get; set; } = 0;
        public decimal? ReorderLevel { get; set; } = 20;
        public decimal? ReorderQuantity { get; set; } = 50;

        public DateTime? LastStockUpdate { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(100)] public string? SKU { get; set; } = "TN-WBH-001";
        [MaxLength(100)] public string? ItemTypeCode { get; set; } = "WIRELESS_AUDIO";
        [MaxLength(100)] public string? VendorSkuCode { get; set; } = "TN-WBH-001";
        [MaxLength(100)] public string? Barcode { get; set; } = "8901234567890";
        [MaxLength(100)] public string? WarehouseCode { get; set; } = "WH-TN-001";
        [MaxLength(100)] public string? FacilityCode { get; set; } = "WH-TN-001"; // GENERIC ONLY
        [MaxLength(100)] public string? ChannelCode { get; set; } = "CUSTOM"; // GENERIC ONLY
        [MaxLength(100)] public string? LocationCode { get; set; } = "009";
        [MaxLength(200)] public string? LocationName { get; set; } = "Bandlaguda";
        [MaxLength(100)] public string? ShelfCode { get; set; } = "A-01-01";
        [MaxLength(100)] public string? LotNumber { get; set; }
        [MaxLength(100)] public string? BatchId { get; set; }
        public decimal? ChannelPrice { get; set; } = 2499;

        [MaxLength(50)] public string? StockType { get; set; } = "GOOD";
        [MaxLength(50)] public string? InventoryType { get; set; } = "OPEN";
        [MaxLength(50)] public string? InventoryStatus { get; set; } = "ACTIVE";
        [MaxLength(50)] public string? BulkStatus { get; set; } = "READY";
        [MaxLength(50)] public string? AdjustmentType { get; set; }
        public int? AdjustmentQuantity { get; set; }
        public bool? IsBulkUpload { get; set; } = false;

        public string? ProductName { get; set; }
        public bool? IsSyncedToUniware { get; set; } = false;
        public DateTime? LastSyncDate { get; set; } // RENAMED from UniwareSyncDate

        // CALCULATED
        [NotMapped] public decimal QuantityOnHand => Quantity ?? 0;
        [NotMapped] public decimal SellableQuantity => Math.Max(0, (Quantity ?? 0) - (ReservedQuantity ?? 0) - (DamagedQuantity ?? 0));
        [NotMapped] public bool IsLowStock => SellableQuantity <= (ReorderLevel ?? 20);
        [NotMapped] public bool NeedsReorder => IsLowStock;
        [NotMapped] public decimal ChannelInventory => SellableQuantity;
        [NotMapped] public bool IsWarehouseActive => Warehouse?.IsActive ?? false;
        [NotMapped] public decimal Inventory => Quantity ?? 0;

        [Timestamp] public byte[]? RowVersion { get; set; }

        [ForeignKey(nameof(ProductId))] public Product? Product { get; set; }
        [ForeignKey(nameof(WarehouseId))] public Warehouse? Warehouse { get; set; }
    }
}