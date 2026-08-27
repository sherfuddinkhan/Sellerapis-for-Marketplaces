using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockAdjustments.DTOs;

namespace Marketplacesellerportal.StockAdjustments.Interfaces
{
    public interface IStockAdjustmentService
    {
        Task<IEnumerable<StockAdjustment>> GetAllAsync();

        Task<StockAdjustment?> GetByIdAsync(
            int stockAdjustmentId);

        Task<IEnumerable<StockAdjustment>> GetBySellerIdAsync(
            int sellerId);

        Task<IEnumerable<StockAdjustment>> GetByProductIdAsync(
            int productId);

        Task<IEnumerable<StockAdjustment>> GetByWarehouseIdAsync(
            int warehouseId);

        Task<IEnumerable<StockAdjustment>> GetByAdjustmentTypeAsync(
            string adjustmentType);

        Task<StockAdjustment?> GetStockAdjustmentAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int stockAdjustmentId);

        Task<IEnumerable<StockAdjustment>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        // =====================================================
        // 4 NEW APIs
        // =====================================================

        Task<IEnumerable<StockAdjustment>> SearchAsync(
            string search);

        Task<IEnumerable<StockAdjustment>> GetSortedAsync(
            string? sort);

        Task<PagedResult<StockAdjustment>> GetPagedAsync(
            int page,
            int limit);

        Task<StockAdjustmentStatistics> GetStatisticsAsync();

        // =====================================================
        // CRUD
        // =====================================================

        Task<StockAdjustment> CreateAsync(
            StockAdjustment stockAdjustment);

        Task<bool> UpdateAsync(
            int stockAdjustmentId,
            StockAdjustment stockAdjustment);

        Task<bool> DeleteAsync(
            int stockAdjustmentId);
    }
}