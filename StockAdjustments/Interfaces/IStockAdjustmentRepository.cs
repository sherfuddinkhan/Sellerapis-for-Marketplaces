using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockAdjustments.DTOs;

namespace Marketplacesellerportal.StockAdjustments.Interfaces
{
    public interface IStockAdjustmentRepository
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

        // =====================================================
        // SELLER + CUSTOMER
        // =====================================================

        Task<IEnumerable<StockAdjustment>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        // =====================================================
        // SEARCH
        // =====================================================

        Task<IEnumerable<StockAdjustment>> SearchAsync(
            string search);

        // =====================================================
        // SORT
        // =====================================================

        Task<IEnumerable<StockAdjustment>> GetSortedAsync(
            string? sort);

        // =====================================================
        // PAGINATION
        // =====================================================

        Task<PagedResult<StockAdjustment>> GetPagedAsync(
            int page,
            int limit);

        // =====================================================
        // STATISTICS
        // =====================================================

        Task<StockAdjustmentStatistics> GetStatisticsAsync();

        // =====================================================
        // CRUD
        // =====================================================

        Task AddAsync(
            StockAdjustment stockAdjustment);

        Task UpdateAsync(
            StockAdjustment stockAdjustment);

        Task DeleteAsync(
            int stockAdjustmentId);

        Task SaveChangesAsync();
    }
}