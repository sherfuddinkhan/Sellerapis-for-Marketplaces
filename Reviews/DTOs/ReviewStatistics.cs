namespace Marketplacesellerportal.Reviews.DTOs
{
    public class ReviewStatistics
    {
        public int TotalRecords { get; set; }

        public int FiveStarCount { get; set; }

        public int FourStarCount { get; set; }

        public int ThreeStarCount { get; set; }

        public int TwoStarCount { get; set; }

        public int OneStarCount { get; set; }

        public int ApprovedCount { get; set; }

        public int PendingCount { get; set; }

        public int RejectedCount { get; set; }

        public decimal AverageRating { get; set; }

        public int DistinctProducts { get; set; }

        public int DistinctCustomers { get; set; }

        public int DistinctSellers { get; set; }
    }
}
