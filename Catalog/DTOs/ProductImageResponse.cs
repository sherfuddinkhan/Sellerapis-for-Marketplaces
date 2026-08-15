namespace Marketplacesellerportal.Catalog.DTOs
{
    public class ProductImageResponse
    {
        public int ProductImageId { get; set; }

        public int ProductId { get; set; }

        public string? ImageUrl { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPrimary { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
