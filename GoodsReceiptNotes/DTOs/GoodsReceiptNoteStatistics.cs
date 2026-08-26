namespace Marketplacesellerportal.GoodsReceiptNotes.DTOs
{
    public class GoodsReceiptNoteStatistics
    {
        // =========================================================
        // TOTAL RECORDS
        // =========================================================

        public int TotalRecords { get; set; }


        // =========================================================
        // STATUS COUNTS
        // =========================================================

        public int PendingCount { get; set; }

        public int ReceivedCount { get; set; }

        public int InspectedCount { get; set; }

        public int RejectedCount { get; set; }

        public int CompletedCount { get; set; }


        // =========================================================
        // AMOUNTS
        // =========================================================

        public decimal TotalAmount { get; set; }


        // =========================================================
        // QUANTITIES
        // =========================================================

        public decimal TotalQuantity { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal RejectedQuantity { get; set; }


        // =========================================================
        // DISTINCT COUNTS
        // =========================================================

        public int DistinctPurchaseOrders { get; set; }

        public int DistinctSuppliers { get; set; }

        public int DistinctSellers { get; set; }

        public int DistinctCustomers { get; set; }
    }
}
