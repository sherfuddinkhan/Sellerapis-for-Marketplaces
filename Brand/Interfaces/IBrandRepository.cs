using Marketplacesellerportal.Brand.DTOs;
using BrandModel = Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.Brand.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<BrandModel>> GetAllAsync();

        Task<BrandModel?> GetByIdAsync(int brandId);

        Task<BrandModel?> GetByNameAsync(string brandName);

        Task<IEnumerable<BrandModel>> GetActiveBrandsAsync();

        Task AddAsync(BrandModel brand);

        Task UpdateAsync(BrandModel brand);

        Task DeleteAsync(BrandModel brand);

        Task<bool> ExistsAsync(int brandId);

        Task SaveChangesAsync();

        // Statistics
        Task<BrandStatisticsResponse> GetStatisticsAsync();


        // Filters
        Task<BrandFiltersResponse> GetFiltersAsync();
    }
}