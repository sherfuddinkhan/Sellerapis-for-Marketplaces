using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductAttributes.Interfaces;

namespace Marketplacesellerportal.ProductAttributes.Repositories
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductAttributeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductAttribute>> GetAllAsync()
        {
            return await _context.ProductAttributes.ToListAsync();
        }

        public async Task<ProductAttribute?> GetByIdAsync(int productAttributeId)
        {
            return await _context.ProductAttributes
                .FirstOrDefaultAsync(x => x.ProductAttributeId == productAttributeId);
        }

        public async Task<IEnumerable<ProductAttribute>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductAttributes
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductAttribute>> GetByAttributeNameAsync(string attributeName)
        {
            return await _context.ProductAttributes
                .Where(x => x.AttributeName == attributeName)
                .ToListAsync();
        }

        public async Task AddAsync(ProductAttribute productAttribute)
        {
            await _context.ProductAttributes.AddAsync(productAttribute);
        }

        public Task UpdateAsync(ProductAttribute productAttribute)
        {
            _context.ProductAttributes.Update(productAttribute);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int productAttributeId)
        {
            var entity = await GetByIdAsync(productAttributeId);

            if (entity != null)
                _context.ProductAttributes.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
