namespace Marketplacesellerportal.Catalog.DTOs
{
    public class ProductImageResponse
    {
        public int ProductImageId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsPrimary { get; set; }
    }
}
