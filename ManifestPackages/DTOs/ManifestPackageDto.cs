namespace Marketplacesellerportal.DTOs
{
    public class ManifestPackageDto
    {
        public int ManifestPackageId { get; set; }

        public int ShippingManifestId { get; set; }

        public string PackageCode { get; set; } = "PKG-001";

        public string SkuCode { get; set; } = "TN-WBH-001";

        public decimal Weight { get; set; } = 1;

        public string FacilityCode { get; set; } = "TN-WH-01";

        public string BinCode { get; set; } = "BIN-A1";

        public string ShelfCode { get; set; } = "SHELF-01";

        public string Status { get; set; } = "Created";
    }
}
