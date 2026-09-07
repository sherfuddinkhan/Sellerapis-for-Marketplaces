namespace Marketplacesellerportal.Payments.DTOs
{
    public class UpiSettingsDto
    {
        public string? UPIId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string? UPIName { get; set; }

        public bool UPIEnabled { get; set; }
    }
}
