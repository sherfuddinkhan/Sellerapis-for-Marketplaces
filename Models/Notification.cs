namespace Marketplacesellerportal.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public int? CustomerId { get; set; }

        public string? Title { get; set; }

        public string? Message { get; set; }

        public bool? IsRead { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
