using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.WarehouseLocations.DTOs;
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

        // =====================================================
        // GET ALL
        // =====================================================

        public async Task<IEnumerable<WarehouseLocation>> GetAllAsync()
        {
            return await _context.WarehouseLocations
                .ToListAsync();
        }

        // =====================================================
        // GET BY ID
        // =====================================================

        public async Task<WarehouseLocation?> GetByIdAsync(
            int locationId)
        {
            return await _context.WarehouseLocations
                .FirstOrDefaultAsync(x =>
                    x.LocationId == locationId);
        }

        // =====================================================
        // GET BY WAREHOUSE
        // =====================================================

        public async Task<IEnumerable<WarehouseLocation>>
            GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.WarehouseLocations
                .Where(x => x.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY CUSTOMER
        // =====================================================

        public async Task<IEnumerable<WarehouseLocation>>
            GetByCustomerIdAsync(int customerId)
        {
            return await _context.WarehouseLocations
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY WAREHOUSE + CUSTOMER
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

        // =====================================================
        // GET SPECIFIC LOCATION
        // =====================================================

        public async Task<WarehouseLocation?>
            GetLocationAsync(
                int warehouseId,
                int customerId,
                int locationId)
        {
            return await _context.WarehouseLocations
                .FirstOrDefaultAsync(x =>
                    x.WarehouseId == warehouseId &&
                    x.CustomerId == customerId &&
                    x.LocationId == locationId);
        }

        // =====================================================
        // SEARCH
        // GET:
        // /api/WarehouseLocation/search?search=abc
        // =====================================================

        public async Task<IEnumerable<WarehouseLocation>>
            SearchAsync(string search)
        {
            search = search.Trim();

            return await _context.WarehouseLocations
                .Where(x =>
                    x.LocationId.ToString().Contains(search) ||
                    x.WarehouseId.ToString().Contains(search) ||
                    x.CustomerId.ToString().Contains(search))
                .ToListAsync();
        }

        // =====================================================
        // SORT
        // GET:
        // /api/WarehouseLocation/sort?sort=id_asc
        // =====================================================

        public async Task<IEnumerable<WarehouseLocation>>
            GetSortedAsync(string? sort)
        {
            var query = _context.WarehouseLocations
                .AsQueryable();

            return sort?.ToLower() switch
            {
                "id_asc" =>
                    await query
                        .OrderBy(x => x.LocationId)
                        .ToListAsync(),

                "id_desc" =>
                    await query
                        .OrderByDescending(x => x.LocationId)
                        .ToListAsync(),

                "warehouse_asc" =>
                    await query
                        .OrderBy(x => x.WarehouseId)
                        .ToListAsync(),

                "warehouse_desc" =>
                    await query
                        .OrderByDescending(x => x.WarehouseId)
                        .ToListAsync(),

                "customer_asc" =>
                    await query
                        .OrderBy(x => x.CustomerId)
                        .ToListAsync(),

                "customer_desc" =>
                    await query
                        .OrderByDescending(x => x.CustomerId)
                        .ToListAsync(),

                _ =>
                    await query
                        .OrderBy(x => x.LocationId)
                        .ToListAsync()
            };
        }

        // =====================================================
        // PAGINATION
        // GET:
        // /api/WarehouseLocation/page?page=1&limit=15
        // =====================================================

        public async Task<PagedResult<WarehouseLocation>>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var query = _context.WarehouseLocations
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(x => x.LocationId)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return new PagedResult<WarehouseLocation>
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                Items = items
            };
        }

        // =====================================================
        // STATISTICS
        // GET:
        // /api/WarehouseLocation/statistics
        // =====================================================

        public async Task<WarehouseLocationStatistics>
            GetStatisticsAsync()
        {
            var totalLocations =
                await _context.WarehouseLocations
                    .CountAsync();

            return new WarehouseLocationStatistics
            {
                TotalLocations = totalLocations
            };
        }

        // =====================================================
        // CREATE
        // =====================================================

        public async Task AddAsync(
            WarehouseLocation location)
        {
            await _context.WarehouseLocations
                .AddAsync(location);
        }

        // =====================================================
        // UPDATE
        // =====================================================

        public Task UpdateAsync(
            WarehouseLocation location)
        {
            _context.WarehouseLocations
                .Update(location);

            return Task.CompletedTask;
        }

        // =====================================================
        // DELETE
        // =====================================================

        public async Task DeleteAsync(
            int locationId)
        {
            var location =
                await GetByIdAsync(locationId);

            if (location != null)
            {
                _context.WarehouseLocations
                    .Remove(location);
            }
        }

        // =====================================================
        // SAVE CHANGES
        // =====================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}