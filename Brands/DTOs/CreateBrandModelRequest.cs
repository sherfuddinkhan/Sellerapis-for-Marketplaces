namespace Marketplacesellerportal.Brands.DTOs
{
    public class CreateBrandModelRequest
    {
        public string ModelName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        // BrandId will be set from route, so don't need in body
        internal int BrandId { get; set; }
    }
}
