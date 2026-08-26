namespace Marketplacesellerportal.Products.DTOs
{
    public class ProductStatisticsResponse
    {
        public int TotalProducts { get; set; }

        public int ActiveProducts { get; set; }

        public int InactiveProducts { get; set; }

        public int ProductsWithStock { get; set; }

        public int OutOfStockProducts { get; set; }

        public int LowStockProducts { get; set; }

        public int TotalBrands { get; set; }

        public int TotalCategories { get; set; }

        public int TotalProductTypes { get; set; }
    }
}
