namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerReviewResponse
    {
        public int ReviewId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int? SalesOrderId { get; set; }

        public int Rating { get; set; }

        public string? ReviewText { get; set; }

        public bool IsApproved { get; set; }

        public DateTime? ReviewDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
