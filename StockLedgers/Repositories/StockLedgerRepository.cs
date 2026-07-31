using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockLedgers.Interfaces;

namespace Marketplacesellerportal.StockLedgers.Repositories
{
    public class StockLedgerRepository : IStockLedgerRepository
    {
        private readonly ApplicationDbContext _context;

        public StockLedgerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockLedger>> GetAllAsync()
        {
            return await _context.StockLedgers.ToListAsync();
        }

        public async Task<StockLedger?> GetByIdAsync(int stockLedgerId)
        {
            return await _context.StockLedgers
                .FirstOrDefaultAsync(x => x.StockLedgerId == stockLedgerId);
        }

        public async Task<IEnumerable<StockLedger>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.StockLedgers
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockLedger>> GetByProductIdAsync(int productId)
        {
            return await _context.StockLedgers
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockLedger>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.StockLedgers
                .Where(x => x.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockLedger>> GetByTransactionTypeAsync(string transactionType)
        {
            return await _context.StockLedgers
                .Where(x => x.TransactionType == transactionType)
                .ToListAsync();
        }

        public async Task<StockLedger?> GetStockLedgerAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int stockLedgerId)
        {
            return await _context.StockLedgers.FirstOrDefaultAsync(x =>
                x.SellerId == sellerId &&
                x.ProductId == productId &&
                x.WarehouseId == warehouseId &&
                x.StockLedgerId == stockLedgerId);
        }

        public async Task AddAsync(StockLedger stockLedger)
        {
            await _context.StockLedgers.AddAsync(stockLedger);
        }

        public Task UpdateAsync(StockLedger stockLedger)
        {
            _context.StockLedgers.Update(stockLedger);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int stockLedgerId)
        {
            var entity = await GetByIdAsync(stockLedgerId);

            if (entity != null)
                _context.StockLedgers.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
