using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockAdjustments.Interfaces;

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
