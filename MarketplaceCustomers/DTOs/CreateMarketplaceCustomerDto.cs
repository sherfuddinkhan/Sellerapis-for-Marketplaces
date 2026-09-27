namespace Marketplacesellerportal.MarketplaceCustomers.DTOs
{
    public class CreateMarketplaceCustomerDto
    {
        public int sellerId { get; set; }
        public int customerId { get; set; }
        public string? marketplaceCustomerId { get; set; }
        public string? marketplaceName { get; set; }
        public string companyName { get; set; } = null!;
        public string? gstin { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? stateCode { get; set; }
        public string? pincode { get; set; }
    }
}
