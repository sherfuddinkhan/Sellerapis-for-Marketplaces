using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.StockTransfers.Interfaces
{
    public interface IStockTransferRepository
    {
        // =====================================================
        // GET ALL
        // =====================================================

        Task<IEnumerable<StockTransfer>> GetAllAsync();


        // =====================================================
        // GET BY ID
        // =====================================================

        Task<StockTransfer?> GetByIdAsync(
            int stockTransferId);


        // =====================================================
        // GET BY SELLER
        // =====================================================

        Task<IEnumerable<StockTransfer>> GetBySellerIdAsync(
            int sellerId);


        // =====================================================
        // GET BY PRODUCT
        // =====================================================

        Task<IEnumerable<StockTransfer>> GetByProductIdAsync(
            int productId);


        // =====================================================
        // GET BY FROM WAREHOUSE
        // =====================================================

        Task<IEnumerable<StockTransfer>> GetByFromWarehouseIdAsync(
            int fromWarehouseId);


        // =====================================================
        // GET BY TO WAREHOUSE
        // =====================================================

        Task<IEnumerable<StockTransfer>> GetByToWarehouseIdAsync(
            int toWarehouseId);


        // =====================================================
        // GET BY STATUS
        // =====================================================

        Task<IEnumerable<StockTransfer>> GetByStatusAsync(
            string status);


        // =====================================================
        // GET BY SELLER + CUSTOMER
        // =====================================================

        Task<IEnumerable<StockTransfer>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);


        // =====================================================
        // GET STOCK TRANSFER
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

        Task AddAsync(
            StockTransfer stockTransfer);


        // =====================================================
        // UPDATE
        // =====================================================

        Task UpdateAsync(
            StockTransfer stockTransfer);


        // =====================================================
        // DELETE
        // =====================================================

        Task DeleteAsync(
            int stockTransferId);


        // =====================================================
        // SAVE CHANGES
        // =====================================================

        Task SaveChangesAsync();
    }
}