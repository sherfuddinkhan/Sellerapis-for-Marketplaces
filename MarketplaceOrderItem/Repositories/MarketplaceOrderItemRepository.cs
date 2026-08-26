using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.MarketplaceOrderItems.DTOs;
using Marketplacesellerportal.MarketplaceOrderItems.Interfaces;

namespace Marketplacesellerportal.MarketplaceOrderItems.Repositories
{
    public class MarketplaceOrderItemRepository
        : IMarketplaceOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MarketplaceOrderItemRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetAllAsync()
        {
            return await _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .ToListAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<MarketplaceOrderItem?>
            GetByIdAsync(
                int marketplaceOrderItemId)
        {
            return await _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.MarketplaceOrderItemId ==
                    marketplaceOrderItemId);
        }

        // =========================================================
        // GET BY MARKETPLACE ORDER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetByMarketplaceOrderIdAsync(
                int marketplaceOrderId)
        {
            return await _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .Where(x =>
                    x.MarketplaceOrderId ==
                    marketplaceOrderId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY PRODUCT
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetByProductIdAsync(
                int productId)
        {
            return await _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .Where(x =>
                    x.ProductId == productId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .Where(x =>
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetByStatusAsync(
                string status)
        {
            return await _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .Where(x =>
                    x.Status != null &&
                    x.Status == status)
                .ToListAsync();
        }

        // =========================================================
        // SEARCH
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            SearchAsync(
                string? search,
                string? status)
        {
            var query = _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .AsQueryable();

            // -----------------------------------------------------
            // SEARCH
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    (x.MarketplaceOrderItemNumber != null &&
                     x.MarketplaceOrderItemNumber.Contains(search))

                    ||

                    (x.ExternalOrderItemId != null &&
                     x.ExternalOrderItemId.Contains(search))

                    ||

                    (x.ProductTitle != null &&
                     x.ProductTitle.Contains(search))

                    ||

                    (x.SKU != null &&
                     x.SKU.Contains(search)));
            }

            // -----------------------------------------------------
            // STATUS
            // -----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.Trim();

                query = query.Where(x =>
                    x.Status != null &&
                    x.Status == status);
            }

            return await query.ToListAsync();
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<MarketplaceOrderItemStatistics>
            GetStatisticsAsync()
        {
            var query = _context
                .MarketplaceOrderItems
                .AsNoTracking();

            return new MarketplaceOrderItemStatistics
            {
                TotalItems =
                    await query.CountAsync(),

                TotalQuantity =
                    await query
                        .SumAsync(x =>
                            (int?)x.Quantity) ?? 0,

                TotalUnitPrice =
                    await query
                        .SumAsync(x =>
                            (decimal?)x.UnitPrice) ?? 0,

                TotalTaxAmount =
                    await query
                        .SumAsync(x =>
                            (decimal?)x.TaxAmount) ?? 0,

                TotalShippingAmount =
                    await query
                        .SumAsync(x =>
                            (decimal?)x.ShippingAmount) ?? 0,

                TotalDiscountAmount =
                    await query
                        .SumAsync(x =>
                            (decimal?)x.DiscountAmount) ?? 0,

                TotalAmount =
                    await query
                        .SumAsync(x =>
                            (decimal?)x.TotalAmount) ?? 0,

                DistinctOrders =
                    await query
                        .Select(x =>
                            x.MarketplaceOrderId)
                        .Distinct()
                        .CountAsync(),

                DistinctProducts =
                    await query
                        .Where(x =>
                            x.ProductId.HasValue)
                        .Select(x =>
                            x.ProductId)
                        .Distinct()
                        .CountAsync(),

                DistinctListings =
                    await query
                        .Where(x =>
                            x.MarketplaceListingId.HasValue)
                        .Select(x =>
                            x.MarketplaceListingId)
                        .Distinct()
                        .CountAsync(),

                DistinctSellers =
                    await query
                        .Where(x =>
                            x.SellerId.HasValue)
                        .Select(x =>
                            x.SellerId)
                        .Distinct()
                        .CountAsync(),

                DistinctCustomers =
                    await query
                        .Where(x =>
                            x.CustomerId.HasValue)
                        .Select(x =>
                            x.CustomerId)
                        .Distinct()
                        .CountAsync(),

                PendingCount =
                    await query.CountAsync(x =>
                        x.Status == "pending"),

                ShippedCount =
                    await query.CountAsync(x =>
                        x.Status == "shipped"),

                DeliveredCount =
                    await query.CountAsync(x =>
                        x.Status == "delivered"),

                CancelledCount =
                    await query.CountAsync(x =>
                        x.Status == "cancelled")
            };
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<MarketplaceOrderItem> Items,
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

            var query = _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .OrderByDescending(x =>
                    x.MarketplaceOrderItemId);

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
        // =========================================================

        public async Task<IEnumerable<MarketplaceOrderItem>>
            GetSortedAsync(
                string? sort)
        {
            var query = _context
                .MarketplaceOrderItems
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "id_asc":

                    query = query
                        .OrderBy(x =>
                            x.MarketplaceOrderItemId);

                    break;

                case "id_desc":

                    query = query
                        .OrderByDescending(x =>
                            x.MarketplaceOrderItemId);

                    break;

                case "date_asc":

                    query = query
                        .OrderBy(x =>
                            x.CreatedDate);

                    break;

                case "date_desc":

                    query = query
                        .OrderByDescending(x =>
                            x.CreatedDate);

                    break;

                case "amount_asc":

                    query = query
                        .OrderBy(x =>
                            x.TotalAmount);

                    break;

                case "amount_desc":

                    query = query
                        .OrderByDescending(x =>
                            x.TotalAmount);

                    break;

                case "quantity_asc":

                    query = query
                        .OrderBy(x =>
                            x.Quantity);

                    break;

                case "quantity_desc":

                    query = query
                        .OrderByDescending(x =>
                            x.Quantity);

                    break;

                case "status_asc":

                    query = query
                        .OrderBy(x =>
                            x.Status);

                    break;

                case "status_desc":

                    query = query
                        .OrderByDescending(x =>
                            x.Status);

                    break;

                default:

                    query = query
                        .OrderByDescending(x =>
                            x.MarketplaceOrderItemId);

                    break;
            }

            return await query.ToListAsync();
        }

        // =========================================================
        // ADD
        // =========================================================

        public async Task AddAsync(
            MarketplaceOrderItem item)
        {
            await _context
                .MarketplaceOrderItems
                .AddAsync(item);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public Task UpdateAsync(
            MarketplaceOrderItem item)
        {
            _context
                .MarketplaceOrderItems
                .Update(item);

            return Task.CompletedTask;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task DeleteAsync(
            int marketplaceOrderItemId)
        {
            var entity =
                await _context
                    .MarketplaceOrderItems
                    .FirstOrDefaultAsync(x =>
                        x.MarketplaceOrderItemId ==
                        marketplaceOrderItemId);

            if (entity != null)
            {
                _context
                    .MarketplaceOrderItems
                    .Remove(entity);
            }
        }

        // =========================================================
        // SAVE
        // =========================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
