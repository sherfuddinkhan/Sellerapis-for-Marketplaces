namespace Marketplacesellerportal.OrderStatusHistories.DTOs
{
    public class OrderStatusHistoryStatistics
    {
        public int TotalRecords { get; set; }

        public int TotalOrders { get; set; }

        public int TotalSellers { get; set; }

        public int TotalCustomers { get; set; }

        public int TotalStatuses { get; set; }

        public int PendingCount { get; set; }

        public int ConfirmedCount { get; set; }

        public int ProcessingCount { get; set; }

        public int ShippedCount { get; set; }

        public int DeliveredCount { get; set; }
        public int DistinctOrders { get; set; }

        public int DistinctStatuses { get; set; }

        public DateTime? FirstChangedOn { get; set; }

        public DateTime? LastChangedOn { get; set; }
        public int CancelledCount { get; set; }

        public DateTime? LatestTimestamp { get; set; }

        public DateTime? EarliestTimestamp { get; set; }
    }
}
