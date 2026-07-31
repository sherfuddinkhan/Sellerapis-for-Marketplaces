using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockMovements.Interfaces;

namespace Marketplacesellerportal.StockMovements.Repositories
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public StockMovementRepository(ApplicationDbContext context)
        {
            _context = context;
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
