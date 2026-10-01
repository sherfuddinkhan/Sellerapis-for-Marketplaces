namespace Marketplacesellerportal.DTOs
{
    public class SupplierAddressDto
    {
        public int SupplierAddressId { get; set; }

        public int SupplierId { get; set; }

        public string AddressLine1 { get; set; }
            = string.Empty;

        public string? AddressLine2 { get; set; }

        public string City { get; set; }
            = "Chennai";

        public string State { get; set; }
            = "Tamil Nadu";

        public string Pincode { get; set; }
            = "600001";

        public string Country { get; set; }
            = "India";

        public string FacilityCode { get; set; }
            = "TN-WH-01";

        public string? ChannelCode { get; set; }
            = "CUSTOM";

        public string? BinCode { get; set; }
            = "BIN-A1";

        public string? ShelfCode { get; set; }
            = "SHELF-01";

        public string? UniwareFacilityCode { get; set; }
            = "TN-WH-01";

        public string? UniwareSyncStatus { get; set; }
            = "Pending";

        public DateTime CreatedDate { get; set; }
    }

}
