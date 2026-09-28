namespace Marketplacesellerportal.Models
{
    public class MarketplaceListingInventory
    {
        public int MarketplaceListingInventoryId { get; set; }
        public int MarketplaceListingId { get; set; }
        public decimal? AvailableQuantity { get; set; }
        public decimal? ReservedQuantity { get; set; }
        public decimal? InboundQuantity { get; set; }
        public DateTime? LastInventorySync { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
