using Marketplacesellerportal.Models;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockMovements.DTOs;
namespace Marketplacesellerportal.StockMovements.Interfaces
{
    public interface IStockMovementRepository
    {
        Task<IEnumerable<StockMovement>> GetAllAsync();

        Task<StockMovement?> GetByIdAsync(int stockMovementId);

        Task<IEnumerable<StockMovement>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<StockMovement>> GetByProductIdAsync(int productId);
        Task<IEnumerable<StockMovement>> GetBySellerCustomerAsync(int sellerId,int customerId);

        Task<IEnumerable<StockMovement>> SearchAsync(string search);

        Task<IEnumerable<StockMovement>> GetSortedAsync(string? sort);

        Task<PagedResult<StockMovement>> GetPagedAsync(int page,int limit);

        Task<StockMovementStatistics> GetStatisticsAsync();
        Task<IEnumerable<StockMovement>> GetByWarehouseIdAsync(int warehouseId);

        Task<IEnumerable<StockMovement>> GetByMovementTypeAsync(string movementType);
    
        Task<StockMovement?> GetStockMovementAsync(int sellerId,int productId,int warehouseId,int stockMovementId);

        Task AddAsync(StockMovement stockMovement);

        Task UpdateAsync(StockMovement stockMovement);

        Task DeleteAsync(int stockMovementId);

        Task SaveChangesAsync();
    }
}
