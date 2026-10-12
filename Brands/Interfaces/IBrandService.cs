using Marketplacesellerportal.Brands.DTOs;

namespace Marketplacesellerportal.Brands.Interfaces
{
    public interface IBrandService
    {
        // Brand
        Task<IEnumerable<BrandResponse>> GetAllAsync();
        Task<BrandResponse?> GetByIdAsync(int brandId);
        Task<IEnumerable<BrandResponse>> GetActiveBrandsAsync();
        Task<bool> CreateAsync(CreateBrandRequest request);
        Task<bool> UpdateAsync(UpdateBrandRequest request);
        Task<bool> DeleteAsync(int brandId);
        Task<BrandStatisticsResponse> GetStatisticsAsync();
        Task<BrandFiltersResponse> GetFiltersAsync();

        // BrandModel - nested inside Brands
        Task<IEnumerable<BrandModelResponse>> GetModelsByBrandIdAsync(int brandId);
        Task<BrandModelResponse?> GetModelByIdAsync(int modelId);
        Task<BrandModelResponse> CreateModelAsync(int brandId, CreateBrandModelRequest request);
        Task<bool> UpdateModelAsync(UpdateBrandModelRequest request);
        Task<bool> DeleteModelAsync(int modelId);
    }
}