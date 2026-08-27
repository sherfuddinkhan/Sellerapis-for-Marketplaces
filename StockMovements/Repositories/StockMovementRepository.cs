using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockMovements.DTOs;
using Marketplacesellerportal.StockMovements.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.StockMovements.Repositories
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public StockMovementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<StockMovementStatistics> GetStatisticsAsync()
        {
            var movements = _context.StockMovements.AsQueryable();

            var totalMovements =
                await movements.CountAsync();

            var totalInMovements =
                await movements.CountAsync(x =>
                    x.MovementType.ToLower() == "in");

            var totalOutMovements =
                await movements.CountAsync(x =>
                    x.MovementType.ToLower() == "out");

            var totalQuantity =
                await movements
                    .Select(x => (decimal?)x.Quantity)
                    .SumAsync() ?? 0;

            var totalInQuantity =
                await movements
                    .Where(x => x.MovementType.ToLower() == "in")
                    .Select(x => (decimal?)x.Quantity)
                    .SumAsync() ?? 0;

            var totalOutQuantity =
                await movements
                    .Where(x => x.MovementType.ToLower() == "out")
                    .Select(x => (decimal?)x.Quantity)
                    .SumAsync() ?? 0;

            var totalSellers =
                await movements
                    .Select(x => x.SellerId)
                    .Distinct()
                    .CountAsync();

            var totalCustomers =
                await movements
                    .Select(x => x.CustomerId)
                    .Distinct()
                    .CountAsync();

            var totalProducts =
                await movements
                    .Select(x => x.ProductId)
                    .Distinct()
                    .CountAsync();

            var totalWarehouses =
                await movements
                    .Select(x => x.WarehouseId)
                    .Distinct()
                    .CountAsync();

            return new StockMovementStatistics
            {
                TotalMovements = totalMovements,
                TotalInMovements = totalInMovements,
                TotalOutMovements = totalOutMovements,
                TotalQuantity = totalQuantity,
                TotalInQuantity = totalInQuantity,
                TotalOutQuantity = totalOutQuantity,
                TotalSellers = totalSellers,
                TotalCustomers = totalCustomers,
                TotalProducts = totalProducts,
                TotalWarehouses = totalWarehouses
            };
        }
        // =====================================================
        // SEARCH
        // =====================================================

        public async Task<IEnumerable<StockMovement>> SearchAsync(
            string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return await _context.StockMovements
                    .AsNoTracking()
                    .ToListAsync();

            search = search.Trim().ToLower();

            return await _context.StockMovements
                .AsNoTracking()
                .Where(x =>
                    x.MovementType.ToLower().Contains(search) ||
                    x.ReferenceTable.ToLower().Contains(search) ||
                    x.Remarks.ToLower().Contains(search))
                .ToListAsync();
        }


        // =====================================================
        // SORT
        // =====================================================

        public async Task<IEnumerable<StockMovement>> GetSortedAsync(
            string? sort)
        {
            var query = _context.StockMovements
                .AsNoTracking()
                .AsQueryable();

            return sort?.ToLower() switch
            {
                "date_asc" =>
                    await query
                        .OrderBy(x => x.MovementDate)
                        .ToListAsync(),

                "date_desc" =>
                    await query
                        .OrderByDescending(x => x.MovementDate)
                        .ToListAsync(),

                "quantity_asc" =>
                    await query
                        .OrderBy(x => x.Quantity)
                        .ToListAsync(),

                "quantity_desc" =>
                    await query
                        .OrderByDescending(x => x.Quantity)
                        .ToListAsync(),

                "id_asc" =>
                    await query
                        .OrderBy(x => x.StockMovementId)
                        .ToListAsync(),

                "id_desc" =>
                    await query
                        .OrderByDescending(x => x.StockMovementId)
                        .ToListAsync(),

                _ =>
                    await query
                        .OrderByDescending(x => x.MovementDate)
                        .ToListAsync()
            };
        }


        // =====================================================
        // PAGINATION
        // =====================================================

        public async Task<PagedResult<StockMovement>> GetPagedAsync(
            int page,
            int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var query = _context.StockMovements
                .AsNoTracking()
                .OrderByDescending(x => x.MovementDate);

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return new PagedResult<StockMovement>
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                Items = items
            };
        }


        // =====================================================
        // SELLER + CUSTOMER
        // =====================================================

        public async Task<IEnumerable<StockMovement>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _context.StockMovements
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderByDescending(x => x.MovementDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<StockMovement>> GetAllAsync()
        {
            return await _context.StockMovements.ToListAsync();
        }

        public async Task<StockMovement?> GetByIdAsync(int stockMovementId)
        {
            return await _context.StockMovements
                .FirstOrDefaultAsync(x => x.StockMovementId == stockMovementId);
        }

        public async Task<IEnumerable<StockMovement>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.StockMovements
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }
   
        public async Task<IEnumerable<StockMovement>> GetByProductIdAsync(int productId)
        {
            return await _context.StockMovements
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockMovement>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.StockMovements
                .Where(x => x.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockMovement>> GetByMovementTypeAsync(string movementType)
        {
            return await _context.StockMovements
                .Where(x => x.MovementType == movementType)
                .ToListAsync();
        }

        public async Task<StockMovement?> GetStockMovementAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int stockMovementId)
        {
            return await _context.StockMovements.FirstOrDefaultAsync(x =>
                x.SellerId == sellerId &&
                x.ProductId == productId &&
                x.WarehouseId == warehouseId &&
                x.StockMovementId == stockMovementId);
        }

        public async Task AddAsync(StockMovement stockMovement)
        {
            await _context.StockMovements.AddAsync(stockMovement);
        }

        public Task UpdateAsync(StockMovement stockMovement)
        {
            _context.StockMovements.Update(stockMovement);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int stockMovementId)
        {
            var entity = await GetByIdAsync(stockMovementId);

            if (entity != null)
                _context.StockMovements.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
