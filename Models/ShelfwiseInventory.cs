using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ShelfwiseInventories")]
    public class ShelfwiseInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INT")]
        public int ShelfwiseInventoryId { get; set; }

        [Required]
        public int SellerId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string FacilityCode { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string ShelfCode { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string ItemSkuCode { get; set; }

        [Column(TypeName = "INT")]
        public int Quantity { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string BatchCode { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? ExpiryDate { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [StringLength(20)]
        public string InventoryType { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string LocationCode { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "DATETIME")]
        public DateTime? UpdatedDate { get; set; }
    }
}
