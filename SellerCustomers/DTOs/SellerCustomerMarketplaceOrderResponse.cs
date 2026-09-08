namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerMarketplaceOrderResponse
    {
        public int MarketplaceOrderId { get; set; }

        public int? MarketplaceAccountId { get; set; }

        public string? MarketplaceOrderNumber { get; set; }

        public string? ExternalOrderId { get; set; }

        public string? SellerOrderNumber { get; set; }

        public DateTime? OrderDate { get; set; }

        public string? OrderStatus { get; set; }

        public string? FulfillmentChannel { get; set; }

        public string? Currency { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? BuyerName { get; set; }

        public string? BuyerEmail { get; set; }

        public string? PurchaseOrderNumber { get; set; }

        public DateTime? LastSyncDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}