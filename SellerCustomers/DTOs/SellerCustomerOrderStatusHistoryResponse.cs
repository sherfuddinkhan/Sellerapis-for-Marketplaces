namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerOrderStatusHistoryResponse
    {
        public int OrderStatusHistoryId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public string? Status { get; set; }

        public DateTime? ChangedOn { get; set; }
        public int? SalesOrderId { get; set; }

        public string? PreviousStatus { get; set; }

        public string? NewStatus { get; set; }

        public string? Remarks { get; set; }

        public DateTime? StatusDate { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
