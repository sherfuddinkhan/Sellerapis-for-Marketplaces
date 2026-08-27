using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockAdjustments.DTOs;
using Marketplacesellerportal.StockAdjustments.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.StockAdjustments.Repositories
{
    public class StockAdjustmentRepository : IStockAdjustmentRepository
    {
        private readonly ApplicationDbContext _context;

        public StockAdjustmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockAdjustment>> GetAllAsync()
        {
            return await _context.StockAdjustments.ToListAsync();
        }
        public async Task<IEnumerable<StockAdjustment>> GetBySellerCustomerAsync(int sellerId,int customerId)
        {
            return await _context.StockAdjustments
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<StockAdjustment>> SearchAsync(
       string search)
        {
            search = search.Trim().ToLower();

            return await _context.StockAdjustments
                .Where(x =>
                    x.AdjustmentType.ToLower().Contains(search) ||
                    (x.Reason != null &&
                     x.Reason.ToLower().Contains(search)) ||
                    (x.AdjustedBy != null &&
                     x.AdjustedBy.ToLower().Contains(search)))
                .ToListAsync();
        }
        public async Task<IEnumerable<StockAdjustment>> GetSortedAsync(
    string? sort)
        {
            var query = _context.StockAdjustments
                .AsNoTracking()
                .AsQueryable();

            return sort?.ToLower() switch
            {
                "date_asc" =>
                    await query
                        .OrderBy(x => x.AdjustmentDate)
                        .ToListAsync(),

                "date_desc" =>
                    await query
                        .OrderByDescending(x => x.AdjustmentDate)
                        .ToListAsync(),

                "quantity_asc" =>
                    await query
                        .OrderBy(x => x.Quantity)
                        .ToListAsync(),

                "quantity_desc" =>
                    await query
                        .OrderByDescending(x => x.Quantity)
                        .ToListAsync(),

                "type_asc" =>
                    await query
                        .OrderBy(x => x.AdjustmentType)
                        .ToListAsync(),

                "type_desc" =>
                    await query
                        .OrderByDescending(x => x.AdjustmentType)
                        .ToListAsync(),

                _ =>
                    await query
                        .OrderByDescending(x => x.StockAdjustmentId)
                        .ToListAsync()
            };
        }
        public async Task<PagedResult<StockAdjustment>> GetPagedAsync(
    int page,
    int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var query = _context.StockAdjustments
                .AsNoTracking()
                .OrderByDescending(x => x.StockAdjustmentId);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return new PagedResult<StockAdjustment>
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                Items = items
            };
        }
        public async Task<StockAdjustmentStatistics> GetStatisticsAsync()
        {
            var totalAdjustments =
                await _context.StockAdjustments.CountAsync();

            var positiveAdjustments =
                await _context.StockAdjustments
                    .CountAsync(x => x.Quantity > 0);

            var negativeAdjustments =
                await _context.StockAdjustments
                    .CountAsync(x => x.Quantity < 0);

            var totalQuantity =
                await _context.StockAdjustments
                    .Select(x => (decimal?)x.Quantity)
                    .SumAsync() ?? 0;

            var averageQuantity =
                await _context.StockAdjustments
                    .Select(x => (decimal?)x.Quantity)
                    .AverageAsync() ?? 0;

            return new StockAdjustmentStatistics
            {
                TotalAdjustments = totalAdjustments,
                PositiveAdjustments = positiveAdjustments,
                NegativeAdjustments = negativeAdjustments,
                TotalQuantityAdjusted = totalQuantity,
                AverageQuantityAdjusted = averageQuantity
            };
        }
        public async Task<StockAdjustment?> GetByIdAsync(int stockAdjustmentId)
        {
            return await _context.StockAdjustments
                .FirstOrDefaultAsync(x => x.StockAdjustmentId == stockAdjustmentId);
        }

        public async Task<IEnumerable<StockAdjustment>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.StockAdjustments
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockAdjustment>> GetByProductIdAsync(int productId)
        {
            return await _context.StockAdjustments
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockAdjustment>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.StockAdjustments
                .Where(x => x.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockAdjustment>> GetByAdjustmentTypeAsync(string adjustmentType)
        {
            return await _context.StockAdjustments
                .Where(x => x.AdjustmentType == adjustmentType)
                .ToListAsync();
        }

        public async Task<StockAdjustment?> GetStockAdjustmentAsync(int sellerId,int productId,int warehouseId,int stockAdjustmentId)
        {
            return await _context.StockAdjustments.FirstOrDefaultAsync(x =>
                x.SellerId == sellerId &&
                x.ProductId == productId &&
                x.WarehouseId == warehouseId &&
                x.StockAdjustmentId == stockAdjustmentId);
        }

        public async Task AddAsync(StockAdjustment stockAdjustment)
        {
            await _context.StockAdjustments.AddAsync(stockAdjustment);
        }

        public Task UpdateAsync(StockAdjustment stockAdjustment)
        {
            _context.StockAdjustments.Update(stockAdjustment);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int stockAdjustmentId)
        {
            var entity = await GetByIdAsync(stockAdjustmentId);

            if (entity != null)
                _context.StockAdjustments.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
