using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class GoodsReceiptItem
    {
        [Key]
        public int GoodsReceiptItemId { get; set; }

        public int GoodsReceiptNoteId { get; set; }

        public int ProductId { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal AcceptedQuantity { get; set; }

        public decimal? RejectedQuantity { get; set; }

        [MaxLength(1000)]
        public string? Remarks { get; set; }

        [ForeignKey(nameof(GoodsReceiptNoteId))]
        public GoodsReceiptNote? GoodsReceiptNote { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
    }
}
