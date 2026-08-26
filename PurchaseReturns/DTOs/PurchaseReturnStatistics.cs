namespace Marketplacesellerportal.PurchaseReturns.DTOs
{
    public class PurchaseReturnStatistics
    {
        public int TotalRecords { get; set; }

        public int PendingPickupCount { get; set; }

        public int PickedUpCount { get; set; }

        public int ReceivedCount { get; set; }

        public int ApprovedCount { get; set; }

        public int RejectedCount { get; set; }

        public int CancelledCount { get; set; }

        public int CompletedCount { get; set; }

        public decimal TotalReturnAmount { get; set; }

        public int DistinctPurchaseOrders { get; set; }

        public int DistinctSuppliers { get; set; }

        public int DistinctSellers { get; set; }

        public int DistinctCustomers { get; set; }
    }
}