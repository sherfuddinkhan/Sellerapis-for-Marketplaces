namespace Marketplacesellerportal.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int? DisplayOrder { get; set; }

        public bool? IsPrimary { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}