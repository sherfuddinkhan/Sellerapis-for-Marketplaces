using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("VendorItemMasters")]
    public class VendorItemMaster
    {
        // =========================================================
        // PRIMARY KEY
        // =========================================================

        [Key]
        public int VendorItemMasterId { get; set; }


        // =========================================================
        // REQUIRED INTEGER FIELDS
        // Database: NOT NULL
        // =========================================================

        public int VendorId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }


        // =========================================================
        // OPTIONAL INTEGER FIELD
        // Database: NULL
        // =========================================================

        public int? ProductId { get; set; }


        // =========================================================
        // SKU / ITEM INFORMATION
        // =========================================================

        [Column(TypeName = "varchar(100)")]
        public string VendorSkuCode { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        public string ItemSkuCode { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        public string? ItemCode { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? ItemSku { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? SKU { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? vendorCode { get; set; }

        [Column(TypeName = "nvarchar")]
        public string? VendorItemCode { get; set; }


        // =========================================================
        // PRICING
        // =========================================================

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? unitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MRP { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? SellingPrice { get; set; }


        // =========================================================
        // INVENTORY
        // Database: NULL
        // =========================================================

        public int? inventory { get; set; }


        // =========================================================
        // LEAD TIME
        // Database: NOT NULL
        // =========================================================

        public int LeadTime { get; set; }


        // =========================================================
        // PRIORITY
        // Database: NULL
        // =========================================================

        public int? priority { get; set; }


        // =========================================================
        // STATUS
        // =========================================================

        public bool? enabled { get; set; }

        public bool IsActive { get; set; } = true;


        // =========================================================
        // DATES
        // CreatedDate is nullable in database
        // UpdatedDate is nullable in database
        // =========================================================

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}