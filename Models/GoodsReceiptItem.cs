using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class GoodsReceiptItem
    {
        [Key]
        public int GoodsReceiptItemId { get; set; }

        // =========================================================
        // REFERENCES
        // =========================================================

        public int GoodsReceiptNoteId { get; set; }

        public int PurchaseOrderItemId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int SupplierId { get; set; }

        public int ProductId { get; set; }

        // =========================================================
        // LINE INFORMATION
        // =========================================================

        public int LineNumber { get; set; }

        // =========================================================
        // PRODUCT / QUANTITY
        // =========================================================

        public decimal ReceivedQuantity { get; set; }

        public decimal AcceptedQuantity { get; set; }

        public decimal RejectedQuantity { get; set; }

        // =========================================================
        // PRICE / AMOUNT
        // =========================================================

        public decimal UnitPrice { get; set; }

        public decimal TotalAmount { get; set; }

        // =========================================================
        // STATUS
        // =========================================================

        [MaxLength(100)]
        public string? Status { get; set; }

        // =========================================================
        // REMARKS
        // =========================================================

        [MaxLength(1000)]
        public string? Remarks { get; set; }

        // =========================================================
        // NAVIGATION PROPERTIES
        // =========================================================

        [ForeignKey(nameof(GoodsReceiptNoteId))]
        public GoodsReceiptNote? GoodsReceiptNote { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
    }
}

