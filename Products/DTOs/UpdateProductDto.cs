namespace Marketplacesellerportal.Products.DTOs
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public string? Barcode { get; set; }
        public int? BrandId { get; set; }
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

        // ALL LISTING FIELDS - Not missing
        public string? TaxCategory { get; set; }
        public string? VisibilityStatus { get; set; }
        public string? FulfillmentType { get; set; }
        public string? CarrierType { get; set; }
        public int? ReadyToDispatchDays { get; set; }
        public int ShippingChargeLocal { get; set; }
        public int ShippingChargeRegional { get; set; }
        public int ShippingChargeNational { get; set; }
        public bool IsComboPack { get; set; }

        // EXTERNAL MAPPING
        public string? ExternalProductId { get; set; } = string.Empty;
        public string? ExternalSystemCode { get; set; } = string.Empty;
    }
}