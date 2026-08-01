namespace Marketplacesellerportal.Catalog.DTOs
{
    public class CatalogProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string BrandName { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public string ProductType { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal? OfferPrice { get; set; }

        public int StockQuantity { get; set; }

        public string? PrimaryImage { get; set; }

        public double Rating { get; set; }

        public int ReviewCount { get; set; }

        public bool IsAvailable { get; set; }
    }
}
