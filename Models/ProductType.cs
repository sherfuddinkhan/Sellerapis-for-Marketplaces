namespace Marketplacesellerportal.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }

        public string ProductTypeName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}