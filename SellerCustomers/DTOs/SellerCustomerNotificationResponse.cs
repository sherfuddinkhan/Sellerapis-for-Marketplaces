namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerNotificationResponse
    {
        public int NotificationId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public string? NotificationType { get; set; }

        public string? Title { get; set; }

        public string? Message { get; set; }

        public bool IsRead { get; set; }

        public DateTime? ReadDate { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
