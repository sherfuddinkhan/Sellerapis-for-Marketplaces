using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockLedgers.DTOs;

namespace Marketplacesellerportal.StockLedgers.Interfaces
{
    public interface IStockLedgerService
    {
        // =========================================================
        // BASIC
        // =========================================================

        Task<IEnumerable<StockLedger>>
            GetAllAsync();

        Task<StockLedger?>
            GetByIdAsync(
                int stockLedgerId);


        // =========================================================
        // SELLER
        // =========================================================

        Task<IEnumerable<StockLedger>>
            GetBySellerIdAsync(
                int sellerId);


        // =========================================================
        // CUSTOMER
        // =========================================================

        Task<IEnumerable<StockLedger>>
            GetByCustomerIdAsync(
                int customerId);


        // =========================================================
        // PRODUCT
        // =========================================================

        Task<IEnumerable<StockLedger>>
            GetByProductIdAsync(
                int productId);


        // =========================================================
        // WAREHOUSE
        // =========================================================

        Task<IEnumerable<StockLedger>>
            GetByWarehouseIdAsync(
                int warehouseId);


        // =========================================================
        // SELLER + CUSTOMER
        // =========================================================

        Task<IEnumerable<StockLedger>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);


        // =========================================================
        // TRANSACTION TYPE
        // =========================================================

        Task<IEnumerable<StockLedger>>
            GetByTransactionTypeAsync(
                string transactionType);


        // =========================================================
        // SPECIFIC STOCK LEDGER
        // =========================================================

        Task<StockLedger?>
            GetStockLedgerAsync(
                int sellerId,
                int productId,
                int warehouseId,
                int stockLedgerId);


        // =========================================================
        // SEARCH
        //
        // GET
        // /api/stock-ledgers?search=PO-001
        //
        // /api/stock-ledgers?search=PO-001&transactionType=Purchase
        // =========================================================

        Task<IEnumerable<StockLedger>>
            SearchAsync(
                string? search,
                string? transactionType);


        // =========================================================
        // STATISTICS
        //
        // GET
        // /api/stock-ledgers/statistics
        // =========================================================

        Task<StockLedgerStatistics>
            GetStatisticsAsync();


        // =========================================================
        // FILTERS
        //
        // GET
        // /api/stock-ledgers/filters
        // =========================================================

        Task<StockLedgerFilters>
            GetFiltersAsync();


        // =========================================================
        // PAGINATION
        //
        // GET
        // /api/stock-ledgers?page=1&limit=25
        // =========================================================

        Task<(
            IEnumerable<StockLedger> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);


        // =========================================================
        // SORTING
        //
        // GET
        // /api/stock-ledgers?sort=quantity_asc
        //
        // Supported:
        // quantity_asc
        // quantity_desc
        // balance_asc
        // balance_desc
        // date_asc
        // date_desc
        // =========================================================

        Task<IEnumerable<StockLedger>>
            GetSortedAsync(
                string? sort);


        // =========================================================
        // CREATE
        // =========================================================

        Task<StockLedger>
            CreateAsync(
                StockLedger stockLedger);


        // =========================================================
        // UPDATE
        // =========================================================

        Task<bool>
            UpdateAsync(
                int stockLedgerId,
                StockLedger stockLedger);


        // =========================================================
        // DELETE
        // =========================================================

        Task<bool>
            DeleteAsync(
                int stockLedgerId);
    }
}