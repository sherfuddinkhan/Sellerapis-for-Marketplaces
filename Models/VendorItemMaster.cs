using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("VendorItemMasters")]
    public class VendorItemMaster
    {
        [Key]
        public int VendorItemMasterId { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string VendorSkuCode { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string ItemSkuCode { get; set; } = string.Empty;

        public int ProductId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}