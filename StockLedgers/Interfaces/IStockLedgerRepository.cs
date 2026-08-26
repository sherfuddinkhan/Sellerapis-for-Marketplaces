using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockLedgers.DTOs;

namespace Marketplacesellerportal.StockLedgers.Interfaces
{
    public interface IStockLedgerRepository
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<StockLedger>> GetAllAsync();

        Task<StockLedger?> GetByIdAsync(
            int stockLedgerId);


        // =========================================================
        // SELLER
        // =========================================================

        Task<IEnumerable<StockLedger>> GetBySellerIdAsync(
            int sellerId);


        // =========================================================
        // CUSTOMER
        // =========================================================

        Task<IEnumerable<StockLedger>> GetByCustomerIdAsync(
            int customerId);


        // =========================================================
        // PRODUCT
        // =========================================================

        Task<IEnumerable<StockLedger>> GetByProductIdAsync(
            int productId);


        // =========================================================
        // WAREHOUSE
        // =========================================================

        Task<IEnumerable<StockLedger>> GetByWarehouseIdAsync(
            int warehouseId);


        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<StockLedger>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);


        // =========================================================
        // TRANSACTION TYPE
        // =========================================================

        Task<IEnumerable<StockLedger>> GetByTransactionTypeAsync(
            string transactionType);


        // =========================================================
        // SPECIFIC STOCK LEDGER
        // =========================================================

        Task<StockLedger?> GetStockLedgerAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int stockLedgerId);


        // =========================================================
        // SEARCH
        // =========================================================

        Task<IEnumerable<StockLedger>> SearchAsync(
            string? search,
            string? transactionType);


        // =========================================================
        // STATISTICS
        // =========================================================

        Task<StockLedgerStatistics> GetStatisticsAsync();


        // =========================================================
        // FILTERS
        // =========================================================

        Task<StockLedgerFilters> GetFiltersAsync();


        // =========================================================
        // PAGINATION
        // =========================================================

        Task<(
            IEnumerable<StockLedger> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        // =========================================================

        Task<IEnumerable<StockLedger>> GetSortedAsync(
            string? sort);


        // =========================================================
        // CREATE
        // =========================================================

        Task AddAsync(
            StockLedger stockLedger);


        // =========================================================
        // UPDATE
        // =========================================================

        Task UpdateAsync(
            StockLedger stockLedger);


        // =========================================================
        // DELETE
        // =========================================================

        Task DeleteAsync(
            int stockLedgerId);


        // =========================================================
        // SAVE
        // =========================================================

        Task SaveChangesAsync();
    }
}

