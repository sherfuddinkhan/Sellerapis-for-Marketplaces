using Marketplacesellerportal.Brands.DTOs;
using Marketplacesellerportal.Brands.Interfaces;
using Marketplacesellerportal.Database;
using Microsoft.EntityFrameworkCore;

using BrandEntity = Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.Brands.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        // =========================================================
        // GET ALL BRANDS
        // =========================================================

        public async Task<IEnumerable<BrandEntity>>
            GetAllAsync()
        {
            return await _context.Brands
                .OrderBy(x => x.BrandName)
                .ToListAsync();
        }


        // =========================================================
        // GET BRAND BY ID
        // =========================================================

        public async Task<BrandEntity?>
            GetByIdAsync(int brandId)
        {
            return await _context.Brands
                .FirstOrDefaultAsync(x =>
                    x.BrandId == brandId);
        }


        // =========================================================
        // GET BRAND BY NAME
        // =========================================================

        public async Task<BrandEntity?>
            GetByNameAsync(string brandName)
        {
            return await _context.Brands
                .FirstOrDefaultAsync(x =>
                    x.BrandName == brandName);
        }


        // =========================================================
        // GET ACTIVE BRANDS
        // =========================================================

        public async Task<IEnumerable<BrandEntity>>
            GetActiveBrandsAsync()
        {
            return await _context.Brands
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.BrandName)
                .ToListAsync();
        }


        // =========================================================
        // ADD BRAND
        // =========================================================

        public async Task AddAsync(
            BrandEntity brand)
        {
            await _context.Brands
                .AddAsync(brand);
        }


        // =========================================================
        // UPDATE BRAND
        // =========================================================

        public Task UpdateAsync(
            BrandEntity brand)
        {
            _context.Brands
                .Update(brand);

            return Task.CompletedTask;
        }


        // =========================================================
        // DELETE BRAND
        // =========================================================

        public Task DeleteAsync(
            BrandEntity brand)
        {
            _context.Brands
                .Remove(brand);

            return Task.CompletedTask;
        }


        // =========================================================
        // CHECK BRAND EXISTS
        // =========================================================

        public async Task<bool>
            ExistsAsync(int brandId)
        {
            return await _context.Brands
                .AnyAsync(x =>
                    x.BrandId == brandId);
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
        //
        // Total Brands
        // Active Brands
        // Inactive Brands
        // Brands With Products
        // Brands Without Products
        // =========================================================

        public async Task<BrandStatisticsResponse>
            GetStatisticsAsync()
        {
            // =====================================================
            // TOTAL
            // =====================================================

            var total =
                await _context.Brands
                    .CountAsync();


            // =====================================================
            // ACTIVE
            //
            // IsActive is bool?
            // Therefore use == true.
            // =====================================================

            var active =
                await _context.Brands
                    .CountAsync(x =>
                        x.IsActive == true);


            // =====================================================
            // BRANDS WITH PRODUCTS
            // =====================================================

            var brandsWithProducts =
                await _context.Brands
                    .Where(b =>
                        _context.Products
                            .Any(p =>
                                p.BrandId == b.BrandId))
                    .CountAsync();


            // =====================================================
            // RESPONSE
            // =====================================================

            return new BrandStatisticsResponse
            {
                TotalBrands =
                    total,

                ActiveBrands =
                    active,

                InactiveBrands =
                    total - active,

                BrandsWithProducts =
                    brandsWithProducts,

                BrandsWithoutProducts =
                    total - brandsWithProducts
            };
        }


        // =========================================================
        // FILTERS
        //
        // GET /api/brands/filters
        // =========================================================

        public async Task<BrandFiltersResponse>
            GetFiltersAsync()
        {
            // =====================================================
            // BRAND NAMES
            // =====================================================

            var names =
                await _context.Brands
                    .Select(x => x.BrandName)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();


            // =====================================================
            // STATUS VALUES
            // =====================================================

            var statuses =
                new List<string>
                {
                    "Active",
                    "Inactive"
                };


            // =====================================================
            // RESPONSE
            // =====================================================

            return new BrandFiltersResponse
            {
                BrandNames =
                    names,

                Statuses =
                    statuses
            };
        }
    }
}