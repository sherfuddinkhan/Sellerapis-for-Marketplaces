using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductInventories.Interfaces;

namespace Marketplacesellerportal.ProductInventories.Repositories
{
    public class ProductInventoryRepository : IProductInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductInventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductInventory>> GetAllAsync()
        {
            return await _context.ProductInventories.ToListAsync();
        }

        public async Task<ProductInventory?> GetByIdAsync(int productInventoryId)
        {
            return await _context.ProductInventories
                .FirstOrDefaultAsync(x => x.ProductInventoryId == productInventoryId);
        }

        public async Task<IEnumerable<ProductInventory>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.ProductInventories
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductInventory>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductInventories
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductInventory>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.ProductInventories
                .Where(x => x.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<ProductInventory?> GetInventoryAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int locationId)
        {
            return await _context.ProductInventories
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.ProductId == productId &&
                    x.WarehouseId == warehouseId &&
                    x.LocationId == locationId);
        }

        public async Task AddAsync(ProductInventory productInventory)
        {
            await _context.ProductInventories.AddAsync(productInventory);
        }

        public Task UpdateAsync(ProductInventory productInventory)
        {
            _context.ProductInventories.Update(productInventory);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int productInventoryId)
        {
            var entity = await GetByIdAsync(productInventoryId);

            if (entity != null)
            {
                _context.ProductInventories.Remove(entity);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
