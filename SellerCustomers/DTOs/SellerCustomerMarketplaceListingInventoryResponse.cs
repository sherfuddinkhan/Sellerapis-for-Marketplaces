namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerMarketplaceListingInventoryResponse
    {
        public int MarketplaceListingInventoryId { get; set; }
        public int MarketplaceListingId { get; set; }
        public int ProductId { get; set; }
        public string MarketplaceSKU { get; set; } = "";
        public string ListingStatus { get; set; } = "";
        public decimal AvailableQuantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal InboundQuantity { get; set; }
        public DateTime? LastInventorySync { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}