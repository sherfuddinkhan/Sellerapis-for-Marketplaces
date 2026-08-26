namespace Marketplacesellerportal.ProductImages.DTOs
{
    public class ProductImageStatistics
    {
        public int TotalImages { get; set; }

        public int ActiveImages { get; set; }

        public int InactiveImages { get; set; }

        public int PrimaryImages { get; set; }

        public int SecondaryImages { get; set; }

        public int ProductsWithImages { get; set; }

        public long TotalSize { get; set; }
        public long TotalImageSize { get; set; }
        public long AverageSize { get; set; }
     
    }
}
