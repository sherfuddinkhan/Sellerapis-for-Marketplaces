namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerMarketplaceResponse
    {
        public int MarketplaceId { get; set; }
        public string MarketplaceCode { get; set; } = "";
        public string MarketplaceName { get; set; } = "";
        public bool IsActive { get; set; }
    }
}
