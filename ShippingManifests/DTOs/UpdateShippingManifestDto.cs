namespace Marketplacesellerportal.ShippingManifest.DTOs
{

    public class UpdateShippingManifestDto
    {
        public string Channel { get; set; } = "CUSTOM";

        public string ShippingProviderCode { get; set; }

        public string ShippingProviderName { get; set; }

        public string ShippingMethodCode { get; set; }

        public string Comments { get; set; }

        public string Status { get; set; } = "CREATED";

        public bool ThirdPartyShipping { get; set; } = false;
    }
}
