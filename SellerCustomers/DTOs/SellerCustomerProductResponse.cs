using System.ComponentModel.DataAnnotations;

public class SellerCustomerProductResponse
{
    public int ProductId { get; set; }
    public int SellerId { get; set; }
    public int CustomerId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public string? Barcode { get; set; }
    public int? BrandId { get; set; }
    public string? BrandName { get; set; }
    public int? CategoryId { get; set; }
    public int? ProductTypeId { get; set; }
    public string? Description { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Length { get; set; }
    public decimal? Width { get; set; }
    public decimal? Height { get; set; }
    public string? HSNCode { get; set; }
    public string? UnitOfMeasure { get; set; }
    public string? Status { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    // 11 Generalized fields
    public string? TaxCategory { get; set; }
    public string? VisibilityStatus { get; set; }
    public string? FulfillmentType { get; set; }
    public string? CarrierType { get; set; }
    public int? ReadyToDispatchDays { get; set; }
    public decimal? ShippingChargeLocal { get; set; }
    public decimal? ShippingChargeRegional { get; set; }
    public decimal? ShippingChargeNational { get; set; }
    public bool IsComboPack { get; set; }
    public string? ExternalProductId { get; set; }
    public string? ExternalSystemCode { get; set; }

    public bool? IsPrimary { get; set; } = true;

    // === FIXED: KEEP ONLY PASCALCASE - REMOVED 13 CAMELCASE DUPLICATES ===
    public string? ScanIdentifier { get; set; }
    public int? MinOrderSize { get; set; }
    public string? Features { get; set; }
    public string? ProductPageUrl { get; set; }
    public string? TaxTypeCode { get; set; }
    public string? BrandCode { get; set; }
    public string? ItemTypeCode { get; set; }
    public string? ProductDetailFieldsJson { get; set; }

    public List<ProductPackageResponse> Packages { get; set; } = new();
    public ProductAddressLabelResponse? AddressLabel { get; set; }

    public string? ItemTypeName { get; set; }
    public string? ProductGroupCode { get; set; }

    // 4 TOPAZ fields - KEEP ONLY THESE
    public string? FulfillmentProfile { get; set; } = "NON_FBF";
    public string? ShippingProvider { get; set; } = "SELLER";
    public string? ProcurementType { get; set; } = "REGULAR";
    public int? ProcurementSla { get; set; } = 2;

    // Uniware fields
    public string? ProductCode { get; set; }
    public string? ItemCode { get; set; }
    public string? ItemType { get; set; } = "STANDARD";
    public int? ProductXID { get; set; }
    public decimal? CostPrice { get; set; }
    public decimal? SellingPrice { get; set; }
    public decimal? MRP { get; set; }
    public decimal? GSTPercentage { get; set; } = 18;
    public bool? IsReturnable { get; set; } = true;
    public bool? IsCancellable { get; set; } = true;
    public bool? IsCodAvailable { get; set; } = true;
    public int? ShelfLifeDays { get; set; }
    public string? WarrantyPeriod { get; set; }
    public bool? IsSyncedToUniware { get; set; } = false;

    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? ColorCode { get; set; }

    public string? ManufacturerDetails { get; set; }
    public string? ImporterDetails { get; set; }
    public string? PackerDetails { get; set; }
    public string? CountryOfOrigin { get; set; }
    public long? ShelfLifeSeconds { get; set; }
    public string? ItemSku { get; set; }
    public string? CategoryCode { get; set; }
    public string? Brand { get; set; }
}



