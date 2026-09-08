using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceSellerPortal.Models
{
    [Table("MarketplaceOrderItems")]
    public class MarketplaceOrderItem
    {
        // =========================================================
        // PRIMARY KEY
        // =========================================================

        [Key]
        public int MarketplaceOrderItemId { get; set; }


        // =========================================================
        // ORDER RELATIONSHIP
        // =========================================================

        [Required]
        public int MarketplaceOrderId { get; set; }

        public MarketplaceOrder? Order { get; set; }


        // =========================================================
        // MARKETPLACE LISTING
        // =========================================================

        public int? MarketplaceListingId { get; set; }


        // =========================================================
        // SELLER / CUSTOMER / PRODUCT
        // =========================================================

        public int? ProductId { get; set; }

        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }


        // =========================================================
        // MARKETPLACE ORDER ITEM IDENTIFIERS
        // =========================================================

        [MaxLength(150)]
        public string? MarketplaceOrderItemNumber { get; set; }

        [MaxLength(200)]
        public string? ExternalOrderItemId { get; set; }


        // =========================================================
        // PRODUCT INFORMATION
        // =========================================================

        [MaxLength(500)]
        public string? ProductTitle { get; set; }

        [MaxLength(150)]
        public string? SKU { get; set; }


        // =========================================================
        // QUANTITY
        // =========================================================

        public int? Quantity { get; set; }


        // =========================================================
        // AMOUNTS
        // =========================================================

        [Column(TypeName = "decimal(18,2)")]
        public decimal? UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TaxAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ShippingAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { get; set; }


        // =========================================================
        // STATUS
        // =========================================================

        [MaxLength(100)]
        public string? Status { get; set; }


        // =========================================================
        // AUDIT
        // =========================================================

        public DateTime? CreatedDate { get; set; }
    }
}

