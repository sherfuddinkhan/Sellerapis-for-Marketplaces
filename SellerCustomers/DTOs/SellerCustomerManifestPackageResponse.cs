namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerManifestPackageResponse
    {
        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }
        public int ManifestPackageId { get; set; }

        public string ShippingManifestCode { get; set; } = string.Empty;

        public string? ShippingPackageCode { get; set; }
    }
}
