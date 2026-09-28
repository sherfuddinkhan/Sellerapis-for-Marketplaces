namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerAmazonInventorySyncResponse
    {
        public int InventorySyncId { get; set; }
        public int AmazonAccountId { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; } = "";
        public string ASIN { get; set; } = "";
        public string MarketplaceId { get; set; } = "";
        public int AvailableQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int InboundQuantity { get; set; }
        public DateTime? LastSyncDate { get; set; }
        public string JsonData { get; set; } = "";
    }
}
