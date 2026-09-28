namespace Marketplacesellerportal.Models
{
    public class MarketplaceListing
    {
        public int MarketplaceListingId { get; set; }
        public int MarketplaceAccountId { get; set; }
        public int ProductId { get; set; }
        public string? MarketplaceSKU { get; set; }
        public string? MarketplaceProductId { get; set; }
        public string? ExternalProductId { get; set; }
        public string? ListingTitle { get; set; }
        public string? ListingDescription { get; set; }
        public string? ListingStatus { get; set; }
        public string? FulfillmentChannel { get; set; }
        public string? Currency { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
