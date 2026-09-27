using System;

namespace Marketplacesellerportal.ShelfwiseInventory.DTOs
{
    public class ShelfwiseInventoryModel
    {
        public int ShelfwiseInventoryId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }

        // These were missing - now added
        public string FacilityCode { get; set; } = "";
        public string ShelfCode { get; set; } = "";
        public string ItemSkuCode { get; set; } = "";
        public int Quantity { get; set; }
        public string? BatchCode { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? InventoryType { get; set; }
        public string? LocationCode { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}