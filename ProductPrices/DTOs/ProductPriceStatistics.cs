namespace Marketplacesellerportal.ProductPrices.DTOs
{
    public class ProductPriceStatistics
    {
        public int TotalPriceRecords { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal AveragePrice { get; set; }

        public decimal MinimumPrice { get; set; }

        public decimal MaximumPrice { get; set; }

        public int ActivePrices { get; set; }

        public int InactivePrices { get; set; }

        public int OfferPrices { get; set; }

        public int WholesalePrices { get; set; }

        public int RetailPrices { get; set; }
    }
}
