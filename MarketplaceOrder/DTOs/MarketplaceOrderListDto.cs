using System;

namespace Marketplacesellerportal.MarketplaceOrder.DTOs
{
    public class MarketplaceOrderListDto
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
        // MARKETPLACE
        // =========================================================

        public int MarketplaceAccountId { get; set; }


        // =========================================================
        // ORDER
        // =========================================================

        public string MarketplaceOrderNumber { get; set; }
            = string.Empty;

        public string? ExternalOrderId { get; set; }

        public string? SellerOrderNumber { get; set; }

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
        // ITEM COUNT
        // =========================================================

        public int ItemCount { get; set; }


        // =========================================================
        // DATES
        // =========================================================

        public DateTime? LastSyncDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
