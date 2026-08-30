namespace Marketplacesellerportal.Catalog.DTOs
{
    public class CatalogProductResponse
    {
        public int ProductId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public string? ProductName { get; set; }

        public string? SKU { get; set; }

        public string? BrandName { get; set; }

        public string? CategoryName { get; set; }

        public string? ProductType { get; set; }

        public decimal Price { get; set; }

        public decimal? OfferPrice { get; set; }

        public int StockQuantity { get; set; }

        public string? PrimaryImage { get; set; }

        public double Rating { get; set; }

        public int ReviewCount { get; set; }

        public bool IsAvailable { get; set; }
    }
}