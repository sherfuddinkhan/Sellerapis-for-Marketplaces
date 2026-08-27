using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.StockTransfers.Interfaces
{
    public interface IStockTransferService
    {
        Task<IEnumerable<StockTransfer>> GetAllAsync();

        Task<StockTransfer?> GetByIdAsync(
            int stockTransferId);

        Task<IEnumerable<StockTransfer>> GetBySellerIdAsync(
            int sellerId);

        Task<IEnumerable<StockTransfer>> GetByProductIdAsync(
            int productId);

        Task<IEnumerable<StockTransfer>> GetByFromWarehouseIdAsync(
            int fromWarehouseId);

        Task<IEnumerable<StockTransfer>> GetByToWarehouseIdAsync(
            int toWarehouseId);

        Task<IEnumerable<StockTransfer>> GetByStatusAsync(
            string status);

        // =====================================================
        // SELLER + CUSTOMER
        // =====================================================

        Task<IEnumerable<StockTransfer>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        // =====================================================
        // SELLER + PRODUCT + STOCK TRANSFER
        // =====================================================

        Task<StockTransfer?> GetStockTransferAsync(
            int sellerId,
            int productId,
            int stockTransferId);

        // =====================================================
        // SEARCH
        // =====================================================

        Task<IEnumerable<StockTransfer>> SearchAsync(
            string search);

        // =====================================================
        // SORT
        // =====================================================

        Task<IEnumerable<StockTransfer>> GetSortedAsync(
            string? sort);

        // =====================================================
        // PAGINATION
        // =====================================================

        Task<PagedResult<StockTransfer>> GetPagedAsync(
            int page,
            int limit);

        // =====================================================
        // STATISTICS
        // =====================================================

        Task<StockTransferStatistics> GetStatisticsAsync();

        // =====================================================
        // CREATE
        // =====================================================

        Task<StockTransfer> CreateAsync(
            StockTransfer stockTransfer);

        // =====================================================
        // UPDATE
        // =====================================================

        Task<bool> UpdateAsync(
            int stockTransferId,
            StockTransfer stockTransfer);

        // =====================================================
        // DELETE
        // =====================================================

        Task<bool> DeleteAsync(
            int stockTransferId);
    }
}