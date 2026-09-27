using System;

namespace Marketplacesellerportal.Putaways.DTOs
{
    public class PutawayModel
    {
        public int PutawayId { get; set; }
        public string PutawayCode { get; set; } = "";
        public string ShelfCode { get; set; } = "";
        public string ItemTypeSkuCode { get; set; } = "";
        public int PutawayQuantity { get; set; }
        public string BatchCode { get; set; } = "";
        public string InventoryType { get; set; } = "GOOD";
        public string StatusCode { get; set; } = "CREATED";
        public string FacilityCode { get; set; } = "";
        public string PutawayType { get; set; } = "";
        public string CreatedBy { get; set; } = "admin";
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}