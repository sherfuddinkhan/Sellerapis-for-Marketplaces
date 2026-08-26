namespace Marketplacesellerportal.Catalog.DTOs
{
    public class UpdateProductRequest
    {
        public string? SKU { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public int? ProductTypeId { get; set; }

        public bool? IsActive { get; set; }
    }
}
