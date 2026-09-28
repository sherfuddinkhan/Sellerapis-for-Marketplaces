namespace Marketplacesellerportal.Models
{
    public class AmazonAccount
    {
        public int AmazonAccountId { get; set; }
        public int SellerId { get; set; }
        public string? SellerCentralId { get; set; }
        public string? MarketplaceId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
