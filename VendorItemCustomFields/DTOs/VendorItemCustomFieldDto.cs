namespace Marketplacesellerportal.DTOs
{
    public class VendorItemCustomFieldDto
    {
        public int VendorItemCustomFieldId { get; set; }

        public int ProductId { get; set; }

        public int VendorId { get; set; }

        public string FieldName { get; set; } = "";

        public string FieldValue { get; set; } = "";

        public string SkuCode { get; set; } = "TN-WBH-001";

        public string FacilityCode { get; set; } = "TN-WH-01";

        public string ChannelCode { get; set; } = "CUSTOM";
    }
}
