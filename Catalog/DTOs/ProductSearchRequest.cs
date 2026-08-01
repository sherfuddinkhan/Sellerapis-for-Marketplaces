namespace Marketplacesellerportal.Catalog.DTOs
{
    public class ProductSearchRequest
    {
        public string? SearchText { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public int? ProductTypeId { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
