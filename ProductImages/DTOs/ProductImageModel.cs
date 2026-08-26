namespace Marketplacesellerportal.ProductImages.DTOs
{
    public class ProductImageModel
    {
        public int ProductImageId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public long ImageSize { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int? DisplayOrder { get; set; }

        public bool? IsPrimary { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
