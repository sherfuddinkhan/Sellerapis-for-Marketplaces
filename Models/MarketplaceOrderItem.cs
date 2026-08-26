using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("MarketplaceOrderItems")]
    public class MarketplaceOrderItem
    {
        [Key]
        public int MarketplaceOrderItemId { get; set; }

        public int MarketplaceOrderId { get; set; }

        public int? MarketplaceListingId { get; set; }

        public int? ProductId { get; set; }

        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }

        [MaxLength(150)]
        public string? MarketplaceOrderItemNumber { get; set; }

        [MaxLength(200)]
        public string? ExternalOrderItemId { get; set; }

        [MaxLength(500)]
        public string? ProductTitle { get; set; }

        [MaxLength(150)]
        public string? SKU { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? ShippingAmount { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        [MaxLength(100)]
        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}