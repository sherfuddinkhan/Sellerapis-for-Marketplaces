namespace Marketplacesellerportal.MarketplaceReturns.DTOs
{
    public class MarketplaceReturnStatistics
    {
        public int TotalReturns { get; set; }

        public int TotalReturnedQuantity { get; set; }

        public decimal TotalRefundAmount { get; set; }

        public int PendingReturns { get; set; }

        public int ApprovedReturns { get; set; }

        public int RejectedReturns { get; set; }

        public int CompletedReturns { get; set; }

        public int DistinctSellers { get; set; }

        public int DistinctCustomers { get; set; }

        public int DistinctProducts { get; set; }
    }
}
