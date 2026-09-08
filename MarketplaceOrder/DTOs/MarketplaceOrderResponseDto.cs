using System;
using System.Collections.Generic;
using Marketplacesellerportal.MarketplaceOrderItem.DTOs;

namespace Marketplacesellerportal.MarketplaceOrder.DTOs
{
    public class MarketplaceOrderResponseDto
    {
        // =========================================================
        // PRIMARY KEY
        // =========================================================

        public int MarketplaceOrderId { get; set; }


        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }


        // =========================================================
        // MARKETPLACE ACCOUNT
        // =========================================================

        public int MarketplaceAccountId { get; set; }


        // =========================================================
        // ORDER IDENTIFICATION
        // =========================================================

        public string MarketplaceOrderNumber { get; set; }
            = string.Empty;

        public string? ExternalOrderId { get; set; }

        public string? SellerOrderNumber { get; set; }


        // =========================================================
        // ORDER DETAILS
        // =========================================================

        public DateTime OrderDate { get; set; }

        public string? OrderStatus { get; set; }

        public string? FulfillmentChannel { get; set; }

        public string? Currency { get; set; }


        // =========================================================
        // AMOUNT
        // =========================================================

        public decimal? TotalAmount { get; set; }


        // =========================================================
        // BUYER
        // =========================================================

        public string? BuyerName { get; set; }

        public string? BuyerEmail { get; set; }


        // =========================================================
        // PURCHASE ORDER
        // =========================================================

        public string? PurchaseOrderNumber { get; set; }


        // =========================================================
        // SYNC
        // =========================================================

        public DateTime? LastSyncDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        // =========================================================
        // ORDER ITEMS
        // =========================================================

        public List<MarketplaceOrderItemResponseDto> Items { get; set; }
            = new List<MarketplaceOrderItemResponseDto>();
    }
}

