namespace Marketplacesellerportal.Brand.DTOs
{
    public class BrandFiltersResponse
    {
        public List<string> BrandNames { get; set; } = new();

        public List<string> Statuses { get; set; } = new();
    }
}
