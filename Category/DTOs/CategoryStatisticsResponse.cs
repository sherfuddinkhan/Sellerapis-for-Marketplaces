namespace Marketplacesellerportal.Category.DTOs
{
    public class CategoryStatisticsResponse
    {
        public int TotalCategories { get; set; }

        public int ActiveCategories { get; set; }

        public int InactiveCategories { get; set; }

        public int CategoriesWithProducts { get; set; }

        public int CategoriesWithoutProducts { get; set; }
    }
}
