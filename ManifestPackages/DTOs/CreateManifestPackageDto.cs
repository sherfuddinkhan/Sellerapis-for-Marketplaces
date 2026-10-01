namespace Marketplacesellerportal.ManifestPackages.DTOs
{
    public class CreateManifestPackageDto
    {
        public int ShippingManifestId { get; set; }

        public string PackageCode { get; set; } = "PKG-001";

        public decimal Weight { get; set; } = 1;
    }
}
