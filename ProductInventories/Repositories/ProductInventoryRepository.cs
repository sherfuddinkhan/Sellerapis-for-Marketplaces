using Marketplacesellerportal.Database;
using Marketplacesellerportal.ProductInventories.DTOs;
using Marketplacesellerportal.ProductInventories.Interfaces;
using Microsoft.EntityFrameworkCore;

using ProductInventoryModel =
    Marketplacesellerportal.Models.ProductInventory;

namespace Marketplacesellerportal.ProductInventories.Repositories
{
    public class ProductInventoryRepository
        : IProductInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductInventoryRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductInventoryModel>>
            GetAllAsync()
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .OrderBy(x => x.ProductInventoryId)
                .ToListAsync();
        }

        public async Task<ProductInventoryModel?>
            GetByIdAsync(int productInventoryId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.ProductInventoryId == productInventoryId);
        }

        public async Task<IEnumerable<ProductInventoryModel>>
            GetByProductIdAsync(int productId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .OrderBy(x => x.ProductInventoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductInventoryModel>>
            GetByProductIdsAsync(IEnumerable<int> productIds)
        {
            var ids = productIds?.ToList()
                      ?? new List<int>();

            if (!ids.Any())
                return Enumerable.Empty<ProductInventoryModel>();

            return await _context.ProductInventory
                .AsNoTracking()
                .Where(x => ids.Contains(x.ProductId))
                .OrderBy(x => x.ProductInventoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductInventoryModel>>
            GetBySellerIdAsync(int sellerId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .Where(x => x.SellerId == sellerId)
                .OrderBy(x => x.ProductInventoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductInventoryModel>>
            GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .Where(x => x.WarehouseId == warehouseId)
                .OrderBy(x => x.ProductInventoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductInventoryModel>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderBy(x => x.ProductInventoryId)
                .ToListAsync();
        }

        public async Task<ProductInventoryModel?>
            GetInventoryAsync(
                int productId,
                int warehouseId,
                int locationId)
        {
            return await _context.ProductInventory
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.ProductId == productId &&
                    x.WarehouseId == warehouseId &&
                    x.LocationId == locationId);
        }

        public async Task AddAsync(
            ProductInventoryModel inventory)
        {
            await _context.ProductInventory
                .AddAsync(inventory);
        }

        public Task UpdateAsync(
            ProductInventoryModel inventory)
        {
            _context.ProductInventory.Update(inventory);

            return Task.CompletedTask;
        }

        public async Task DeleteAsync(
            int productInventoryId)
        {
            var inventory =
                await _context.ProductInventory
                    .FirstOrDefaultAsync(x =>
                        x.ProductInventoryId ==
                        productInventoryId);

            if (inventory != null)
            {
                _context.ProductInventory.Remove(inventory);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductInventoryModel>>
            SearchAsync(
                string? search,
                string? status)
        {
            var query =
                _context.ProductInventory
                    .AsNoTracking()
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                if (int.TryParse(
                    search,
                    out int numericSearch))
                {
                    query = query.Where(x =>
                        x.ProductId == numericSearch ||
                        x.ProductInventoryId == numericSearch);
                }
                else
                {
                    query = query.Where(x =>
                        _context.Products.Any(p =>
                            p.ProductId == x.ProductId &&
                            p.SKU != null &&
                            p.SKU.Contains(search)));
                }
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.Trim().ToLower();

                switch (status)
                {
                    case "low_stock":

                        query = query.Where(x =>
                            (x.Quantity ?? 0) > 0 &&
                            (x.Quantity ?? 0) <=
                            (x.ReorderLevel ?? 0));

                        break;

                    case "out_of_stock":

                        query = query.Where(x =>
                            (x.Quantity ?? 0) <= 0);

                        break;

                    case "in_stock":

                        query = query.Where(x =>
                            (x.Quantity ?? 0) >
                            (x.ReorderLevel ?? 0));

                        break;
                }
            }

            return await query
                .OrderBy(x => x.ProductInventoryId)
                .ToListAsync();
        }

        public async Task<ProductInventoryStatistics>
            GetStatisticsAsync()
        {
            var inventories =
                await _context.ProductInventory
                    .AsNoTracking()
                    .ToListAsync();

            var totalQuantity =
                inventories.Sum(x =>
                    x.Quantity ?? 0);

            var totalReserved =
                inventories.Sum(x =>
                    x.ReservedQuantity ?? 0);

            var totalDamaged =
                inventories.Sum(x =>
                    x.DamagedQuantity ?? 0);

            var available =
                totalQuantity -
                totalReserved -
                totalDamaged;

            return new ProductInventoryStatistics
            {
                TotalInventoryRecords =
                    inventories.Count,

                TotalQuantity =
                    totalQuantity,

                TotalReservedQuantity =
                    totalReserved,

                TotalDamagedQuantity =
                    totalDamaged,

                AvailableQuantity =
                    available,

                LowStockItems =
                    inventories.Count(x =>
                        (x.Quantity ?? 0) > 0 &&
                        (x.Quantity ?? 0) <=
                        (x.ReorderLevel ?? 0)),

                OutOfStockItems =
                    inventories.Count(x =>
                        (x.Quantity ?? 0) <= 0),

                InStockItems =
                    inventories.Count(x =>
                        (x.Quantity ?? 0) >
                        (x.ReorderLevel ?? 0))
            };
        }

        public async Task<(
            IEnumerable<ProductInventoryModel> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            page = page < 1 ? 1 : page;
            limit = limit < 1 ? 15 : limit;
            limit = limit > 100 ? 100 : limit;

            var query =
                _context.ProductInventory
                    .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderBy(x =>
                        x.ProductInventoryId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (items, totalCount);
        }

        public async Task<IEnumerable<ProductInventoryModel>>
            GetSortedAsync(string? sort)
        {
            var query =
                _context.ProductInventory
                    .AsNoTracking();

            switch (sort?.Trim().ToLower())
            {
                case "quantity_asc":
                    return await query
                        .OrderBy(x => x.Quantity ?? 0)
                        .ToListAsync();

                case "quantity_desc":
                    return await query
                        .OrderByDescending(x =>
                            x.Quantity ?? 0)
                        .ToListAsync();

                case "reserved_asc":
                    return await query
                        .OrderBy(x =>
                            x.ReservedQuantity ?? 0)
                        .ToListAsync();

                case "reserved_desc":
                    return await query
                        .OrderByDescending(x =>
                            x.ReservedQuantity ?? 0)
                        .ToListAsync();

                case "damaged_asc":
                    return await query
                        .OrderBy(x =>
                            x.DamagedQuantity ?? 0)
                        .ToListAsync();

                case "damaged_desc":
                    return await query
                        .OrderByDescending(x =>
                            x.DamagedQuantity ?? 0)
                        .ToListAsync();

                case "reorderlevel_asc":
                    return await query
                        .OrderBy(x =>
                            x.ReorderLevel ?? 0)
                        .ToListAsync();

                case "reorderlevel_desc":
                    return await query
                        .OrderByDescending(x =>
                            x.ReorderLevel ?? 0)
                        .ToListAsync();

                case "updated_asc":
                    return await query
                        .OrderBy(x =>
                            x.UpdatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                case "updated_desc":
                    return await query
                        .OrderByDescending(x =>
                            x.UpdatedDate ??
                            DateTime.MinValue)
                        .ToListAsync();

                default:
                    return await query
                        .OrderBy(x =>
                            x.ProductInventoryId)
                        .ToListAsync();
            }
        }
    }
}