namespace Marketplacesellerportal.Products.DTOs
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; } = string.Empty;

        public string SKU { get; set; } = string.Empty;

        public string? Barcode { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public int? ProductTypeId { get; set; }

        public string? Description { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public string? HSNCode { get; set; }

        public string? UnitOfMeasure { get; set; }

        public string? Status { get; set; }

        public bool? IsActive { get; set; }
    }
}