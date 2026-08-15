namespace Marketplacesellerportal.Models
{
    public class ProductAttribute
    {
        public int ProductAttributeId { get; set; }

        public int ProductId { get; set; }
        public int SellerId { get; set; }

        public int CustomerId { get; set; }
        public string AttributeName { get; set; } = string.Empty;

        public string AttributeValue { get; set; } = string.Empty;

        public DateTime? CreatedDate { get; set; }
    }
}