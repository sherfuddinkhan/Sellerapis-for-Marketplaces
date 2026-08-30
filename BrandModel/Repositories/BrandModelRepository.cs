using BrandModelEntity =
    Marketplacesellerportal.Models.BrandModel;

using Marketplacesellerportal.BrandModel.Interfaces;
using Marketplacesellerportal.Database;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.BrandModel.Repositories
{
    public class BrandModelRepository : IBrandModelRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandModelRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================
        public async Task<List<BrandModelEntity>> GetAllAsync()
        {
            return await _context.BrandModels
                .OrderBy(x => x.ModelName)
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================
        public async Task<BrandModelEntity?> GetByIdAsync(
            int id)
        {
            return await _context.BrandModels
                .FirstOrDefaultAsync(
                    x => x.BrandModelId == id);
        }

        // =========================================================
        // GET BY BRAND ID
        // =========================================================
        public async Task<List<BrandModelEntity>> GetByBrandIdAsync(
            int brandId)
        {
            return await _context.BrandModels
                .Where(x => x.BrandId == brandId)
                .OrderBy(x => x.ModelName)
                .ToListAsync();
        }

        // =========================================================
        // GET BY MULTIPLE BRAND IDS
        // =========================================================
        public async Task<List<BrandModelEntity>> GetByBrandIdsAsync(
            IEnumerable<int> brandIds)
        {
            var ids = brandIds
                .Distinct()
                .ToList();

            if (!ids.Any())
                return new List<BrandModelEntity>();

            return await _context.BrandModels
                .Where(x => ids.Contains(x.BrandId))
                .OrderBy(x => x.ModelName)
                .ToListAsync();
        }

        // =========================================================
        // CREATE
        // =========================================================
        public async Task<BrandModelEntity> CreateAsync(
            BrandModelEntity brandModel)
        {
            await _context.BrandModels.AddAsync(brandModel);
            await _context.SaveChangesAsync();

            return brandModel;
        }

        // =========================================================
        // UPDATE
        // =========================================================
        public async Task<BrandModelEntity?> UpdateAsync(
            int id,
            BrandModelEntity brandModel)
        {
            var existing =
                await _context.BrandModels
                    .FirstOrDefaultAsync(
                        x => x.BrandModelId == id);

            if (existing == null)
                return null;

            existing.BrandId = brandModel.BrandId;
            existing.ModelName = brandModel.ModelName;
            existing.Description = brandModel.Description;
            existing.IsActive = brandModel.IsActive;
            existing.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return existing;
        }

        // =========================================================
        // DELETE
        // =========================================================
        public async Task<bool> DeleteAsync(int id)
        {
            var brandModel =
                await _context.BrandModels
                    .FirstOrDefaultAsync(
                        x => x.BrandModelId == id);

            if (brandModel == null)
                return false;

            _context.BrandModels.Remove(brandModel);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<BrandModelEntity>> GetByBrandIdsAsync(
    List<int> brandIds)
        {
            return await _context.BrandModels
                .Where(x => brandIds.Contains(x.BrandId))
                .OrderBy(x => x.ModelName)
                .ToListAsync();
        }
    }
}