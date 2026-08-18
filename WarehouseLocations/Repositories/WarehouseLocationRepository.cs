using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.WarehouseLocations.Interfaces;

namespace Marketplacesellerportal.WarehouseLocations.Repositories
{
    public class WarehouseLocationRepository : IWarehouseLocationRepository
    {
        private readonly ApplicationDbContext _context;

        public WarehouseLocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WarehouseLocation>> GetAllAsync()
        {
            return await _context.WarehouseLocations
                .ToListAsync();
        }

        public async Task<WarehouseLocation?> GetByIdAsync(int locationId)
        {
            return await _context.WarehouseLocations
                .FirstOrDefaultAsync(x => x.LocationId == locationId);
        }

        public async Task<IEnumerable<WarehouseLocation>> GetByWarehouseIdAsync(
            int warehouseId)
        {
            return await _context.WarehouseLocations
                .Where(x => x.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<WarehouseLocation>> GetByCustomerIdAsync(
            int customerId)
        {
            return await _context.WarehouseLocations
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        // =====================================================
        // SELLER-CUSTOMER MAPPING THROUGH WAREHOUSE
        // =====================================================

        public async Task<IEnumerable<WarehouseLocation>>
            GetByWarehouseCustomerAsync(
                int warehouseId,
                int customerId)
        {
            return await _context.WarehouseLocations
                .Where(x =>
                    x.WarehouseId == warehouseId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task AddAsync(WarehouseLocation location)
        {
            await _context.WarehouseLocations.AddAsync(location);
        }

        public Task UpdateAsync(WarehouseLocation location)
        {
            _context.WarehouseLocations.Update(location);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int locationId)
        {
            var location = await GetByIdAsync(locationId);

            if (location != null)
                _context.WarehouseLocations.Remove(location);
        }
    public async Task<WarehouseLocation?> GetLocationAsync(int warehouseId,int customerId,int locationId)
        {
            return await _context.WarehouseLocations
                .FirstOrDefaultAsync(x =>
                    x.WarehouseId == warehouseId &&
                    x.CustomerId == customerId &&
                    x.LocationId == locationId);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}