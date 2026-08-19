namespace Marketplacesellerportal.ProductTypes.DTOs
{
    public class CreateProductTypeRequest
    {
        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public string ProductTypeName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
