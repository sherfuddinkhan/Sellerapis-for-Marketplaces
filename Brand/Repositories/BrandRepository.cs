using Marketplacesellerportal.Brand.Interfaces;
using Marketplacesellerportal.Database;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using BrandModel = Marketplacesellerportal.Models.Brand;

namespace Marketplacesellerportal.Brand.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BrandModel>> GetAllAsync()
        {
            return await _context.Brands
                .OrderBy(x => x.BrandName)
                .ToListAsync();
        }

        public async Task<BrandModel?> GetByIdAsync(int brandId)
        {
            return await _context.Brands
                .FirstOrDefaultAsync(x => x.BrandId == brandId);
        }

        public async Task<BrandModel?> GetByNameAsync(string brandName)
        {
            return await _context.Brands
                .FirstOrDefaultAsync(x => x.BrandName == brandName);
        }

        public async Task<IEnumerable<BrandModel>> GetActiveBrandsAsync()
        {
            return await _context.Brands
                .Where(x => x.IsActive)
                .OrderBy(x => x.BrandName)
                .ToListAsync();
        }

        public async Task AddAsync(BrandModel brand)
        {
            await _context.Brands.AddAsync(brand);
        }

        public Task UpdateAsync(BrandModel brand)
        {
            _context.Brands.Update(brand);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(BrandModel brand)
        {
            _context.Brands.Remove(brand);
            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int brandId)
        {
            return await _context.Brands
                .AnyAsync(x => x.BrandId == brandId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}