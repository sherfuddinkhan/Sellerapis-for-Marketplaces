using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.StockLedgers.DTOs;
using Marketplacesellerportal.StockLedgers.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marketplacesellerportal.StockLedgers.Repositories
{
    public class StockLedgerRepository : IStockLedgerRepository
    {
        private readonly ApplicationDbContext _context;

        public StockLedgerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockLedger>> GetAllAsync()
        {
            return await _context.StockLedgers.ToListAsync();
        }

        public async Task<StockLedger?> GetByIdAsync(int stockLedgerId)
        {
            return await _context.StockLedgers
                .FirstOrDefaultAsync(x => x.StockLedgerId == stockLedgerId);
        }

        public async Task<IEnumerable<StockLedger>> GetBySellerIdAsync(int sellerId)
        {
            return await _context.StockLedgers
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }
        // =========================================================
        // GET STOCK LEDGER BY SELLER + CUSTOMER
        // =========================================================
        public async Task<IEnumerable<StockLedger>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId)
        {
            return await _context.StockLedgers
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderBy(x => x.StockLedgerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<StockLedger>> GetByProductIdAsync(int productId)
        {
            return await _context.StockLedgers
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockLedger>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.StockLedgers
                .Where(x => x.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockLedger>> GetByTransactionTypeAsync(string transactionType)
        {
            return await _context.StockLedgers
                .Where(x => x.TransactionType == transactionType)
                .ToListAsync();
        }

        public async Task<StockLedger?> GetStockLedgerAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int stockLedgerId)
        {
            return await _context.StockLedgers.FirstOrDefaultAsync(x =>
                x.SellerId == sellerId &&
                x.ProductId == productId &&
                x.WarehouseId == warehouseId &&
                x.StockLedgerId == stockLedgerId);
        }

        public async Task AddAsync(StockLedger stockLedger)
        {
            await _context.StockLedgers.AddAsync(stockLedger);
        }

        public Task UpdateAsync(StockLedger stockLedger)
        {
            _context.StockLedgers.Update(stockLedger);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int stockLedgerId)
        {
            var entity = await GetByIdAsync(stockLedgerId);

            if (entity != null)
                _context.StockLedgers.Remove(entity);
        }
        
// =========================================================
// GET BY CUSTOMER
//
// GET /api/stock-ledgers/customer/{customerId}
// =========================================================

public async Task<IEnumerable<StockLedger>>
    GetByCustomerIdAsync(int customerId)
        {
            return await _context.StockLedgers
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }
        
// =========================================================
// SEARCH + TRANSACTION TYPE FILTER
//
// Examples:
//
// /api/stock-ledgers?search=PO-001
//
// /api/stock-ledgers?search=PO-001&transactionType=Purchase
//
// /api/stock-ledgers?transactionType=Purchase
// =========================================================

public async Task<IEnumerable<StockLedger>>
    SearchAsync(
        string? search,
        string? transactionType)
        {
            var query = _context.StockLedgers
                .AsNoTracking()
                .AsQueryable();

            // =====================================================
            // SEARCH
            // =====================================================

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    (x.ReferenceNumber != null &&
                     x.ReferenceNumber.Contains(search))

                    ||

                    (x.TransactionType != null &&
                     x.TransactionType.Contains(search))

                    ||

                    (x.Remarks != null &&
                     x.Remarks.Contains(search))
                );
            }

            // =====================================================
            // TRANSACTION TYPE FILTER
            // =====================================================

            if (!string.IsNullOrWhiteSpace(transactionType))
            {
                transactionType = transactionType.Trim();

                query = query.Where(x =>
                    x.TransactionType == transactionType);
            }

            // =====================================================
            // RESULT
            // =====================================================

            return await query
                .OrderByDescending(x => x.TransactionDate)
                .ToListAsync();
        }
        
// =========================================================
// FILTERS
//
// GET /api/stock-ledgers/filters
// =========================================================

public async Task<StockLedgerFilters>
    GetFiltersAsync()
        {
            var transactionTypes =
                await _context.StockLedgers
                    .AsNoTracking()
                    .Where(x =>
                        x.TransactionType != null &&
                        x.TransactionType != "")
                    .Select(x => x.TransactionType)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var sellers =
                await _context.StockLedgers
                    .AsNoTracking()
                    .Select(x => x.SellerId)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var customers =
                await _context.StockLedgers
                    .AsNoTracking()
                    .Select(x => x.CustomerId)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var products =
                await _context.StockLedgers
                    .AsNoTracking()
                    .Select(x => x.ProductId)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            var warehouses =
                await _context.StockLedgers
                    .AsNoTracking()
                    .Select(x => x.WarehouseId)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToListAsync();

            return new StockLedgerFilters
            {
                TransactionTypes = transactionTypes,
                SellerIds = sellers,
                CustomerIds = customers,
                ProductIds = products,
                WarehouseIds = warehouses
            };
        }


        // =========================================================
        // PAGINATION
        //
        // GET /api/stock-ledgers?page=1&limit=25
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

            var query = _context.StockLedgers
                .AsNoTracking()
                .OrderByDescending(x => x.TransactionDate);

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (
                items,
                totalCount
            );
        }


        // =========================================================
        // SORTING
        //
        // Supported:
        //
        // quantity_asc
        // quantity_desc
        // date_asc
        // date_desc
        // balance_asc
        // balance_desc
        // =========================================================

        public async Task<IEnumerable<StockLedger>>
            GetSortedAsync(string? sort)
        {
            var query = _context.StockLedgers
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                // =====================================================
                // QUANTITY
                // =====================================================

                case "quantity_asc":

                    query = query
                        .OrderBy(x => x.Quantity);

                    break;


                case "quantity_desc":

                    query = query
                        .OrderByDescending(x => x.Quantity);

                    break;


                // =====================================================
                // DATE
                // =====================================================

                case "date_asc":

                    query = query
                        .OrderBy(x => x.TransactionDate);

                    break;


                case "date_desc":

                    query = query
                        .OrderByDescending(x => x.TransactionDate);

                    break;


                // =====================================================
                // BALANCE
                // =====================================================

                case "balance_asc":

                    query = query
                        .OrderBy(x => x.BalanceQuantity);

                    break;


                case "balance_desc":

                    query = query
                        .OrderByDescending(x => x.BalanceQuantity);

                    break;


                // =====================================================
                // DEFAULT
                // =====================================================

                default:

                    query = query
                        .OrderByDescending(x => x.TransactionDate);

                    break;
            }

            return await query.ToListAsync();
        }
