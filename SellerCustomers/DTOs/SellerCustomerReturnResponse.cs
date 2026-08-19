namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerReturnResponse
    {
        public int CustomerReturnId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int? SalesOrderId { get; set; }
        public int? SalesOrderItemId { get; set; }

        public decimal Quantity { get; set; }

        public string? ReturnReason { get; set; }
        public string? ReturnStatus { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
