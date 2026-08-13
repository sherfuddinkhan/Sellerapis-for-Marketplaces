namespace Marketplacesellerportal.Catalog.DTOs
{
    public class CreateProductRequest
    {
        public int SellerId { get; set; }

        public string SKU { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public string? Barcode { get; set; }

        public string? HSNCode { get; set; }

        public string? UnitOfMeasure { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public string? Status { get; set; }

        public bool? IsActive { get; set; }
    }
}
