namespace Marketplacesellerportal.Catalog.DTOs
{
    public class ProductReviewResponse
    {
        public string CustomerName { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string? Review { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
