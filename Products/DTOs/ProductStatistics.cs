
namespace Marketplacesellerportal.Products.DTOs
{
    public class ProductStatistics
    {
        public int TotalProducts { get; set; }

        public int ActiveProducts { get; set; }

        public int InactiveProducts { get; set; }

        public Dictionary<string, int>
            StatusCounts
        { get; set; }
            = new Dictionary<string, int>();
    }
}

