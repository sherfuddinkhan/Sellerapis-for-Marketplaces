using Marketplacesellerportal.MarketplaceOrderItem.DTOs;
using Marketplacesellerportal.Models;
using System;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace Marketplacesellerportal.MarketplaceOrderItem.DTOs
{
    public class MarketplaceOrderItemResponseDto
    {
        public int MarketplaceOrderItemId { get; set; }

        public int MarketplaceOrderId { get; set; }

        public int? MarketplaceListingId { get; set; }

        public int? ProductId { get; set; }

        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }

        public string? MarketplaceOrderItemNumber { get; set; }

        public string? ExternalOrderItemId { get; set; }

        public string? ProductTitle { get; set; }

        public string? SKU { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? ShippingAmount { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}

