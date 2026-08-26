namespace Marketplacesellerportal.ProductImage.DTOs
{
    public class ProductImageStatisticsResponse
    {
        public int TotalImages { get; set; }

        public int PrimaryImages { get; set; }

        public int SecondaryImages { get; set; }

        public int ProductsWithImages { get; set; }

        public long TotalImageSize { get; set; }

        public long AverageImageSize { get; set; }
    }
}
