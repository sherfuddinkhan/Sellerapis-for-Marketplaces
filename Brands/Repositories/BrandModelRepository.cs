using Marketplacesellerportal.Brands.Interfaces;
using Marketplacesellerportal.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Marketplacesellerportal.Brands.Repositories
{
    public class BrandModelRepository : IBrandModelRepository
    {
        private readonly Database.ApplicationDbContext _context;

        public BrandModelRepository(Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BrandModel>> GetByBrandIdAsync(int brandId)
        {
            return await _context.BrandModels
                .Where(x => x.BrandId == brandId)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }

        public async Task<BrandModel?> GetByIdAsync(int id)
        {
            return await _context.BrandModels
                .FirstOrDefaultAsync(x => x.BrandModelId == id);
        }

        public async Task<BrandModel> AddAsync(BrandModel entity)
        {
            var entry = await _context.BrandModels.AddAsync(entity);
            return entry.Entity;
        }

        public Task UpdateAsync(BrandModel entity)
        {
            _context.BrandModels.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(BrandModel entity)
        {
            _context.BrandModels.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
