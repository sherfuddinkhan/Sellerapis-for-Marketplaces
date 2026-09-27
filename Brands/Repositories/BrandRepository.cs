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
        public BrandRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<BrandEntity>> GetAllAsync()
            => await _context.Brands.OrderBy(x => x.BrandName).ToListAsync();

        public async Task<BrandEntity?> GetByIdAsync(int brandId)
            => await _context.Brands.FirstOrDefaultAsync(x => x.BrandId == brandId);

        public async Task<BrandEntity?> GetByNameAsync(string brandName)
            => await _context.Brands.FirstOrDefaultAsync(x => x.BrandName == brandName);

        public async Task<IEnumerable<BrandEntity>> GetActiveBrandsAsync()
            => await _context.Brands.Where(x => x.IsActive).OrderBy(x => x.BrandName).ToListAsync();

        public async Task AddAsync(BrandEntity brand) => await _context.Brands.AddAsync(brand);

        public Task UpdateAsync(BrandEntity brand)
        {
            _context.Brands.Update(brand);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(BrandEntity brand)
        {
            _context.Brands.Remove(brand);
            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int brandId)
            => await _context.Brands.AnyAsync(x => x.BrandId == brandId);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<BrandStatisticsResponse> GetStatisticsAsync()
        {
            var total = await _context.Brands.CountAsync();
            var active = await _context.Brands.CountAsync(x => x.IsActive);
            var brandsWithProducts = await _context.Brands.Where(b => _context.Products.Any(p => p.BrandId == b.BrandId)).CountAsync();
            return new BrandStatisticsResponse
            {
                TotalBrands = total,
                ActiveBrands = active,
                InactiveBrands = total - active,
                BrandsWithProducts = brandsWithProducts,
                BrandsWithoutProducts = total - brandsWithProducts
            };
        }

        public async Task<BrandFiltersResponse> GetFiltersAsync()
        {
            var names = await _context.Brands.Select(x => x.BrandName).Distinct().OrderBy(x => x).ToListAsync();
            return new BrandFiltersResponse { BrandNames = names, Statuses = new List<string> { "Active", "Inactive" } };
        }
    }
}