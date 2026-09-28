namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerVendorItemMasterResponse
    {
        public int VendorItemMasterId { get; set; }
        public int VendorId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string VendorSkuCode { get; set; } = string.Empty;
        public string ItemSkuCode { get; set; } = string.Empty;
        public decimal CostPrice { get; set; }
        public int? ProductId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
