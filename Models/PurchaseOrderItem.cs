using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    public class PurchaseOrderItem
    {
        [Key]
        public int PurchaseOrderItemId { get; set; }

        public int PurchaseOrderId { get; set; }

        // =====================================================
        // SELLER + CUSTOMER
        // =====================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        // =====================================================
        // PRODUCT
        // =====================================================

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }

        // =====================================================
        // NAVIGATION
        // =====================================================

        [ForeignKey(nameof(PurchaseOrderId))]
        public PurchaseOrder? PurchaseOrder { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
    }
}