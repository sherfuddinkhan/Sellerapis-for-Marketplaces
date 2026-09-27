namespace Marketplacesellerportal.Gatepasses.DTOs
{
    public class GatepassModel
    {
        public int GatepassId { get; set; }
        public string GatepassCode { get; set; } = "";
        public string FacilityCode { get; set; } = "";
        public string ItemSkuCode { get; set; } = "";
        public int Quantity { get; set; }
        public string Reason { get; set; } = "";
        public string Status { get; set; } = "Created";
        public string Facility { get; set; } = "";
        public string CreatedBy { get; set; } = "admin";
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}
