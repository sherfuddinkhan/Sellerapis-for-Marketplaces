namespace Marketplacesellerportal.Category.DTOs
{
    public class CategoryListRequest
    {
        public string? Search { get; set; }

        public string? Status { get; set; }

        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 10;

        public string? Sort { get; set; }
    }
}
