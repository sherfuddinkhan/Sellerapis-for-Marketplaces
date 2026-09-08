using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceSellerPortal.Models
{
    [Table("MarketplaceOrders")]
    public class MarketplaceOrder
    {
        // =====================================================
        // PRIMARY KEY
        // =====================================================

        [Key]
        public int MarketplaceOrderId { get; set; }


        // =====================================================
        // SELLER
        // =====================================================

        [Required]
        public int SellerId { get; set; }


        // =====================================================
        // CUSTOMER
        // =====================================================

        [Required]
        public int CustomerId { get; set; }


        // =====================================================
        // MARKETPLACE ACCOUNT
        // =====================================================

        [Required]
        public int MarketplaceAccountId { get; set; }


        // =====================================================
        // MARKETPLACE ORDER IDENTIFICATION
        // =====================================================

        [Required]
        [MaxLength(150)]
        public string MarketplaceOrderNumber { get; set; }
            = string.Empty;

        [MaxLength(200)]
        public string? ExternalOrderId { get; set; }

        [MaxLength(100)]
        public string? SellerOrderNumber { get; set; }


        // =====================================================
        // ORDER INFORMATION
        // =====================================================

        public DateTime OrderDate { get; set; }

        [MaxLength(100)]
        public string? OrderStatus { get; set; }

        [MaxLength(100)]
        public string? FulfillmentChannel { get; set; }


        // =====================================================
        // MONEY
        // =====================================================

        [MaxLength(20)]
        public string? Currency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { get; set; }


        // =====================================================
        // BUYER
        // =====================================================

        [MaxLength(200)]
        public string? BuyerName { get; set; }

        [MaxLength(200)]
        public string? BuyerEmail { get; set; }


        // =====================================================
        // PURCHASE ORDER
        // =====================================================

        [MaxLength(100)]
        public string? PurchaseOrderNumber { get; set; }


        // =====================================================
        // SYNCHRONIZATION
        // =====================================================

        public DateTime? LastSyncDate { get; set; }


        // =====================================================
        // AUDIT
        // =====================================================

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        // =====================================================
        // ORDER ITEMS
        // =====================================================

        public ICollection<MarketplaceOrderItem> Items { get; set; }
            = new List<MarketplaceOrderItem>();
    }
}

