
using Marketplacesellerportal.Brand.DTOs;
using Marketplacesellerportal.Brand.Interfaces;
using Marketplacesellerportal.Database;
using Microsoft.EntityFrameworkCore;

using BrandEntity = Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.Brand.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL BRANDS
        // =========================================================
        public async Task<IEnumerable<BrandEntity>> GetAllAsync()
        {
            return await _context.Brands
                .OrderBy(x => x.BrandName)
                .ToListAsync();
        }

        // =========================================================
        // GET BRAND BY ID
        // =========================================================
        public async Task<BrandEntity?> GetByIdAsync(int brandId)
        {
            return await _context.Brands
                .FirstOrDefaultAsync(x => x.BrandId == brandId);
        }

        // =========================================================
        // GET BRAND BY NAME
        // =========================================================
        public async Task<BrandEntity?> GetByNameAsync(string brandName)
        {
            return await _context.Brands
                .FirstOrDefaultAsync(x => x.BrandName == brandName);
        }

        // =========================================================
        // GET ACTIVE BRANDS
        // =========================================================
        public async Task<IEnumerable<BrandEntity>> GetActiveBrandsAsync()
        {
            return await _context.Brands
                .Where(x => x.IsActive)
                .OrderBy(x => x.BrandName)
                .ToListAsync();
        }

        // =========================================================
        // ADD BRAND
        // =========================================================
        public async Task AddAsync(BrandEntity brand)
        {
            await _context.Brands.AddAsync(brand);
        }

        // =========================================================
        // UPDATE BRAND
        // =========================================================
        public Task UpdateAsync(BrandEntity brand)
        {
            _context.Brands.Update(brand);

            return Task.CompletedTask;
        }

        // =========================================================
        // DELETE BRAND
        // =========================================================
        public Task DeleteAsync(BrandEntity brand)
        {
            _context.Brands.Remove(brand);

            return Task.CompletedTask;
        }

        // =========================================================
        // CHECK EXISTS
        // =========================================================
        public async Task<bool> ExistsAsync(int brandId)
        {
            return await _context.Brands
                .AnyAsync(x => x.BrandId == brandId);
        }

        // =========================================================
        // SAVE CHANGES
        // =========================================================
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // =========================================================
        // STATISTICS
        // =========================================================
        public async Task<BrandStatisticsResponse> GetStatisticsAsync()
        {
            var totalBrands =
                await _context.Brands.CountAsync();

            var activeBrands =
                await _context.Brands
                    .CountAsync(x => x.IsActive);

            var inactiveBrands =
                await _context.Brands
                    .CountAsync(x => !x.IsActive);

            var brandsWithProducts =
                await _context.Brands
                    .Where(b =>
                        _context.Products.Any(
                            p => p.BrandId == b.BrandId))
                    .CountAsync();

            var brandsWithoutProducts =
                totalBrands - brandsWithProducts;

            return new BrandStatisticsResponse
            {
                TotalBrands = totalBrands,
                ActiveBrands = activeBrands,
                InactiveBrands = inactiveBrands,
                BrandsWithProducts = brandsWithProducts,
                BrandsWithoutProducts = brandsWithoutProducts
            };
        }

        // =========================================================
        // FILTERS
        // =========================================================
        public async Task<BrandFiltersResponse> GetFiltersAsync()
        {
            var brandNames =
                await _context.Brands
                    .Where(x =>
                        !string.IsNullOrEmpty(x.BrandName))
                    .Select(x => x.BrandName)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            return new BrandFiltersResponse
            {
                BrandNames = brandNames,

                Statuses = new List<string>
                {
                    "Active",
                    "Inactive"
                }
            };
        }
    }
}

