namespace Marketplacesellerportal.SaleOrderAddresses.DTOs
{
    public class CreateSaleOrderAddressDto
    {
        public int SaleOrderId { get; set; }

        public string AddressType { get; set; } = "SHIPPING";

        public string AddressLine1 { get; set; } = "";

        public string City { get; set; } = "";

        public string Pincode { get; set; } = "";
    }
}
