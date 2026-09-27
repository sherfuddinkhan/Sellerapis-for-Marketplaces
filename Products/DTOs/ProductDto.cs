namespace Marketplacesellerportal.Products.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
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
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // ALL LISTING FIELDS - Not missing
        public string? TaxCategory { get; set; } = "GST_18";
        public string? VisibilityStatus { get; set; } = "VISIBLE";
        public string? FulfillmentType { get; set; } = "SELF";
        public string? CarrierType { get; set; } = "PARTNER";
        public int? ReadyToDispatchDays { get; set; } = 2;
        public int ShippingChargeLocal { get; set; } = 0;
        public int ShippingChargeRegional { get; set; } = 0;
        public int ShippingChargeNational { get; set; } = 0;
        public bool IsComboPack { get; set; } = false;

        // EXTERNAL MAPPING
        public string? ExternalProductId { get; set; } = string.Empty;
        public string? ExternalSystemCode { get; set; } = string.Empty;
    }
}