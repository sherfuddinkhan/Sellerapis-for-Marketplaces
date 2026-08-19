namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerSalesOrderResponse
    {
        public int SalesOrderId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public string SalesOrderNumber { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public string? Remarks { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}