namespace Marketplacesellerportal.Brands.DTOs
{
    public class BrandResponse
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }
        public string BrandCode { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public int ProductCount { get; set; }

        public int ModelCount { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public int? SellerId { get; set; }
        public string? LogoUrl { get; set; }
    }
}
