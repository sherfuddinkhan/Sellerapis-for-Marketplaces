namespace Marketplacesellerportal.SupplierAddresses.DTOs
{
    public class CreateSupplierAddressDto
    {
        public int SupplierId { get; set; }

        public string AddressLine1 { get; set; }
            = string.Empty;

        public string City { get; set; }
            = "Chennai";

        public string Pincode { get; set; }
            = "600001";

        public string FacilityCode { get; set; }
            = "TN-WH-01";
    }
}
