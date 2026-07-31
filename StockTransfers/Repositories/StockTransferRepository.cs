using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockTransfers.Interfaces;

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

        public async Task<StockTransfer?> GetStockTransferAsync(
            int sellerId,
            int productId,
            int stockTransferId)
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
