namespace Marketplacesellerportal.Models
{
    public class ProductPrice
    {
        public int ProductPriceId { get; set; }

        public int ProductId { get; set; }

        public int SellerId { get; set; }

        public string PriceType { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string? Currency { get; set; }

        public DateTime? EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}