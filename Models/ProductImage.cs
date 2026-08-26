namespace Marketplacesellerportal.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public long ImageSize { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int? DisplayOrder { get; set; }

        public bool? IsPrimary { get; set; }

        // =========================================================
        // STATUS
        // =========================================================

        public bool IsActive { get; set; } = true;

        public bool IsInactive => !IsActive;

        // =========================================================
        // DATE
        // =========================================================

        public DateTime? CreatedDate { get; set; }
    }
}