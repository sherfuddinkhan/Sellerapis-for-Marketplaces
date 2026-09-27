using Marketplacesellerportal.Brands.DTOs;
using BrandEntity = Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.Brands.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<BrandEntity>> GetAllAsync();
        Task<BrandEntity?> GetByIdAsync(int brandId);
        Task<BrandEntity?> GetByNameAsync(string brandName);
        Task<IEnumerable<BrandEntity>> GetActiveBrandsAsync();
        Task AddAsync(BrandEntity brand);
        Task UpdateAsync(BrandEntity brand);
        Task DeleteAsync(BrandEntity brand);
        Task<bool> ExistsAsync(int brandId);
        Task SaveChangesAsync();
        Task<BrandStatisticsResponse> GetStatisticsAsync();
        Task<BrandFiltersResponse> GetFiltersAsync();
    }
}