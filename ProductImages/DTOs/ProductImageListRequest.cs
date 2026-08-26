namespace Marketplacesellerportal.ProductImage.DTOs
{
    public class ProductImageListRequest
    {
        // Search by image URL, product ID, etc.
        public string? Search { get; set; }

        // Optional seller/customer filtering
        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }

        // Pagination
        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 24;

        // Sorting
        // Examples:
        // size_desc
        // size_asc
        // newest
        // oldest
        // name_asc
        // name_desc
        public string? Sort { get; set; }
    }
}
