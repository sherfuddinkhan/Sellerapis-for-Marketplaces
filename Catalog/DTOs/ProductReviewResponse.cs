namespace Marketplacesellerportal.Catalog.DTOs
{
    public class ProductReviewResponse
    {
        public int ReviewId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Rating { get; set; }

        public string? ReviewText { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
