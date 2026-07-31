using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Warehouses.Interfaces;

namespace Marketplacesellerportal.Warehouses.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _context;

        public WarehouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse?> GetByIdAsync(int warehouseId)
        {
            return await _context.Warehouses
                .FirstOrDefaultAsync(x => x.WarehouseId == warehouseId);
        }

        public async Task<IEnumerable<Warehouse>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.Warehouses
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<Warehouse?> GetWarehouseAsync(int sellerId, int warehouseId)
        {
            return await _context.Warehouses
                .FirstOrDefaultAsync(x =>
                    x.SellerId == sellerId &&
                    x.WarehouseId == warehouseId);
        }

        public async Task AddAsync(Warehouse warehouse)
        {
            await _context.Warehouses.AddAsync(warehouse);
        }

        public Task UpdateAsync(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int warehouseId)
        {
            var warehouse = await GetByIdAsync(warehouseId);

            if (warehouse != null)
                _context.Warehouses.Remove(warehouse);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}