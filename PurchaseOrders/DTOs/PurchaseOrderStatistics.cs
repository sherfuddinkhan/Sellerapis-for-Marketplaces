namespace Marketplacesellerportal.PurchaseOrders.DTOs
{
    public class PurchaseOrderStatistics
    {
        public int TotalOrders { get; set; }

        public int PendingApproval { get; set; }

        public int ApprovedOrders { get; set; }

        public int RejectedOrders { get; set; }

        public int CompletedOrders { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
