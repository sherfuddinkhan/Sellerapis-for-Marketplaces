namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerResponse
    {
        public int CustomerId { get; set; }
        public int SellerId { get; set; }

        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? GSTIN { get; set; }

        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }

        public decimal CreditLimit { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // IMPORTANT
        public List<SellerCustomerProductResponse> Products { get; set; }
            = new List<SellerCustomerProductResponse>();
    }
}
