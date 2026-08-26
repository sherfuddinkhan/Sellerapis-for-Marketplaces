using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("GoodsReceiptNotes")]
    public class GoodsReceiptNote
    {
        [Key]
        public int GoodsReceiptNoteId { get; set; }

        // =========================================================
        // PURCHASE ORDER
        // =========================================================

        public int PurchaseOrderId { get; set; }

        // =========================================================
        // SELLER / CUSTOMER / SUPPLIER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int? SupplierId { get; set; }

        // =========================================================
        // GRN DETAILS
        // =========================================================

        [Required]
        [MaxLength(200)]
        public string GRNNumber { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Status { get; set; }

        [MaxLength(1000)]
        public string? Remarks { get; set; }

        // =========================================================
        // RECEIPT DETAILS
        // =========================================================

        public DateTime? ReceiptDate { get; set; }

        // =========================================================
        // FINANCIAL DETAILS
        // =========================================================

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        // =========================================================
        // QUANTITY DETAILS
        // =========================================================

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ReceivedQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RejectedQuantity { get; set; }

        // =========================================================
        // AUDIT
        // =========================================================

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // =========================================================
        // NAVIGATION
        // =========================================================

        [ForeignKey(nameof(PurchaseOrderId))]
        public PurchaseOrder? PurchaseOrder { get; set; }

        public ICollection<GoodsReceiptItem>? GoodsReceiptItems { get; set; }
    }
}