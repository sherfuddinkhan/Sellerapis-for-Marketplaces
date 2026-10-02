using Marketplacesellerportal.Brands.DTOs;

namespace Marketplacesellerportal.Brands.Interfaces
{
    public interface IBrandService
    {
        // =========================================================
        // EXISTING APIs
        // =========================================================

        Task<IEnumerable<BrandResponse>>
            GetAllAsync();

        Task<BrandResponse?>
            GetByIdAsync(int brandId);

        Task<IEnumerable<BrandResponse>>
            GetActiveBrandsAsync();

        Task<bool>
            CreateAsync(CreateBrandRequest request);

        Task<bool>
            UpdateAsync(UpdateBrandRequest request);

        Task<bool>
            DeleteAsync(int brandId);


        // =========================================================
        // STATISTICS API
        // =========================================================

        Task<BrandStatisticsResponse>
            GetStatisticsAsync();


        // =========================================================
        // FILTERS API
        // =========================================================

        Task<BrandFiltersResponse>
            GetFiltersAsync();
    }
}