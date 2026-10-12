namespace Marketplacesellerportal.Brands.DTOs
{
    public class UpdateBrandModelRequest
    {
        public int BrandModelId { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
