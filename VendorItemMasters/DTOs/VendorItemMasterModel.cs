using System;

namespace Marketplacesellerportal.VendorItemMasters.DTOs
{
    public class VendorItemMasterModel
    {
        public int VendorItemMasterId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int VendorId { get; set; }
        public int ProductId { get; set; }

        public string VendorSkuCode { get; set; } = "";
        public string ItemSkuCode { get; set; } = "";
        public string? ItemCode { get; set; }
        public string? ItemSku { get; set; }
        public string? SKU { get; set; }
        public string? vendorCode { get; set; }
        public string? VendorItemCode { get; set; }

        public decimal CostPrice { get; set; }
        public decimal? unitPrice { get; set; }
        public decimal? MRP { get; set; }
        public decimal? SellingPrice { get; set; }

        public int inventory { get; set; }
        public int LeadTime { get; set; }
        public int priority { get; set; }
        public bool? enabled { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}