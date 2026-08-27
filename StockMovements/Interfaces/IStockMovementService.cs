using Marketplacesellerportal.Models;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockMovements.DTOs;
namespace Marketplacesellerportal.StockMovements.Interfaces
{
    public interface IStockMovementService
    {
        // =====================================================
        // GET ALL
        // =====================================================

        Task<IEnumerable<StockMovement>> GetAllAsync();

        // =====================================================
        // GET BY ID
        // =====================================================

        Task<StockMovement?> GetByIdAsync(
            int stockMovementId);

        // =====================================================
        // GET BY SELLER
        // =====================================================

        Task<IEnumerable<StockMovement>> GetBySellerIdAsync(
            int sellerId);

        // =====================================================
        // GET BY PRODUCT
        // =====================================================

        Task<IEnumerable<StockMovement>> GetByProductIdAsync(
            int productId);

        // =====================================================
        // GET BY WAREHOUSE
        // =====================================================

        Task<IEnumerable<StockMovement>> GetByWarehouseIdAsync(
            int warehouseId);

        // =====================================================
        // GET BY MOVEMENT TYPE
        // =====================================================

        Task<IEnumerable<StockMovement>> GetByMovementTypeAsync(
            string movementType);

        // =====================================================
        // GET BY SELLER + CUSTOMER
        // =====================================================

        Task<IEnumerable<StockMovement>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        // =====================================================
        // GET BY SELLER + PRODUCT + WAREHOUSE + ID
        // =====================================================

        Task<StockMovement?> GetStockMovementAsync(int sellerId,int productId,
            int warehouseId,
            int stockMovementId);

        // =====================================================
        // SEARCH
        // =====================================================

        Task<IEnumerable<StockMovement>> SearchAsync(string search);

        // =====================================================
        // SORT
        // =====================================================

        Task<IEnumerable<StockMovement>> GetSortedAsync(string? sort);

        // =====================================================
        // PAGINATION
        // =====================================================

        Task<PagedResult<StockMovement>> GetPagedAsync(int page,int limit);

        // =====================================================
        // STATISTICS
        // =====================================================

        Task<StockMovementStatistics> GetStatisticsAsync();

        // =====================================================
        // CREATE
        // =====================================================

        Task<StockMovement> CreateAsync(
            StockMovement stockMovement);

        // =====================================================
        // UPDATE
        // =====================================================

        Task<bool> UpdateAsync(
            int stockMovementId,
            StockMovement stockMovement);

        // =====================================================
        // DELETE
        // =====================================================

        Task<bool> DeleteAsync(
            int stockMovementId);
    }
}