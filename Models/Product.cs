using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Products")]
    public class Product
    {
        [Key] public int ProductId { get; set; }
        [Required] public int SellerId { get; set; }
        [Required] public int CustomerId { get; set; }

        [MaxLength(250)] public string? ProductName { get; set; }
        [MaxLength(100)] public string? SKU { get; set; }
        [MaxLength(100)] public string? Barcode { get; set; }
        [MaxLength(2000)] public string? Description { get; set; }
        public string? ScanIdentifier { get; set; }
        [NotMapped] public string? BrandName { get; set; }
        public int? MinOrderSize { get; set; }
        public string? Features { get; set; }
        public string? ProductPageUrl { get; set; }

        [MaxLength(100)] public string? ProductCode { get; set; }
        [MaxLength(100)] public string? ItemCode { get; set; }
        [MaxLength(50)] public string? ItemType { get; set; } = "STANDARD";
        public int? ProductXID { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? GSTPercentage { get; set; } = 18;
        public bool? IsReturnable { get; set; } = true;
        public bool? IsCancellable { get; set; } = true;
        public bool? IsCodAvailable { get; set; } = true;
        public int? ShelfLifeDays { get; set; }
        [MaxLength(100)] public string? WarrantyPeriod { get; set; }
     
        [NotMapped] public bool? IsSynced { get; set; } = false;
        [NotMapped] public DateTime? LastSyncDate { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductTypeId { get; set; }

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

        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }

        [MaxLength(20)] public string? HSNCode { get; set; }
        [MaxLength(50)] public string? UnitOfMeasure { get; set; }
        [Column("uom")][MaxLength(20)] public string? Uom { get; set; }
        [MaxLength(50)] public string? Status { get; set; }
        public bool? IsActive { get; set; }
        [MaxLength(50)] public string? TaxCategory { get; set; }
        [MaxLength(50)] public string? TaxTypeCode { get; set; } = "GST";
        public decimal? TaxPercentage { get; set; } = 18;

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

        [Column(TypeName = "decimal(18,2)")] public decimal? Mrp { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? SellingPrice { get; set; }
        [MaxLength(10)] public string? CurrencyCode { get; set; } = "INR";

        [Column("mfgDate")] public DateTime? MfgDate { get; set; }
        [Column("expDate")] public DateTime? ExpDate { get; set; }

        [MaxLength(20)] public string? VisibilityStatus { get; set; }
        [MaxLength(20)] public string? FulfillmentType { get; set; }
        [MaxLength(20)] public string? CarrierType { get; set; }
        public int? ReadyToDispatchDays { get; set; }
        public int? ShippingChargeLocal { get; set; }
        public int? ShippingChargeRegional { get; set; }
        public int? ShippingChargeNational { get; set; }
        public bool IsComboPack { get; set; }

        [MaxLength(100)] public string? ExternalProductId { get; set; }
        [MaxLength(20)] public string? ExternalSystemCode { get; set; }

        [Column("color")][MaxLength(100)] public string? Color { get; set; }
        [Column("colorCode")][MaxLength(50)] public string? ColorCode { get; set; }
        [Column("remarks")][MaxLength(500)] public string? Remarks { get; set; }
        [Column("isAdditionalCharges")] public bool? IsAdditionalCharges { get; set; }
        [Column("size")][MaxLength(100)] public string? Size { get; set; }

        [Column("brandXID")] public int? BrandXID { get; set; }
        [Column("itemXID")] public int? ItemXID { get; set; }

        [Column("flipkart_fsn")][MaxLength(16)] public string? FlipkartFsn { get; set; }

        [MaxLength(50)] public string? FulfillmentProfile { get; set; }
        [MaxLength(50)] public string? ShippingProvider { get; set; }
        [MaxLength(50)] public string? ProcurementType { get; set; }
        public int? ProcurementSla { get; set; }

        [MaxLength(1000)] public string? BarcodeImageUrl { get; set; }
        [MaxLength(50)] public string? BarcodeType { get; set; }
        public string? BarcodeDetailsJson { get; set; }
        public bool? IsBarcodeVerified { get; set; }
        public DateTime? BarcodeVerifiedDate { get; set; }

        [MaxLength(100)] public string? BatchId { get; set; }
        public bool? IsBulkUpload { get; set; }
        public int? BulkUploadRowNumber { get; set; }
        [MaxLength(100)] public string? BulkUploadStatus { get; set; }
        [MaxLength(2000)] public string? BulkUploadError { get; set; }

        [MaxLength(200)] public string? CategoryCode { get; set; }
        [MaxLength(1000)] public string? CategoryPath { get; set; }

        // FIXED - No Uniware suffix, now compares CategoryCode vs ProductGroupCode
        [NotMapped]
        public bool IsCategoryCodeMatch =>
           !string.IsNullOrWhiteSpace(CategoryCode) &&
           !string.IsNullOrWhiteSpace(ProductGroupCode) &&
            string.Equals(CategoryCode, ProductGroupCode, StringComparison.OrdinalIgnoreCase);

        [MaxLength(100)] public string? ChannelCode { get; set; }
        [MaxLength(200)] public string? ChannelItemId { get; set; }
        [MaxLength(200)] public string? ChannelProductId { get; set; }
        public bool? IsChannelSynced { get; set; }
        public DateTime? LastChannelSyncDate { get; set; }
        [MaxLength(100)] public string? ChannelSyncStatus { get; set; }

        // FIXED - No Uniware suffix, now compares ChannelCode vs ExternalSystemCode
        [NotMapped]
        public bool IsChannelCodeMatch =>
           !string.IsNullOrWhiteSpace(ChannelCode) &&
           !string.IsNullOrWhiteSpace(ExternalSystemCode) &&
            string.Equals(ChannelCode, ExternalSystemCode, StringComparison.OrdinalIgnoreCase);

        [MaxLength(100)] public string? VendorCode { get; set; }
        [MaxLength(100)] public string? VendorSkuCode { get; set; }
        [MaxLength(100)] public string? FacilityCode { get; set; }
        [MaxLength(50)] public string? ListingStatus { get; set; } = "ACTIVE";

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

        [ForeignKey(nameof(BrandId))] public Brand? Brand { get; set; }
        [ForeignKey(nameof(CategoryId))] public Category? Category { get; set; }
        [ForeignKey(nameof(ProductTypeId))] public ProductType? ProductType { get; set; }

        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
        public ICollection<ProductInventory> Inventories { get; set; } = new List<ProductInventory>();
        public ICollection<ProductPrice> Prices { get; set; } = new List<ProductPrice>();

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(50)] public string? EanCode { get; set; }
        [MaxLength(50)] public string? UpcCode { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? SellingPriceVal { get; set; }
        [MaxLength(100)] public string? CountryOfOrigin { get; set; } = "India";
        public bool IsBatchEnabled { get; set; } = false;
        public bool IsExpiryEnabled { get; set; } = false;
        public bool IsSerialEnabled { get; set; } = false;
        [MaxLength(1000)] public string? ManufacturerDetails { get; set; }
        [MaxLength(1000)] public string? ImporterDetails { get; set; }
        [MaxLength(1000)] public string? PackerDetails { get; set; }
        public long? ShelfLifeSeconds { get; set; }
    }
}