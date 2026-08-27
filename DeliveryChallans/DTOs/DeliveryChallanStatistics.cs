namespace Marketplacesellerportal.Models
{
    public class DeliveryChallanStatistics
    {
        public int TotalChallans { get; set; }

        public int PendingChallans { get; set; }

        public int DeliveredChallans { get; set; }
        public int TotalCount { get; set; }
        public int PendingCount { get; set; }
        public int DeliveredCount { get; set; }
        public int CancelledCount { get; set; }
        public int InTransitCount { get; set; }
        public int CancelledChallans { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PendingAmount { get; set; }

        public decimal DeliveredAmount { get; set; }

        public decimal CancelledAmount { get; set; }
    }
}


