namespace Marketplacesellerportal.Brand.DTOs
{
    public class BrandStatisticsResponse
    {
        public int TotalBrands { get; set; }

        public int ActiveBrands { get; set; }

        public int InactiveBrands { get; set; }

        public int BrandsWithProducts { get; set; }

        public int BrandsWithoutProducts { get; set; }
    }
}
