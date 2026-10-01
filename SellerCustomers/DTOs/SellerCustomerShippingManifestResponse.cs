namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerShippingManifestResponse
    {
        public int ShippingManifestId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string ManifestNumber { get; set; } = string.Empty;
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
