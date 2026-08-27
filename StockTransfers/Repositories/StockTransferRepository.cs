using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockTransfers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Models;
namespace Marketplacesellerportal.StockTransfers.Repositories
{
    public class StockTransferRepository : IStockTransferRepository
    {
        private readonly ApplicationDbContext _context;

        public StockTransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockTransfer>> GetAllAsync()
        {
            return await _context.StockTransfers.ToListAsync();
        }

        public async Task<StockTransfer?> GetByIdAsync(int stockTransferId)
        {
            return await _context.StockTransfers
                .FirstOrDefaultAsync(x => x.StockTransferId == stockTransferId);
        }

        public async Task<IEnumerable<StockTransfer>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.StockTransfers
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransfer>> GetByProductIdAsync(int productId)
        {
            return await _context.StockTransfers
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }
        public async Task<IEnumerable<StockTransfer>> SearchAsync(
    string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return await _context.StockTransfers
                    .AsNoTracking()
                    .ToListAsync();
            }

            search = search.Trim().ToLower();

            return await _context.StockTransfers
                .AsNoTracking()
                .Where(x =>
                    x.Status.ToLower().Contains(search))
                .ToListAsync();
        }
        public async Task<IEnumerable<StockTransfer>> GetSortedAsync(
    string? sort)
        {
            var query = _context.StockTransfers
                .AsNoTracking()
                .AsQueryable();

            return sort?.ToLower() switch
            {
                "date_asc" =>
                    await query
                        .OrderBy(x => x.TransferDate)
                        .ToListAsync(),

                "date_desc" =>
                    await query
                        .OrderByDescending(x => x.TransferDate)
                        .ToListAsync(),

                "quantity_asc" =>
                    await query
                        .OrderBy(x => x.Quantity)
                        .ToListAsync(),

                "quantity_desc" =>
                    await query
                        .OrderByDescending(x => x.Quantity)
                        .ToListAsync(),

                "status_asc" =>
                    await query
                        .OrderBy(x => x.Status)
                        .ToListAsync(),

                "status_desc" =>
                    await query
                        .OrderByDescending(x => x.Status)
                        .ToListAsync(),

                _ =>
                    await query
                        .OrderByDescending(x => x.TransferDate)
                        .ToListAsync()
            };
        }
        public async Task<PagedResult<StockTransfer>> GetPagedAsync(
    int page,
    int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var query = _context.StockTransfers
                .AsNoTracking()
                .OrderByDescending(x => x.TransferDate);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return new PagedResult<StockTransfer>
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                Items = items
            };
        }
        public async Task<IEnumerable<StockTransfer>> GetByFromWarehouseIdAsync(int fromWarehouseId)
        {
            return await _context.StockTransfers
                .Where(x => x.FromWarehouseId == fromWarehouseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransfer>> GetByToWarehouseIdAsync(int toWarehouseId)
        {
            return await _context.StockTransfers
                .Where(x => x.ToWarehouseId == toWarehouseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransfer>> GetByStatusAsync(string status)
        {
            return await _context.StockTransfers
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockTransfer>> GetBySellerCustomerAsync(int sellerId,int customerId)
        {
            return await _context.StockTransfers
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<StockTransfer?> GetStockTransferAsync(int sellerId,int productId,int stockTransferId)
        {
            return await _context.StockTransfers.FirstOrDefaultAsync(x =>
                x.SellerId == sellerId &&
                x.ProductId == productId &&
                x.StockTransferId == stockTransferId);
        }

        public async Task AddAsync(StockTransfer stockTransfer)
        {
            await _context.StockTransfers.AddAsync(stockTransfer);
        }

        public Task UpdateAsync(StockTransfer stockTransfer)
        {
            _context.StockTransfers.Update(stockTransfer);
            return Task.CompletedTask;
        }
        public async Task<StockTransferStatistics> GetStatisticsAsync()
        {
            var totalTransfers =
                await _context.StockTransfers.CountAsync();

            var pendingTransfers =
                await _context.StockTransfers
                    .CountAsync(x => x.Status == "Pending");

            var completedTransfers =
                await _context.StockTransfers
                    .CountAsync(x => x.Status == "Completed");

            var cancelledTransfers =
                await _context.StockTransfers
                    .CountAsync(x => x.Status == "Cancelled");

            var totalQuantity =
                await _context.StockTransfers
                    .SumAsync(x => (decimal?)x.Quantity) ?? 0;

            return new StockTransferStatistics
            {
                TotalTransfers = totalTransfers,
                PendingTransfers = pendingTransfers,
                CompletedTransfers = completedTransfers,
                CancelledTransfers = cancelledTransfers,
                TotalQuantity = totalQuantity
            };
        }
        public async Task DeleteAsync(int stockTransferId)
        {
            var entity = await GetByIdAsync(stockTransferId);

            if (entity != null)
                _context.StockTransfers.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
