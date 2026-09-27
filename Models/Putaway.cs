using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Putaways")] // plural
    public class Putaway
    {
        [Key]
        public int PutawayId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PutawayCode { get; set; } = string.Empty;

        [Column(TypeName = "varchar(50)")]
        public string ShelfCode { get; set; } = string.Empty;

        [Column(TypeName = "varchar(50)")] // was ItemTypeskuCode - fix casing
        public string ItemTypeSkuCode { get; set; } = string.Empty;

        public int PutawayQuantity { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? BatchCode { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string InventoryType { get; set; } = "GOOD"; // GOOD, BAD, DAMAGED

        [Column(TypeName = "varchar(50)")]
        public string StatusCode { get; set; } = "CREATED";

        [Column(TypeName = "varchar(50)")]
        public string FacilityCode { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        public string? CreatedBy { get; set; }

        [Column("PutawayType", TypeName = "varchar(50)")] // FIX: don't use column name 'Type'
        public string? PutawayType { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}

