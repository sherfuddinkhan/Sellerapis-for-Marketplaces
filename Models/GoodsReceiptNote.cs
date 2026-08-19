using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class GoodsReceiptNote
    {
        [Key]
        public int GoodsReceiptNoteId { get; set; }

        public int PurchaseOrderId { get; set; }

        [Required]
        [MaxLength(200)]
        public string GRNNumber { get; set; } = string.Empty;

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        [MaxLength(100)]
        public string? Status { get; set; }

        [MaxLength(1000)]
        public string? Remarks { get; set; }


        // Existing properties
        public DateTime? ReceiptDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(PurchaseOrderId))]
        public PurchaseOrder? PurchaseOrder { get; set; }

        public ICollection<GoodsReceiptItem>? GoodsReceiptItems { get; set; }
    }
}
