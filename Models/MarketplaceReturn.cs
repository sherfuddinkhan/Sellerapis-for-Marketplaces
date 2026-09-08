using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MarketplaceOrderItemEntity =
    MarketplaceSellerPortal.Models.MarketplaceOrderItem;

namespace Marketplacesellerportal.Models
{
    [Table("MarketplaceReturns")]
    public class MarketplaceReturn
    {
        // =========================================================
        // PRIMARY KEY
        // =========================================================

        [Key]
        public int MarketplaceReturnId { get; set; }


        // =========================================================
        // MARKETPLACE ORDER ITEM
        // =========================================================

        public int MarketplaceOrderItemId { get; set; }


        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }


        // =========================================================
        // PRODUCT
        // =========================================================

        public int? ProductId { get; set; }

        [MaxLength(150)]
        public string? SKU { get; set; }


        // =========================================================
        // RETURN DETAILS
        // =========================================================

        [MaxLength(100)]
        public string? ReturnNumber { get; set; }

        [MaxLength(300)]
        public string? ReturnReason { get; set; }

        [MaxLength(100)]
        public string? ReturnStatus { get; set; }

        public int? QuantityReturned { get; set; }


        // =========================================================
        // REFUND
        // =========================================================

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RefundAmount { get; set; }


        // =========================================================
        // DATES
        // =========================================================

        public DateTime? ReturnDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        // =========================================================
        // MARKETPLACE ORDER ITEM NAVIGATION
        // =========================================================

        [ForeignKey(nameof(MarketplaceOrderItemId))]
        public MarketplaceOrderItemEntity? MarketplaceOrderItem { get; set; }
    }
}

