using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Marketplacesellerportal.Products.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public int SellerId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
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
        public string? ItemSku { get; set; } // = SKU
        public string? CategoryCode { get; set; }
        public string? Brand { get; set; }
        public string? TaxCategory { get; set; } = "GST_18";
        public string? VisibilityStatus { get; set; } = "VISIBLE";
        public string? FulfillmentType { get; set; } = "SELF";
        public string? CarrierType { get; set; } = "PARTNER";
        public int? ReadyToDispatchDays { get; set; } = 2;
        public int ShippingChargeLocal { get; set; } = 0;
        public int ShippingChargeRegional { get; set; } = 0;
        public int ShippingChargeNational { get; set; } = 0;
        public bool IsComboPack { get; set; } = false;
        public string? ExternalProductId { get; set; } = string.Empty;
        public string? ExternalSystemCode { get; set; } = string.Empty;

        // =====================================================
        // NEW - Packages array wrapper + AddressLabel - No separate API needed
        // Flipkart PDF Page 2-3 Mandatory - Will save with Product
        // =====================================================
        public List<CreatePackageDto> Packages { get; set; } = new();
        public CreateAddressLabelDto? AddressLabel { get; set; }
    }

    // Nested DTO - For packages - Flipkart PDF: packages[]
    public class CreatePackageDto
    {
        [Required]
        public string Name { get; set; } = string.Empty; // package-identifier
        public decimal Length { get; set; } = 20;
        public decimal Breadth { get; set; } = 15; // Flipkart uses breadth, not width
        public decimal Height { get; set; } = 10;
        public decimal Weight { get; set; } = 1; // kg
        public string? Description { get; set; }
        public bool IsFragile { get; set; } = false;
    }

    // Nested DTO - For address_label - Flipkart PDF Page 3 - MANDATORY
    public class CreateAddressLabelDto
    {
        [Required]
        public string ManufacturerDetails { get; set; } = string.Empty; // address_of_manufacturer
        public string? ImporterDetails { get; set; }
        public string? PackerDetails { get; set; }
        public string CountryOfOrigin { get; set; } = "IN"; // iso_alpha2_code
        public long? MfgDateEpoch { get; set; } // EPOCH seconds
        public long? ShelfLifeSeconds { get; set; }
    }
}