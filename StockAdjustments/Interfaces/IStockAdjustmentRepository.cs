using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.StockAdjustments.Interfaces
{
    public interface IStockAdjustmentRepository
    {
        Task<IEnumerable<StockAdjustment>> GetAllAsync();

        Task<StockAdjustment?> GetByIdAsync(int stockAdjustmentId);

        Task<IEnumerable<StockAdjustment>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<StockAdjustment>> GetByProductIdAsync(int productId);

        Task<IEnumerable<StockAdjustment>> GetByWarehouseIdAsync(int warehouseId);

        Task<IEnumerable<StockAdjustment>> GetByAdjustmentTypeAsync(string adjustmentType);

        Task<StockAdjustment?> GetStockAdjustmentAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int stockAdjustmentId);

        Task AddAsync(StockAdjustment stockAdjustment);

        Task UpdateAsync(StockAdjustment stockAdjustment);

        Task DeleteAsync(int stockAdjustmentId);

        Task SaveChangesAsync();
    }
}
