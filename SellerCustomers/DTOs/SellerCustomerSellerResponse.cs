namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerSellerResponse
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; } = "";
        public string? GSTIN { get; set; }
        public string? Email { get; set; }
    }
}
