using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("MarketplaceReturns")]
    public class MarketplaceReturn
    {
        [Key]
        public int MarketplaceReturnId { get; set; }

        public int MarketplaceOrderItemId { get; set; }

        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }

        [MaxLength(150)]
        public string? SKU { get; set; }

        [MaxLength(100)]
        public string? ReturnNumber { get; set; }

        [MaxLength(300)]
        public string? ReturnReason { get; set; }

        [MaxLength(100)]
        public string? ReturnStatus { get; set; }

        public int? QuantityReturned { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RefundAmount { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // Navigation property
        [ForeignKey(nameof(MarketplaceOrderItemId))]
        public MarketplaceOrderItem? MarketplaceOrderItem { get; set; }
    }
}
