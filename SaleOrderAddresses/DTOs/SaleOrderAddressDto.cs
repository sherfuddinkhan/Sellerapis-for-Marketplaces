namespace Marketplacesellerportal.DTOs
{
    public class SaleOrderAddressDto
    {
        public int SaleOrderAddressId { get; set; }

        public int SaleOrderId { get; set; }

        public string AddressType { get; set; } = "SHIPPING";

        public string Name { get; set; } = "";

        public string AddressLine1 { get; set; } = "";

        public string City { get; set; } = "";

        public string Pincode { get; set; } = "";

        public string FacilityCode { get; set; } = "TN-WH-01";

        public string ChannelCode { get; set; } = "CUSTOM";
    }
}