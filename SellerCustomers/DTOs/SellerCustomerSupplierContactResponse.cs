namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerSupplierContactResponse
    {
        public int SupplierContactId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
        public string? ContactName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
