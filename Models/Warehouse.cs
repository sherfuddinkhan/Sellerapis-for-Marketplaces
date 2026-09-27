using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Warehouses")]
    public class Warehouse
    {
        [Key] public int WarehouseId { get; set; }
        public int SellerId { get; set; } = 6;
        public int? CustomerId { get; set; } = 3;

        [Required][MaxLength(50)] public string WarehouseCode { get; set; } = string.Empty;
        [Required][MaxLength(200)] public string WarehouseName { get; set; } = string.Empty;

        // Uniware - Single definition only
        [MaxLength(100)] public string? FacilityCode { get; set; } = "WH-TN-001";
        [MaxLength(100)] public string? UniwareFacilityCode { get; set; }
        [MaxLength(200)] public string? FacilityName { get; set; }
        [MaxLength(100)] public string? FacilityType { get; set; }
        [MaxLength(100)] public string? LocationCode { get; set; }

        [MaxLength(250)] public string? AddressLine1 { get; set; }
        [MaxLength(250)] public string? AddressLine2 { get; set; }
        [MaxLength(100)] public string? City { get; set; }
        [MaxLength(100)] public string? State { get; set; }
        [MaxLength(10)] public string? StateCode { get; set; } = "36";
        [MaxLength(100)] public string? Country { get; set; } = "IN";
        [MaxLength(10)] public string? CountryCode { get; set; } = "IN";
        [MaxLength(20)] public string? PostalCode { get; set; }

        [MaxLength(150)] public string? ContactPerson { get; set; }
        [MaxLength(20)] public string? Phone { get; set; }
        [MaxLength(150)] public string? Email { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDefault { get; set; } = false;
        public bool? IsQCEnabled { get; set; } = true;
        public bool? IsPutawayEnabled { get; set; } = true;
        [MaxLength(100)] public string? ChannelCode { get; set; } = "CUSTOM";
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(100)] public string? CreatedBy { get; set; } = "System";

        [Column("pan")][MaxLength(20)] public string? Pan { get; set; }
        [Column("arn")][MaxLength(50)] public string? Arn { get; set; }
        [Column("tinNo")][MaxLength(50)] public string? TinNo { get; set; }
        [Column("cstNo")][MaxLength(50)] public string? CstNo { get; set; }
        [Column("eccNo")][MaxLength(50)] public string? EccNo { get; set; }
        [Column("fax")][MaxLength(50)] public string? Fax { get; set; }
        [MaxLength(50)] public string? GSTNumber { get; set; }

        [Column("heading")][MaxLength(200)] public string? Heading { get; set; }
        [Column("imageName")][MaxLength(200)] public string? ImageName { get; set; }
        [Column("imagePath")][MaxLength(500)] public string? ImagePath { get; set; }
        [Column("backgroundImageName")][MaxLength(200)] public string? BackgroundImageName { get; set; }
        [Column("backgroundImagePath")][MaxLength(500)] public string? BackgroundImagePath { get; set; }
        [Column("companySignature")][MaxLength(200)] public string? CompanySignature { get; set; }
        [Column("companyTallyName")][MaxLength(200)] public string? CompanyTallyName { get; set; }
        [Column("businessTypeXID")] public int? BusinessTypeXID { get; set; }
        [Column("poBox")][MaxLength(20)] public string? PoBox { get; set; }
        [MaxLength(100)] public string? ExternalLocationId { get; set; }
        [MaxLength(20)] public string? ExternalSystemCode { get; set; }
        [Column("flipkart_location_id")][MaxLength(50)] public string? FlipkartLocationId { get; set; }

        [NotMapped] public bool IsFacilityCodeMatch => !string.IsNullOrWhiteSpace(FacilityCode) && !string.IsNullOrWhiteSpace(UniwareFacilityCode) && string.Equals(FacilityCode, UniwareFacilityCode, StringComparison.OrdinalIgnoreCase);
        [NotMapped] public int? TotalInventory { get; set; }
        [NotMapped] public int? ReservedInventory { get; set; }
        [NotMapped] public int? DamagedInventory { get; set; }
        [NotMapped] public int? SellableInventory => TotalInventory.HasValue ? Math.Max(0, TotalInventory.Value - (ReservedInventory ?? 0) - (DamagedInventory ?? 0)) : null;

        public ICollection<ProductInventory> Inventories { get; set; } = [];
        public ICollection<ProductPrice> Prices { get; set; } = [];
    }
}