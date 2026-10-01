namespace Marketplacesellerportal.SupplierContact.DTOs
{
    namespace Marketplacesellerportal.DTOs
    {
        public class SupplierContactDto
        {
            public int SupplierContactId { get; set; }

            public int SupplierId { get; set; }

            public string Name { get; set; } = "";

            public string Email { get; set; } = "";

            public string Phone { get; set; } = "";

            public string Designation { get; set; } = "Manager";

            public bool IsPrimary { get; set; } = true;

            public string FacilityCode { get; set; } = "TN-WH-01";

            public string ChannelCode { get; set; } = "CUSTOM";

            public DateTime CreatedDate { get; set; }
        }
    }
}
