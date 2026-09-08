namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerMarketplaceReturnResponse
    {
        public int MarketplaceReturnId { get; set; }

        public int? MarketplaceOrderItemId { get; set; }

        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }

        public string? SKU { get; set; }

        public string? ReturnNumber { get; set; }

        public string? ReturnReason { get; set; }

        public string? ReturnStatus { get; set; }

        public int? QuantityReturned { get; set; }

        public decimal? RefundAmount { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}