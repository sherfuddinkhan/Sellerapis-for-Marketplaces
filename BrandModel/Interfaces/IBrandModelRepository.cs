using BrandModelEntity =
    Marketplacesellerportal.Models.BrandModel;

namespace Marketplacesellerportal.BrandModel.Interfaces
{
    public interface IBrandModelRepository
    {
        // =========================================================
        // GET ALL
        // =========================================================
        Task<List<BrandModelEntity>> GetAllAsync();

        // =========================================================
        // GET BY ID
        // =========================================================
        Task<BrandModelEntity?> GetByIdAsync(
            int id);

        // =========================================================
        // GET BY BRAND ID
        // =========================================================
        Task<List<BrandModelEntity>> GetByBrandIdAsync(
            int brandId);

        // =========================================================
        // GET BY MULTIPLE BRAND IDS
        // =========================================================
        Task<List<BrandModelEntity>> GetByBrandIdsAsync(
            IEnumerable<int> brandIds);

        // =========================================================
        // CREATE
        // =========================================================
        Task<BrandModelEntity> CreateAsync(
            BrandModelEntity brandModel);

        // =========================================================
        // UPDATE
        // =========================================================
        Task<BrandModelEntity?> UpdateAsync(
            int id,
            BrandModelEntity brandModel);

        // =========================================================
        // DELETE
        // =========================================================
        Task<bool> DeleteAsync(int id);
        Task<List<BrandModelEntity>> GetByBrandIdsAsync(
         List<int> brandIds);
    }
}