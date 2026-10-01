namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerSupplierAddressResponse
    {
        public int SupplierAddressId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
