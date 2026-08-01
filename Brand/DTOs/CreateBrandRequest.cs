namespace Marketplacesellerportal.Brand.DTOs
{
    public class CreateBrandRequest
    {
        public string BrandName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
