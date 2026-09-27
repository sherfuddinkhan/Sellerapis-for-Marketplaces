namespace Marketplacesellerportal.Brands.DTOs
{
    public class UpdateBrandRequest
    {
        public int BrandId { get; set; }
        public string BrandCode { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }
    }
}
