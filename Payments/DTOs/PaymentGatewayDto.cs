namespace Marketplacesellerportal.Payments.DTOs
{
    public class PaymentGatewayDto
    {
        public string? GatewayName { get; set; }

        public string? GatewayMerchantId { get; set; }

        public string? GatewayKey { get; set; }

        public string? GatewaySecret { get; set; }

        public bool GatewayEnabled { get; set; }
    }
}
