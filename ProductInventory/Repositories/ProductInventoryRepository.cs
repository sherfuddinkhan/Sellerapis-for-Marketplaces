using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductInventories.Interfaces;
using Marketplacesellerportal.SharedKernel.Repositories;

namespace Marketplacesellerportal.ProductInventories.Repositories
{
    public class ProductInventoryRepository
        : BaseRepository<ProductInventory>,
          IProductInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductInventoryRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL INVENTORY
        // =========================================================
        public async Task<IEnumerable<ProductInventory>> GetAllAsync()
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .ToListAsync();
        }

        // =========================================================
        // GET INVENTORY BY ID
        // =========================================================
        public async Task<ProductInventory?> GetByIdAsync(
            int productInventoryId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.ProductInventoryId == productInventoryId);
        }

        // =========================================================
        // GET INVENTORY BY SELLER
        // =========================================================
        public async Task<IEnumerable<ProductInventory>> GetBySellerIdAsync(
            int sellerId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        // =========================================================
        // GET INVENTORY BY SELLER + CUSTOMER
        // =========================================================
        public async Task<IEnumerable<ProductInventory>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        // =========================================================
        // GET INVENTORY BY PRODUCT
        // =========================================================
        public async Task<IEnumerable<ProductInventory>> GetByProductIdAsync(
            int productId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        // =========================================================
        // GET INVENTORY BY WAREHOUSE
        // =========================================================
        public async Task<IEnumerable<ProductInventory>> GetByWarehouseIdAsync(
            int warehouseId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .Where(x => x.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // =========================================================
        // GET SPECIFIC INVENTORY
        // SELLER + PRODUCT + WAREHOUSE + LOCATION
        // =========================================================
        public async Task<ProductInventory?> GetInventoryAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int locationId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.ProductId == productId &&
                    x.WarehouseId == warehouseId &&
                    x.LocationId == locationId);
        }

        // =========================================================
        // ADD INVENTORY
        // =========================================================
        public async Task AddAsync(ProductInventory productInventory)
        {
            await _context.ProductInventory
                .AddAsync(productInventory);
        }

        // =========================================================
        // UPDATE INVENTORY
        // =========================================================
        public Task UpdateAsync(ProductInventory productInventory)
        {
            _context.ProductInventory.Update(productInventory);

            return Task.CompletedTask;
        }

        // =========================================================
        // DELETE INVENTORY BY ID
        // =========================================================
        public async Task DeleteAsync(int productInventoryId)
        {
            var entity = await _context.ProductInventory
                .FirstOrDefaultAsync(x =>
                    x.ProductInventoryId == productInventoryId);

            if (entity != null)
            {
                _context.ProductInventory.Remove(entity);
            }
        }

        // =========================================================
        // DELETE INVENTORY ENTITY
        // REQUIRED BY IGenericRepository
        // =========================================================
        public Task DeleteAsync(ProductInventory productInventory)
        {
            _context.ProductInventory.Remove(productInventory);

            return Task.CompletedTask;
        }

        // =========================================================
        // SAVE CHANGES
        // =========================================================
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}