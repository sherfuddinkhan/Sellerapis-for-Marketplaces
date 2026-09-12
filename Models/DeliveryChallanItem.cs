using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("DeliveryChallanItems")]
    public class DeliveryChallanItem
    {
        // =====================================================
        // PRIMARY KEY
        // =====================================================

        [Key]
        public int DeliveryChallanItemId { get; set; }

        // =====================================================
        // FOREIGN KEYS
        // =====================================================

        public int DeliveryChallanId { get; set; }

        public int ProductId { get; set; }

        // =====================================================
        // ITEM DETAILS
        // =====================================================

        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TaxAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        // =====================================================
        // REMARKS
        // =====================================================

        [MaxLength(500)]
        public string? Remarks { get; set; }

        // =====================================================
        // AUDIT
        // =====================================================

        public DateTime? CreatedDate { get; set; }
    }
}