// =========================================================
// STATISTICS
//
// GET /api/stock-ledgers/statistics
// =========================================================

public async Task<StockLedgerStatistics>
    GetStatisticsAsync()
        {
            var query = _context.StockLedgers
                .AsNoTracking();

            var totalRecords =
                await query.CountAsync();

            var totalQuantity =
                await query
                    .Select(x => (decimal?)x.Quantity)
                    .SumAsync() ?? 0;

            var totalBalanceQuantity =
                await query
                    .Select(x => (decimal?)x.BalanceQuantity)
                    .SumAsync() ?? 0;

            var purchaseCount =
                await query.CountAsync(x =>
                    x.TransactionType == "Purchase");

            var salesCount =
                await query.CountAsync(x =>
                    x.TransactionType == "Sale");

            var adjustmentCount =
                await query.CountAsync(x =>
                    x.TransactionType == "Adjustment");

            var transferCount =
                await query.CountAsync(x =>
                    x.TransactionType == "Transfer");

            var distinctProducts =
                await query
                    .Select(x => x.ProductId)
                    .Distinct()
                    .CountAsync();

            var distinctWarehouses =
                await query
                    .Select(x => x.WarehouseId)
                    .Distinct()
                    .CountAsync();

            var distinctSellers =
                await query
                    .Select(x => x.SellerId)
                    .Distinct()
                    .CountAsync();

            var distinctCustomers =
                await query
                    .Select(x => x.CustomerId)
                    .Distinct()
                    .CountAsync();

            return new StockLedgerStatistics
            {
                TotalRecords = totalRecords,

                TotalQuantity = totalQuantity,

                TotalBalanceQuantity =
                    totalBalanceQuantity,

                PurchaseCount = purchaseCount,

                SalesCount = salesCount,

                AdjustmentCount =
                    adjustmentCount,

                TransferCount =
                    transferCount,

                DistinctProducts =
                    distinctProducts,

                DistinctWarehouses =
                    distinctWarehouses,

                DistinctSellers =
                    distinctSellers,

                DistinctCustomers =
                    distinctCustomers
            };
        }



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
