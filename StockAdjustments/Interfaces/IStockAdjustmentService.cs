using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.StockAdjustments.Interfaces
{
    public interface IStockAdjustmentService
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

        Task<StockAdjustment> CreateAsync(StockAdjustment stockAdjustment);

        Task<bool> UpdateAsync(
            int stockAdjustmentId,
            StockAdjustment stockAdjustment);

        Task<bool> DeleteAsync(int stockAdjustmentId);
    }
}
