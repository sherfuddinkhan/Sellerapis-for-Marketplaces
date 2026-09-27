using System;

namespace Marketplacesellerportal.Models
{
    public class Gatepass
    {
        public int GatepassId { get; set; }
        public string GatepassCode { get; set; } = string.Empty;
        public string FacilityCode { get; set; } = string.Empty;
        public string ItemSkuCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = "Created";
        public string Facility { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = "admin";
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}