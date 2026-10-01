namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerVendorItemCustomFieldResponse
    {
        public int VendorItemCustomFieldId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int VendorItemMasterId { get; set; }
        public string? FieldName { get; set; }
        public string? FieldValue { get; set; }
    }
}
