using Marketplacesellerportal.Catalog.DTOs;

namespace Marketplacesellerportal.Category.DTOs
{
    public class CategoryListResponse
    {
        public IEnumerable<CategoryResponse> Items { get; set; }
            = new List<CategoryResponse>();

        public int Page { get; set; }

        public int Limit { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }
    }
}
