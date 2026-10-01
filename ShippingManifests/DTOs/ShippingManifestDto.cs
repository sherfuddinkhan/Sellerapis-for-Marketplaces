namespace Marketplacesellerportal.DTOs
{
    public class ShippingManifestDto
    {
        public string ShippingManifestCode { get; set; }

        public string Channel { get; set; } = "CUSTOM";

        public string ShippingProviderCode { get; set; }

        public string ShippingProviderName { get; set; }

        public string ShippingMethodCode { get; set; }

        public string Comments { get; set; }

        public string Status { get; set; } = "CREATED";

        public DateTime CreatedDate { get; set; }

        public bool ThirdPartyShipping { get; set; }
    }
}