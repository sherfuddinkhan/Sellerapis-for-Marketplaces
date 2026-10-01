namespace Marketplacesellerportal.SupplierContact.DTOs
{
    public class CreateSupplierContactDto
    {
        public int SupplierId { get; set; }

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public string Phone { get; set; } = "";
    }
}
