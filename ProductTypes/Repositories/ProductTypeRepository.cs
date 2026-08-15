using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductTypes.Interfaces;

namespace Marketplacesellerportal.ProductTypes.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductType>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _context.ProductTypes
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType?> GetByIdAsync(int productTypeId)
        {
            return await _context.ProductTypes
                .FirstOrDefaultAsync(x => x.ProductTypeId == productTypeId);
        }

        public async Task<ProductType?> GetByNameAsync(string productTypeName)
        {
            return await _context.ProductTypes
                .FirstOrDefaultAsync(x => x.ProductTypeName == productTypeName);
        }

        public async Task<IEnumerable<ProductType>> GetActiveAsync()
        {
            return await _context.ProductTypes
                .Where(x => x.IsActive)
                .ToListAsync();
        }

        public async Task AddAsync(ProductType productType)
        {
            await _context.ProductTypes.AddAsync(productType);
        }

        public Task UpdateAsync(ProductType productType)
        {
            _context.ProductTypes.Update(productType);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int productTypeId)
        {
            var entity = await GetByIdAsync(productTypeId);

            if (entity != null)
                _context.ProductTypes.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
