namespace Marketplacesellerportal.StockLedgers.DTOs
{
    public class StockLedgerStatistics
    {
        // =========================================================
        // TOTALS
        // =========================================================

        public int TotalRecords { get; set; }

        public int TotalTransactions { get; set; }

        public decimal TotalQuantity { get; set; }

        public decimal TotalBalanceQuantity { get; set; }


        // =========================================================
        // TRANSACTION COUNTS
        // =========================================================

        public int PurchaseCount { get; set; }

        public int SalesCount { get; set; }

        public int AdjustmentCount { get; set; }

        public int TransferCount { get; set; }


        // =========================================================
        // DISTINCT COUNTS
        // =========================================================

        public int DistinctProducts { get; set; }

        public int DistinctWarehouses { get; set; }

        public int DistinctSellers { get; set; }

        public int DistinctCustomers { get; set; }
    }
}