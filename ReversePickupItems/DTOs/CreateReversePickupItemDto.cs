namespace Marketplacesellerportal.ReversePickupItems.DTOs
{
    public class CreateReversePickupItemDto
    {
        public int ReversePickupId { get; set; }

        public string SkuCode { get; set; } = "TN-WBH-001";

        public decimal Quantity { get; set; } = 1;

        public string Reason { get; set; } = "Damaged";
    }
}
