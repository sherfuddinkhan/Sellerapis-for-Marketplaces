
using Marketplacesellerportal.Brand.DTOs;

using BrandEntity =
    Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.Brand.Interfaces
{
    public interface IBrandRepository
    {
        // =========================================================
        // GET ALL
        // =========================================================
        Task<IEnumerable<BrandEntity>> GetAllAsync();

        // =========================================================
        // GET BY ID
        // =========================================================
        Task<BrandEntity?> GetByIdAsync(int brandId);

        // =========================================================
        // GET BY NAME
        // =========================================================
        Task<BrandEntity?> GetByNameAsync(string brandName);

        // =========================================================
        // GET ACTIVE
        // =========================================================
        Task<IEnumerable<BrandEntity>> GetActiveBrandsAsync();

        // =========================================================
        // ADD
        // =========================================================
        Task AddAsync(BrandEntity brand);

        // =========================================================
        // UPDATE
        // =========================================================
        Task UpdateAsync(BrandEntity brand);

        // =========================================================
        // DELETE
        // =========================================================
        Task DeleteAsync(BrandEntity brand);

        // =========================================================
        // EXISTS
        // =========================================================
        Task<bool> ExistsAsync(int brandId);

        // =========================================================
        // SAVE
        // =========================================================
        Task SaveChangesAsync();

        // =========================================================
        // STATISTICS
        // =========================================================
        Task<BrandStatisticsResponse> GetStatisticsAsync();

        // =========================================================
        // FILTERS
        // =========================================================
        Task<BrandFiltersResponse> GetFiltersAsync();
    }
}
