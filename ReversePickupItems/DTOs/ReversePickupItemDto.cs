namespace Marketplacesellerportal.DTOs
{
    public class ReversePickupItemDto
    {
        public int ReversePickupItemId { get; set; }

        public int ReversePickupId { get; set; }

        public string SkuCode { get; set; } = "TN-WBH-001";

        public decimal Quantity { get; set; } = 1;

        public string Reason { get; set; } = "Damaged";

        public string FacilityCode { get; set; } = "TN-WH-01";

        public string BinCode { get; set; } = "BIN-A1";
    }
}
