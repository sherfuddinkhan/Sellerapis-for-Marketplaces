namespace Marketplacesellerportal.VendorItemMasters.DTOs
{
    public class VendorItemMasterModel
    {
        public int VendorItemMasterId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int VendorId { get; set; }
        public string VendorSkuCode { get; set; } = "";
        public string ItemSkuCode { get; set; } = "";
        public int ProductId { get; set; }
        public decimal CostPrice { get; set; }
        public bool IsActive { get; set; } = true;
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime? UpdatedDate { get; set; }
    }
}