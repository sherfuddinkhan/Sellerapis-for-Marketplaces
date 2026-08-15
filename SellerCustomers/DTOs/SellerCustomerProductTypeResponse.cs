namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerProductTypeResponse
    {
        public int ProductTypeId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public string ProductTypeName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
