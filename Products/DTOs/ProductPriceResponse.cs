namespace Marketplacesellerportal.Products.DTOs
{
    public class ProductPriceResponse
    {
        public int ProductPriceId { get; set; }

        public int ProductId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public string PriceType { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string? Currency { get; set; }

        public DateTime? EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }

        public bool? IsActive { get; set; }
    }
}
