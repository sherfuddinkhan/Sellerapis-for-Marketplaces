namespace Marketplacesellerportal.Catalog.DTOs
{
    public class ProductAttributeResponse
    {
        public int ProductAttributeId { get; set; }

        public int ProductId { get; set; }

        public string? AttributeName { get; set; }

        public string? AttributeValue { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}