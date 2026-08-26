namespace Marketplacesellerportal.Products.DTOs
{
    public class ProductPriceSummaryResponse
    {
        public int ProductId { get; set; }

        public int PriceCount { get; set; }

        public decimal MinimumPrice { get; set; }

        public decimal MaximumPrice { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal? RetailPrice { get; set; }

        public decimal? WholesalePrice { get; set; }

        public decimal? OfferPrice { get; set; }
    }
}
