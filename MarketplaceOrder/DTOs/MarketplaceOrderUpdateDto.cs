using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.MarketplaceOrder.DTOs
{
    public class MarketplaceOrderUpdateDto
    {
        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        [Required]
        public int SellerId { get; set; }

        [Required]
        public int CustomerId { get; set; }


        // =========================================================
        // MARKETPLACE ACCOUNT
        // =========================================================

        [Required]
        public int MarketplaceAccountId { get; set; }


        // =========================================================
        // ORDER IDENTIFICATION
        // =========================================================

        [Required]
        [MaxLength(150)]
        public string MarketplaceOrderNumber { get; set; }
            = string.Empty;

        [MaxLength(200)]
        public string? ExternalOrderId { get; set; }

        [MaxLength(100)]
        public string? SellerOrderNumber { get; set; }


        // =========================================================
        // ORDER DETAILS
        // =========================================================

        [Required]
        public DateTime OrderDate { get; set; }

        [MaxLength(100)]
        public string? OrderStatus { get; set; }

        [MaxLength(100)]
        public string? FulfillmentChannel { get; set; }

        [MaxLength(20)]
        public string? Currency { get; set; }


        // =========================================================
        // AMOUNT
        // =========================================================

        public decimal? TotalAmount { get; set; }


        // =========================================================
        // BUYER
        // =========================================================

        [MaxLength(200)]
        public string? BuyerName { get; set; }

        [MaxLength(200)]
        public string? BuyerEmail { get; set; }


        // =========================================================
        // PURCHASE ORDER
        // =========================================================

        [MaxLength(100)]
        public string? PurchaseOrderNumber { get; set; }


        // =========================================================
        // SYNC
        // =========================================================

        public DateTime? LastSyncDate { get; set; }
    }
}
