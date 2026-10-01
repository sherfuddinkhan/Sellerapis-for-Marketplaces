namespace Marketplacesellerportal.VendorItemCustomFields.DTOs
{
    public class CreateVendorItemCustomFieldDto
    {
        public int ProductId { get; set; }

        public string FieldName { get; set; } = "";

        public string FieldValue { get; set; } = "";
    }

}
