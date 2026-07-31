using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.StockMovements.Interfaces
{
    public interface IStockMovementService
    {
        Task<IEnumerable<StockMovement>> GetAllAsync();

        Task<StockMovement?> GetByIdAsync(int stockMovementId);

        Task<IEnumerable<StockMovement>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<StockMovement>> GetByProductIdAsync(int productId);

        Task<IEnumerable<StockMovement>> GetByWarehouseIdAsync(int warehouseId);

        Task<IEnumerable<StockMovement>> GetByMovementTypeAsync(string movementType);

        Task<StockMovement?> GetStockMovementAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int stockMovementId);

        Task<StockMovement> CreateAsync(StockMovement stockMovement);

        Task<bool> UpdateAsync(
            int stockMovementId,
            StockMovement stockMovement);

        Task<bool> DeleteAsync(int stockMovementId);
    }
}