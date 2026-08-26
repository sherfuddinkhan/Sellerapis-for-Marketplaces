using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.Warehouses.DTOs;
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

        // =========================================================
        // STATISTICS
        // GET /api/warehouses/statistics
        // =========================================================

        public async Task<WarehouseStatistics>
            GetStatisticsAsync()
        {
            var query = _context.Warehouses
                .AsNoTracking();

            var totalRecords =
                await query.CountAsync();

            var activeWarehouses =
                await query.CountAsync(x =>
                    x.IsActive == true);

            var inactiveWarehouses =
                await query.CountAsync(x =>
                    x.IsActive == false);

            var distinctSellers =
                await query
                    .Select(x => x.SellerId)
                    .Distinct()
                    .CountAsync();

            var distinctCustomers =
                await query
                    .Select(x => x.CustomerId)
                    .Distinct()
                    .CountAsync();

            var distinctCities =
                await query
                    .Where(x => x.City != null &&
                                x.City != "")
                    .Select(x => x.City!)
                    .Distinct()
                    .CountAsync();

            var distinctStates =
                await query
                    .Where(x => x.State != null &&
                                x.State != "")
                    .Select(x => x.State!)
                    .Distinct()
                    .CountAsync();

            return new WarehouseStatistics
            {
                TotalRecords = totalRecords,

                ActiveWarehouses =
                    activeWarehouses,

                InactiveWarehouses =
                    inactiveWarehouses,

                DistinctSellers =
                    distinctSellers,

                DistinctCustomers =
                    distinctCustomers,

                DistinctCities =
                    distinctCities,

                DistinctStates =
                    distinctStates
            };
        }
        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses
                .AsNoTracking()
                .ToListAsync();
        }


        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<Warehouse?> GetByIdAsync(
            int warehouseId)
        {
            return await _context.Warehouses
                .FirstOrDefaultAsync(x =>
                    x.WarehouseId == warehouseId);
        }


        // =========================================================
        // GET SPECIFIC WAREHOUSE
        // Seller + Customer + Warehouse
        // =========================================================

        public async Task<Warehouse?> GetWarehouseAsync(
            int sellerId,
            int customerId,
            int warehouseId)
        {
            return await _context.Warehouses
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.WarehouseId == warehouseId &&
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId);
        }


        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _context.Warehouses
                .AsNoTracking()
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _context.Warehouses
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.Warehouses
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }


        // =========================================================
        // GET BY CITY
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetByCityAsync(
                string city)
        {
            return await _context.Warehouses
                .AsNoTracking()
                .Where(x =>
                    x.City != null &&
                    x.City.ToLower() == city.ToLower())
                .ToListAsync();
        }


        // =========================================================
        // GET BY STATE
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetByStateAsync(
                string state)
        {
            return await _context.Warehouses
                .AsNoTracking()
                .Where(x =>
                    x.State != null &&
                    x.State.ToLower() == state.ToLower())
                .ToListAsync();
        }


        // =========================================================
        // SEARCH + STATUS
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            SearchAsync(
                string? search,
                string? status)
        {
            var query = _context.Warehouses
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();

                query = query.Where(x =>
                    (x.WarehouseCode != null &&
                     x.WarehouseCode.ToLower().Contains(search)) ||

                    (x.WarehouseName != null &&
                     x.WarehouseName.ToLower().Contains(search)) ||

                    (x.City != null &&
                     x.City.ToLower().Contains(search)) ||

                    (x.State != null &&
                     x.State.ToLower().Contains(search)));
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                if (status.ToLower() == "active")
                {
                    query = query.Where(x =>
                        x.IsActive == true);
                }
                else if (status.ToLower() == "inactive")
                {
                    query = query.Where(x =>
                        x.IsActive == false);
                }
            }

            return await query.ToListAsync();
        }


        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<Warehouse> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            var query = _context.Warehouses
                .AsNoTracking()
                .OrderBy(x => x.WarehouseId);

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (
                items,
                totalCount
            );
        }


        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetSortedAsync(
                string? sort)
        {
            var query = _context.Warehouses
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "name_asc":
                    query = query
                        .OrderBy(x => x.WarehouseName);
                    break;

                case "name_desc":
                    query = query
                        .OrderByDescending(x => x.WarehouseName);
                    break;

                case "city_asc":
                    query = query
                        .OrderBy(x => x.City);
                    break;

                case "city_desc":
                    query = query
                        .OrderByDescending(x => x.City);
                    break;

                case "created_asc":
                    query = query
                        .OrderBy(x => x.CreatedDate);
                    break;

                case "created_desc":
                    query = query
                        .OrderByDescending(x => x.CreatedDate);
                    break;

                default:
                    query = query
                        .OrderBy(x => x.WarehouseId);
                    break;
            }

            return await query.ToListAsync();
        }


        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            Warehouse warehouse)
        {
            await _context.Warehouses
                .AddAsync(warehouse);
        }


        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);

            return Task.CompletedTask;
        }


        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(
            int warehouseId)
        {
            var warehouse =
                await GetByIdAsync(warehouseId);

            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
            }
        }


        // =========================================================
        // SAVE
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        // =========================================================
        // FILTERS
        // GET /api/warehouses/filters
        // =========================================================

        public async Task<WarehouseFilters>
            GetFiltersAsync()
        {
            var query = _context.Warehouses
                .AsNoTracking();

            var sellerIds =
                await query
                    .Select(x => x.SellerId)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var customerIds =
                await query
                    .Select(x => x.CustomerId)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var cities =
                await query
                    .Where(x => x.City != null &&
                                x.City != "")
                    .Select(x => x.City!)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var states =
                await query
                    .Where(x => x.State != null &&
                                x.State != "")
                    .Select(x => x.State!)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var countries =
                await query
                    .Where(x => x.Country != null &&
                                x.Country != "")
                    .Select(x => x.Country!)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var statuses =
                await query
                    .Select(x =>
                        x.IsActive == true
                            ? "active"
                            : "inactive")
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            return new WarehouseFilters
            {
                SellerIds = sellerIds,

                CustomerIds = customerIds,

                Cities = cities,

                States = states,

                Countries = countries,

                Statuses = statuses
            };

        }
    }
}