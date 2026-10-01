using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Products")]
    public class Product
    {
        // ============================================================
        // PRIMARY KEY
        // ============================================================
        [Key] public int ProductId { get; set; }

        // ============================================================
        // SELLER / CUSTOMER
        // ============================================================
        [Required] public int SellerId { get; set; }
        [Required] public int CustomerId { get; set; }

        // ============================================================
        // BASIC PRODUCT INFORMATION - ALL NULL-SAFE
        // ============================================================
        [MaxLength(250)] public string? ProductName { get; set; }
        [MaxLength(100)] public string? SKU { get; set; }
        [MaxLength(100)] public string? Barcode { get; set; }
        [MaxLength(2000)] public string? Description { get; set; }

        public string? ScanIdentifier { get; set; }

        [NotMapped] public string? BrandName { get; set; }
        public int? MinOrderSize { get; set; }
        public string? Features { get; set; }
        public string? ProductPageUrl { get; set; }

        // === Uniware Product Codes ===
        [MaxLength(100)] public string? ProductCode { get; set; }
        [MaxLength(100)] public string? UniwareItemCode { get; set; }
        [MaxLength(100)] public string? UniwareProductCode { get; set; }
        [MaxLength(50)] public string? ItemType { get; set; } = "STANDARD";
        public int? ProductXID { get; set; }
        public decimal? CostPrice { get; set; }
      
        public decimal? GSTPercentage { get; set; } = 18;
        public bool? IsReturnable { get; set; } = true;
        public bool? IsCancellable { get; set; } = true;
        public bool? IsCodAvailable { get; set; } = true;
        public int? ShelfLifeDays { get; set; }
        [MaxLength(100)] public string? WarrantyPeriod { get; set; }
        public bool? IsSyncedToUniware { get; set; } = false;

        // ============================================================
        // PRODUCT CLASSIFICATION
        // ============================================================
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductTypeId { get; set; }

        // ============================================================
        // UNIWARE ITEM TYPE CORE
        // ============================================================
        [MaxLength(100)] public string? ItemTypeCode { get; set; }
        [MaxLength(100)] public string? ItemTypeName { get; set; }
        [MaxLength(100)] public string? ProductGroupCode { get; set; }
        [MaxLength(100)] public string? BrandCode { get; set; }
        [MaxLength(100)] public string? ProductDetailFieldColor { get; set; }
        [MaxLength(100)] public string? ProductDetailFieldSize { get; set; }
        [MaxLength(100)] public string? ProductDetailFieldMaterial { get; set; }
        public string? ProductDetailFieldsJson { get; set; }
        [MaxLength(20)] public string? DimUnit { get; set; } = "CM";
        [MaxLength(20)] public string? WeightUnit { get; set; } = "KG";
        public int? ShelfLife { get; set; }
        [MaxLength(20)] public string? ShelfLifeType { get; set; } = "DAYS";
        [MaxLength(20)] public string? ItemTypeStatus { get; set; } = "ACTIVE";

        // ============================================================
        // PHYSICAL DIMENSIONS
        // ============================================================
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }

        // ============================================================
        // PRODUCT / TAX INFORMATION
        // ============================================================
        [MaxLength(20)] public string? HSNCode { get; set; }
        [MaxLength(50)] public string? UnitOfMeasure { get; set; }
        [Column("uom")][MaxLength(20)] public string? Uom { get; set; }
        [MaxLength(50)] public string? Status { get; set; }
        public bool? IsActive { get; set; }
        [MaxLength(50)] public string? TaxCategory { get; set; }
        [MaxLength(50)] public string? TaxTypeCode { get; set; } = "GST";
        public decimal? TaxPercentage { get; set; } = 18;

        // ============================================================
        // AMOUNT / TAX CALCULATION FIELDS
        // ============================================================
        [Column("quantityAmount")] public decimal? QuantityAmount { get; set; }
        [Column("totalAmount")] public decimal? TotalAmount { get; set; }
        [Column("gstPer")] public decimal? GstPer { get; set; }
        [Column("sgstPer")] public decimal? SgstPer { get; set; }
        [Column("sgstAmount")] public decimal? SgstAmount { get; set; }
        [Column("cgstPer")] public decimal? CgstPer { get; set; }
        [Column("cgstAmount")] public decimal? CgstAmount { get; set; }
        [Column("igstPer")] public decimal? IgstPer { get; set; }
        [Column("igstAmount")] public decimal? IgstAmount { get; set; }
        [Column("afterGSTAmount")] public decimal? AfterGSTAmount { get; set; }
        [Column("taxType")][MaxLength(20)] public string? TaxType { get; set; }
        [Column("exciseDutyTotalInWords")][MaxLength(500)] public string? ExciseDutyTotalInWords { get; set; }

        // ============================================================
        // MRP / SELLING PRICE
        // ============================================================
        [Column(TypeName = "decimal(18,2)")] public decimal? Mrp { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? SellingPrice { get; set; }
        [MaxLength(10)] public string? CurrencyCode { get; set; } = "INR";

        // ============================================================
        // MANUFACTURING / EXPIRY
        // ============================================================
        [Column("mfgDate")] public DateTime? MfgDate { get; set; }
        [Column("expDate")] public DateTime? ExpDate { get; set; }

        // ============================================================
        // PRODUCT DISPLAY / SHIPPING
        // ============================================================
        [MaxLength(20)] public string? VisibilityStatus { get; set; }
        [MaxLength(20)] public string? FulfillmentType { get; set; }
        [MaxLength(20)] public string? CarrierType { get; set; }
        public int? ReadyToDispatchDays { get; set; }
        public int? ShippingChargeLocal { get; set; }
        public int? ShippingChargeRegional { get; set; }
        public int? ShippingChargeNational { get; set; }
        public bool IsComboPack { get; set; }

        // ============================================================
        // EXTERNAL PRODUCT
        // ============================================================
        [MaxLength(100)] public string? ExternalProductId { get; set; }
        [MaxLength(20)] public string? ExternalSystemCode { get; set; }

        // ============================================================
        // PRODUCT COLOR / REMARKS
        // ============================================================
        [Column("color")][MaxLength(100)] public string? Color { get; set; }
        [Column("colorCode")][MaxLength(50)] public string? ColorCode { get; set; }
        [Column("remarks")][MaxLength(500)] public string? Remarks { get; set; }
        [Column("isAdditionalCharges")] public bool? IsAdditionalCharges { get; set; }
        [Column("size")][MaxLength(100)] public string? Size { get; set; }

        // ============================================================
        // PRODUCT X-ID
        // ============================================================
        [Column("brandXID")] public int? BrandXID { get; set; }
        [Column("itemXID")] public int? ItemXID { get; set; }

        // ============================================================
        // FLIPKART
        // ============================================================
        [Column("flipkart_fsn")][MaxLength(16)] public string? FlipkartFsn { get; set; }

        // ============================================================
        // FULFILLMENT / PROCUREMENT
        // ============================================================
        [MaxLength(50)] public string? FulfillmentProfile { get; set; }
        [MaxLength(50)] public string? ShippingProvider { get; set; }
        [MaxLength(50)] public string? ProcurementType { get; set; }
        public int? ProcurementSla { get; set; }

        // ============================================================
        // UNIWARE - BARCODE
        // ============================================================
        [MaxLength(1000)] public string? BarcodeImageUrl { get; set; }
        [MaxLength(50)] public string? BarcodeType { get; set; }
        public string? BarcodeDetailsJson { get; set; }
        public bool? IsBarcodeVerified { get; set; }
        public DateTime? BarcodeVerifiedDate { get; set; }

        // ============================================================
        // UNIWARE - BULK UPLOAD
        // ============================================================
        [MaxLength(100)] public string? BatchId { get; set; }
        public bool? IsBulkUpload { get; set; }
        public int? BulkUploadRowNumber { get; set; }
        [MaxLength(100)] public string? BulkUploadStatus { get; set; }
        [MaxLength(2000)] public string? BulkUploadError { get; set; }

        // ============================================================
        // UNIWARE - CATEGORY
        // ============================================================
        [MaxLength(200)] public string? CategoryCode { get; set; }
        [MaxLength(200)] public string? UniwareCategoryCode { get; set; }
        [MaxLength(1000)] public string? CategoryPath { get; set; }
        [NotMapped] public bool IsCategoryCodeMatch => !string.IsNullOrWhiteSpace(CategoryCode) && !string.IsNullOrWhiteSpace(UniwareCategoryCode) && string.Equals(CategoryCode, UniwareCategoryCode, StringComparison.OrdinalIgnoreCase);

        // ============================================================
        // UNIWARE - CHANNEL
        // ============================================================
        [MaxLength(100)] public string? ChannelCode { get; set; }
        [MaxLength(100)] public string? UniwareChannelCode { get; set; }
        [MaxLength(200)] public string? ChannelItemId { get; set; }
        [MaxLength(200)] public string? ChannelProductId { get; set; }
        public bool? IsChannelSynced { get; set; }
        public DateTime? LastChannelSyncDate { get; set; }
        [MaxLength(100)] public string? ChannelSyncStatus { get; set; }
        [NotMapped] public bool IsChannelCodeMatch => !string.IsNullOrWhiteSpace(ChannelCode) && !string.IsNullOrWhiteSpace(UniwareChannelCode) && string.Equals(ChannelCode, UniwareChannelCode, StringComparison.OrdinalIgnoreCase);

        // ============================================================
        // UNIWARE - VENDOR & FACILITY
        // ============================================================
        [MaxLength(100)] public string? VendorCode { get; set; }
        [MaxLength(100)] public string? VendorSkuCode { get; set; }
        [MaxLength(100)] public string? FacilityCode { get; set; }
        [MaxLength(100)] public string? UniwareFacilityCode { get; set; }
        [MaxLength(50)] public string? ListingStatus { get; set; } = "ACTIVE";

        // ============================================================
        // RELATED / CALCULATED - NOT MAPPED
        // ============================================================
        [NotMapped] public int? InventoryQuantity { get; set; }
        [NotMapped] public int? ReservedQuantity { get; set; }
        [NotMapped] public int? DamagedQuantity { get; set; }
        [NotMapped] public int? SellableInventory => InventoryQuantity.HasValue ? Math.Max(0, InventoryQuantity.Value - (ReservedQuantity ?? 0) - (DamagedQuantity ?? 0)) : null;
        [NotMapped] public decimal? OfferPrice { get; set; }
        [NotMapped] public decimal? MrpPrice { get; set; }
        [NotMapped] public int? PrimaryWarehouseId { get; set; }
        [NotMapped] public string? PrimaryWarehouseCode { get; set; }
        [NotMapped] public bool? IsWarehouseActive { get; set; }
        [NotMapped] public string? ItemSku => SKU;

        // ============================================================
        // NAVIGATION
        // ============================================================
        [ForeignKey(nameof(BrandId))] public Brand? Brand { get; set; }
        [ForeignKey(nameof(CategoryId))] public Category? Category { get; set; }
        [ForeignKey(nameof(ProductTypeId))] public ProductType? ProductType { get; set; }

        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
        public ICollection<ProductInventory> Inventories { get; set; } = new List<ProductInventory>();
        public ICollection<ProductPrice> Prices { get; set; } = new List<ProductPrice>();

        // ============================================================
        // AUDIT
        // ============================================================
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}