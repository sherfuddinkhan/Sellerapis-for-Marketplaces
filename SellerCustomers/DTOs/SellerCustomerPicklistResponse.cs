namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerPicklistResponse
    {
        public int PicklistId { get; set; }

        public string PicklistCode { get; set; } = string.Empty;

        public string? Destination { get; set; }

        public string? ShippingPackageCodes { get; set; }


        // =========================================================
        // SELLER / CUSTOMER
        // =========================================================

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
