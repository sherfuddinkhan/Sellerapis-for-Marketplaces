using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.MarketplaceReturns.Interfaces;
using Marketplacesellerportal.MarketplaceReturns.DTOs;

using MarketplaceReturnModel =
    Marketplacesellerportal.Models.MarketplaceReturn;

namespace Marketplacesellerportal.MarketplaceReturns.Repositories
{
    public class MarketplaceReturnRepository
        : IMarketplaceReturnRepository
    {
        private readonly ApplicationDbContext _context;

        public MarketplaceReturnRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetAllAsync()
        {
            return await _context.MarketplaceReturns
                .AsNoTracking()
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<MarketplaceReturnModel?>
            GetByIdAsync(
                int marketplaceReturnId)
        {
            return await _context.MarketplaceReturns
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.MarketplaceReturnId ==
                    marketplaceReturnId);
        }

        // =========================================================
        // GET BY MARKETPLACE ORDER ITEM
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetByMarketplaceOrderItemIdAsync(
                int marketplaceOrderItemId)
        {
            return await _context.MarketplaceReturns
                .AsNoTracking()
                .Where(x =>
                    x.MarketplaceOrderItemId ==
                    marketplaceOrderItemId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _context.MarketplaceReturns
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _context.MarketplaceReturns
                .AsNoTracking()
                .Where(x =>
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetByProductIdAsync(
                int productId)
        {
            return await _context.MarketplaceReturns
                .AsNoTracking()
                .Where(x =>
                    x.ProductId == productId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context.MarketplaceReturns
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetByStatusAsync(
                string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return await GetAllAsync();

            status = status.Trim();

            return await _context.MarketplaceReturns
                .AsNoTracking()
                .Where(x =>
                    x.ReturnStatus != null &&
                    x.ReturnStatus == status)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SKU
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetBySKUAsync(
                string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
                return Enumerable.Empty<MarketplaceReturnModel>();

            sku = sku.Trim();

            return await _context.MarketplaceReturns
                .AsNoTracking()
                .Where(x =>
                    x.SKU != null &&
                    x.SKU.Contains(sku))
                .ToListAsync();
        }

        // =========================================================
        // GET BY RETURN NUMBER
        // =========================================================

        public async Task<MarketplaceReturnModel?>
            GetByReturnNumberAsync(
                string returnNumber)
        {
            if (string.IsNullOrWhiteSpace(returnNumber))
                return null;

            return await _context.MarketplaceReturns
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.ReturnNumber == returnNumber);
        }

        // =========================================================
        // GET BY ORDER ITEM + RETURN
        // =========================================================

        public async Task<MarketplaceReturnModel?>
            GetMarketplaceReturnAsync(
                int marketplaceOrderItemId,
                int marketplaceReturnId)
        {
            return await _context.MarketplaceReturns
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.MarketplaceOrderItemId ==
                        marketplaceOrderItemId &&
                    x.MarketplaceReturnId ==
                        marketplaceReturnId);
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            SearchAsync(
                string? search)
        {
            var query = _context.MarketplaceReturns
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    (x.ReturnNumber != null &&
                     x.ReturnNumber.Contains(search)) ||

                    (x.ReturnReason != null &&
                     x.ReturnReason.Contains(search)) ||

                    (x.ReturnStatus != null &&
                     x.ReturnStatus.Contains(search)) ||

                    (x.SKU != null &&
                     x.SKU.Contains(search)));
            }

            return await query.ToListAsync();
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<MarketplaceReturnStatistics>
            GetStatisticsAsync()
        {
            var query = _context.MarketplaceReturns
                .AsNoTracking();

            return new MarketplaceReturnStatistics
            {
                TotalReturns =
                    await query.CountAsync(),

                TotalReturnedQuantity =
                    await query
                        .SumAsync(x =>
                            (int?)x.QuantityReturned) ?? 0,

                TotalRefundAmount =
                    await query
                        .SumAsync(x =>
                            (decimal?)x.RefundAmount) ?? 0,

                PendingReturns =
                    await query.CountAsync(x =>
                        x.ReturnStatus != null &&
                        x.ReturnStatus.ToLower() == "pending"),

                ApprovedReturns =
                    await query.CountAsync(x =>
                        x.ReturnStatus != null &&
                        x.ReturnStatus.ToLower() == "approved"),

                RejectedReturns =
                    await query.CountAsync(x =>
                        x.ReturnStatus != null &&
                        x.ReturnStatus.ToLower() == "rejected"),

                CompletedReturns =
                    await query.CountAsync(x =>
                        x.ReturnStatus != null &&
                        x.ReturnStatus.ToLower() == "completed"),

                DistinctSellers =
                    await query
                        .Select(x => x.SellerId)
                        .Distinct()
                        .CountAsync(),

                DistinctCustomers =
                    await query
                        .Select(x => x.CustomerId)
                        .Distinct()
                        .CountAsync(),

                DistinctProducts =
                    await query
                        .Select(x => x.ProductId)
                        .Distinct()
                        .CountAsync()
            };
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<MarketplaceReturnModel> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 20;

            if (limit > 100)
                limit = 100;

            var query = _context.MarketplaceReturns
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderByDescending(x =>
                        x.MarketplaceReturnId)
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
        // =========================================================

        public async Task<IEnumerable<MarketplaceReturnModel>>
            GetSortedAsync(
                string? sort)
        {
            var query = _context.MarketplaceReturns
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.Trim().ToLower())
            {
                case "date_asc":

                    query = query.OrderBy(x =>
                        x.ReturnDate);

                    break;

                case "date_desc":

                    query = query.OrderByDescending(x =>
                        x.ReturnDate);

                    break;

                case "amount_asc":

                    query = query.OrderBy(x =>
                        x.RefundAmount);

                    break;

                case "amount_desc":

                    query = query.OrderByDescending(x =>
                        x.RefundAmount);

                    break;

                case "quantity_asc":

                    query = query.OrderBy(x =>
                        x.QuantityReturned);

                    break;

                case "quantity_desc":

                    query = query.OrderByDescending(x =>
                        x.QuantityReturned);

                    break;

                case "status_asc":

                    query = query.OrderBy(x =>
                        x.ReturnStatus);

                    break;

                case "status_desc":

                    query = query.OrderByDescending(x =>
                        x.ReturnStatus);

                    break;

                case "return_number_asc":

                    query = query.OrderBy(x =>
                        x.ReturnNumber);

                    break;

                case "return_number_desc":

                    query = query.OrderByDescending(x =>
                        x.ReturnNumber);

                    break;

                default:

                    query = query.OrderByDescending(x =>
                        x.MarketplaceReturnId);

                    break;
            }

            return await query.ToListAsync();
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task AddAsync(
            MarketplaceReturnModel marketplaceReturn)
        {
            await _context.MarketplaceReturns
                .AddAsync(marketplaceReturn);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            MarketplaceReturnModel marketplaceReturn)
        {
            _context.MarketplaceReturns
                .Update(marketplaceReturn);

            return Task.CompletedTask;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(
            int marketplaceReturnId)
        {
            var entity =
                await _context.MarketplaceReturns
                    .FirstOrDefaultAsync(x =>
                        x.MarketplaceReturnId ==
                        marketplaceReturnId);

            if (entity != null)
            {
                _context.MarketplaceReturns
                    .Remove(entity);
            }
        }

        // =========================================================
        // SAVE CHANGES
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

