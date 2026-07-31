namespace Marketplacesellerportal.Models
{
    public class OrderStatusHistory
    {
        public int HistoryId { get; set; }

        public int OrderId { get; set; }

        public string? Status { get; set; }

        public string? Remarks { get; set; }

        public DateTime? ChangedOn { get; set; }
    }
}
