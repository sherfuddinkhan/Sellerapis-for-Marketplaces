namespace Marketplacesellerportal.ProductTypes.DTOs
{
    public class CreateProductTypeRequest
    {
        public string ProductTypeName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
