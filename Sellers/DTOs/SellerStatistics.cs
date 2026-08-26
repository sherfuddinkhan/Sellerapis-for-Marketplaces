namespace Marketplacesellerportal.Sellers.DTOs
{
    public class SellerStatistics
    {
        public int TotalSellers { get; set; }

        public int ActiveSellers { get; set; }

        public int InactiveSellers { get; set; }

        public int SellersWithGSTIN { get; set; }

        public int SellersWithEmail { get; set; }

        public int SellersWithPhone { get; set; }

        public int DistinctCities { get; set; }

        public int DistinctStates { get; set; }

        public int DistinctCountries { get; set; }
    }
}


