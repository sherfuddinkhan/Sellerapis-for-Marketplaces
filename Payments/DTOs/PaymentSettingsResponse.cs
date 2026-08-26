using Marketplacesellerportal.Payments.DTOs;

namespace Marketplacesellerportal.Payments.DTOs
{
    public class PaymentSettingsResponseDto
    {
        public BankDetailsDto? Bank { get; set; }

        public PaymentGatewayDto? Gateway { get; set; }

        public UpiSettingsDto? UPI { get; set; }
    }
}
