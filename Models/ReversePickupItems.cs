using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("ReversePickupItems")]
    public class ReversePickupItem
    {
        // =========================================================
        // PRIMARY KEY
        // =========================================================

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        // =========================================================
        // REVERSE PICKUP
        // =========================================================

        public int ReversePickupId { get; set; }

        // =========================================================
        // ORDER ITEM
        // =========================================================

        [MaxLength(50)]
        public string SaleOrderItemCode { get; set; } = string.Empty;

        // =========================================================
        // ITEM DETAILS
        // =========================================================

        [MaxLength(255)]
        public string Reason { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ItemSku { get; set; } = string.Empty;

        // =========================================================
        // PRICE DETAILS
        // =========================================================

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
    }
}