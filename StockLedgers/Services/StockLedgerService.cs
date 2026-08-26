using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockLedgers.DTOs;
using Marketplacesellerportal.StockLedgers.Interfaces;

namespace Marketplacesellerportal.StockLedgers.Services
{
    public class StockLedgerService : IStockLedgerService
    {
        private readonly IStockLedgerRepository _repository;

        public StockLedgerService(
            IStockLedgerRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<StockLedger?>
            GetByIdAsync(
                int stockLedgerId)
        {
            return await _repository.GetByIdAsync(
                stockLedgerId);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _repository.GetBySellerIdAsync(
                sellerId);
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _repository.GetByCustomerIdAsync(
                customerId);
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            GetByProductIdAsync(
                int productId)
        {
            return await _repository.GetByProductIdAsync(
                productId);
        }

        // =========================================================
        // GET BY WAREHOUSE
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            GetByWarehouseIdAsync(
                int warehouseId)
        {
            return await _repository.GetByWarehouseIdAsync(
                warehouseId);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }

        // =========================================================
        // GET BY TRANSACTION TYPE
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            GetByTransactionTypeAsync(
                string transactionType)
        {
            return await _repository
                .GetByTransactionTypeAsync(
                    transactionType);
        }

        // =========================================================
        // GET SPECIFIC STOCK LEDGER
        // =========================================================

        public async Task<StockLedger?>
            GetStockLedgerAsync(
                int sellerId,
                int productId,
                int warehouseId,
                int stockLedgerId)
        {
            return await _repository
                .GetStockLedgerAsync(
                    sellerId,
                    productId,
                    warehouseId,
                    stockLedgerId);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            SearchAsync(
                string? search,
                string? transactionType)
        {
            return await _repository.SearchAsync(
                search,
                transactionType);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<StockLedgerStatistics>
            GetStatisticsAsync()
        {
            return await _repository
                .GetStatisticsAsync();
        }

        // =========================================================
        // FILTERS
        // =========================================================

        public async Task<StockLedgerFilters>
            GetFiltersAsync()
        {
            return await _repository
                .GetFiltersAsync();
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<StockLedger> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 25;

            if (limit > 100)
                limit = 100;

            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository.GetSortedAsync(
                sort);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<StockLedger>
            CreateAsync(
                StockLedger stockLedger)
        {
            stockLedger.CreatedDate =
                stockLedger.CreatedDate ??
                DateTime.Now;

            stockLedger.TransactionDate =
                stockLedger.TransactionDate ??
                DateTime.Now;

            await _repository.AddAsync(
                stockLedger);

            await _repository.SaveChangesAsync();

            return stockLedger;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int stockLedgerId,
                StockLedger stockLedger)
        {
            var existing =
                await _repository.GetByIdAsync(
                    stockLedgerId);

            if (existing == null)
                return false;

            existing.SellerId =
                stockLedger.SellerId;

            existing.CustomerId =
                stockLedger.CustomerId;

            existing.ProductId =
                stockLedger.ProductId;

            existing.WarehouseId =
                stockLedger.WarehouseId;

            existing.TransactionType =
                stockLedger.TransactionType;

            existing.ReferenceNumber =
                stockLedger.ReferenceNumber;

            existing.Quantity =
                stockLedger.Quantity;

            existing.BalanceQuantity =
                stockLedger.BalanceQuantity;

            existing.Remarks =
                stockLedger.Remarks;

            existing.TransactionDate =
                stockLedger.TransactionDate;

            await _repository.UpdateAsync(
                existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(
                int stockLedgerId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    stockLedgerId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                stockLedgerId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

