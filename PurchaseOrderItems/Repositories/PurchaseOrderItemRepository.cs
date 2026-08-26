using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrderItems.DTOs;
using Marketplacesellerportal.PurchaseOrderItems.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marketplacesellerportal.PurchaseOrderItems.Repositories
{
    public class PurchaseOrderItemRepository : IPurchaseOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderItemRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // GET ALL
        // GET: /api/purchase-order-items
        // =====================================================

        public async Task<IEnumerable<PurchaseOrderItem>> GetAllAsync()
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        // =====================================================
        // GET BY ID
        // GET: /api/purchase-order-items/{id}
        // =====================================================

        public async Task<PurchaseOrderItem?> GetByIdAsync(
            int purchaseOrderItemId)
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderItemId == purchaseOrderItemId);
        }

        // =====================================================
        // GET BY PURCHASE ORDER
        // GET:
        // /api/purchase-order-items/purchase-order/{purchaseOrderId}
        // =====================================================

        public async Task<IEnumerable<PurchaseOrderItem>>
            GetByPurchaseOrderIdAsync(
                int purchaseOrderId)
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .AsNoTracking()
                .Where(x =>
                    x.PurchaseOrderId == purchaseOrderId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY PURCHASE ORDER + ITEM
        // =====================================================

        public async Task<PurchaseOrderItem?>
            GetByPurchaseOrderAndItemIdAsync(
                int purchaseOrderId,
                int purchaseOrderItemId)
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x =>
                    x.PurchaseOrderId == purchaseOrderId &&
                    x.PurchaseOrderItemId == purchaseOrderItemId);
        }

        // =====================================================
        // GET BY SELLER + CUSTOMER + PURCHASE ORDERS
        // =====================================================

        public async Task<IEnumerable<PurchaseOrderItem>>
            GetByPurchaseOrdersAsync(
                int sellerId,
                int customerId,
                List<int> purchaseOrderIds)
        {
            return await _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId &&
                    purchaseOrderIds.Contains(
                        x.PurchaseOrderId))
                .ToListAsync();
        }

        // =====================================================
        // SEARCH
        // GET:
        // /api/purchase-order-items?search=sku-882
        // =====================================================
        public async Task<IEnumerable<PurchaseOrderItem>>
            SearchAsync(string? search)
        {
            var query = _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    (x.Product != null &&
                     x.Product.SKU != null &&
                     x.Product.SKU.Contains(search))
                    ||
                    (x.Product != null &&
                     x.Product.ProductName != null &&
                     x.Product.ProductName.Contains(search))
                );
            }

            return await query.ToListAsync();
        }
        // =====================================================
        // STATISTICS
        // GET:
        // /api/purchase-order-items/stats
        // =====================================================

        public async Task<PurchaseOrderItemStatistics>
            GetStatisticsAsync()
        {
            var query = _context.PurchaseOrderItems
                .AsNoTracking();

            var statistics =
                new PurchaseOrderItemStatistics
                {
                    TotalItems =
                        await query.CountAsync(),

                    DistinctPurchaseOrders =
                        await query
                            .Select(x => x.PurchaseOrderId)
                            .Distinct()
                            .CountAsync(),

                    DistinctProducts =
                        await query
                            .Select(x => x.ProductId)
                            .Distinct()
                            .CountAsync(),

                    TotalQuantity =
                        await query
                            .Select(x => (decimal?)x.Quantity)
                            .SumAsync() ?? 0,

                    TotalAmount =
                        await query
                            .Select(x => (decimal?)x.TotalAmount)
                            .SumAsync() ?? 0
                };

            return statistics;
        }

        // =====================================================
        // PAGINATION
        // GET:
        // /api/purchase-order-items?page=1&limit=25
        // =====================================================

        public async Task<(
            IEnumerable<PurchaseOrderItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 10;

            if (limit > 100)
                limit = 100;

            var query = _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .AsNoTracking();

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderByDescending(x =>
                        x.PurchaseOrderItemId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (
                items,
                totalCount
            );
        }

        // =====================================================
        // SORTING
        // GET:
        // /api/purchase-order-items?sort=line_no
        // =====================================================

        // =====================================================
        // SORTING
        // GET:
        // /api/purchase-order-items?sort=line_no
        // =====================================================

        public async Task<IEnumerable<PurchaseOrderItem>>
            GetSortedAsync(string? sort)
        {
            var query = _context.PurchaseOrderItems
                .Include(x => x.PurchaseOrder)
                .Include(x => x.Product)
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                // -------------------------------------------------
                // LINE NUMBER ASC
                // PurchaseOrderItemId used because
                // PurchaseOrderItem has no LineNumber property
                // -------------------------------------------------

                case "line_no":
                case "line_no_asc":

                    query = query.OrderBy(x =>
                        x.PurchaseOrderItemId);

                    break;

                // -------------------------------------------------
                // LINE NUMBER DESC
                // -------------------------------------------------

                case "line_no_desc":

                    query = query.OrderByDescending(x =>
                        x.PurchaseOrderItemId);

                    break;

                // -------------------------------------------------
                // QUANTITY ASC
                // -------------------------------------------------

                case "quantity_asc":

                    query = query.OrderBy(x =>
                        x.Quantity);

                    break;

                // -------------------------------------------------
                // QUANTITY DESC
                // -------------------------------------------------

                case "quantity_desc":

                    query = query.OrderByDescending(x =>
                        x.Quantity);

                    break;

                // -------------------------------------------------
                // AMOUNT ASC
                // -------------------------------------------------

                case "amount_asc":

                    query = query.OrderBy(x =>
                        x.TotalAmount);

                    break;

                // -------------------------------------------------
                // AMOUNT DESC
                // -------------------------------------------------

                case "amount_desc":

                    query = query.OrderByDescending(x =>
                        x.TotalAmount);

                    break;

                // -------------------------------------------------
                // DEFAULT
                // -------------------------------------------------

                default:

                    query = query.OrderByDescending(x =>
                        x.PurchaseOrderItemId);

                    break;
            }

            return await query.ToListAsync();
        }
        // =====================================================
        // CREATE
        // =====================================================

        public async Task AddAsync(
            PurchaseOrderItem item)
        {
            await _context.PurchaseOrderItems
                .AddAsync(item);
        }

        // =====================================================
        // UPDATE
        // =====================================================

        public Task UpdateAsync(
            PurchaseOrderItem item)
        {
            _context.PurchaseOrderItems
                .Update(item);

            return Task.CompletedTask;
        }

        // =====================================================
        // DELETE
        // =====================================================

        public async Task DeleteAsync(
            int purchaseOrderItemId)
        {
            var item =
                await _context.PurchaseOrderItems
                    .FirstOrDefaultAsync(x =>
                        x.PurchaseOrderItemId ==
                        purchaseOrderItemId);

            if (item != null)
            {
                _context.PurchaseOrderItems
                    .Remove(item);
            }
        }

        // =====================================================
        // SAVE CHANGES
        // =====================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}