namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerSaleOrderAddressResponse
    {
        public string SaleOrderAddressId { get; set; } = string.Empty;

        public int SalesOrderId { get; set; }

        public int SellerId { get; set; }

        public int CustomerId { get; set; }

        public string? Name { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? StateCode { get; set; }

        public string? CountryCode { get; set; }

        public string? Pincode { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? AddressType { get; set; }

        public string? FacilityCode { get; set; }

        public string? ChannelCode { get; set; }
    }
}
