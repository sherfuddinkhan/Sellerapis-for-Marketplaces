namespace Marketplacesellerportal.Models
{
    public class StockTransferStatistics
    {
        public int TotalTransfers { get; set; }

        public int PendingTransfers { get; set; }

        public int CompletedTransfers { get; set; }

        public int CancelledTransfers { get; set; }

        public decimal TotalQuantity { get; set; }
    }
}
