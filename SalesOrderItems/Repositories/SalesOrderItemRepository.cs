using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrderItems.Interfaces;
using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.SalesOrderItems.DTOs;
namespace Marketplacesellerportal.SalesOrderItems.Repositories
{
    public class SalesOrderItemRepository : ISalesOrderItemRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesOrderItem>> GetAllAsync()
        {
            return await _context.SalesOrderItems
                .ToListAsync();
        }
        public async Task<IEnumerable<SalesOrderItem>> GetBySalesOrderAsync(
    int salesOrderId)
        {
            return await _context.SalesOrderItems
                .Where(x => x.SalesOrderId == salesOrderId)
                .ToListAsync();
        }
        public async Task<IEnumerable<SalesOrderItem>> GetBySalesOrdersAsync(
    List<int> salesOrderIds)
        {
            return await _context.SalesOrderItems
                .Where(x => salesOrderIds.Contains(x.SalesOrderId))
                .ToListAsync();
        }
        public async Task<SalesOrderItem?> GetByIdAsync(int salesOrderItemId)
        {
            return await _context.SalesOrderItems
                .FirstOrDefaultAsync(x =>
                    x.SalesOrderItemId == salesOrderItemId);
        }
        public async Task<IEnumerable<SalesOrderItem>>
    SearchAsync(
        string? search)
        {
            var query = _context.SalesOrderItems
                .Include(x => x.SalesOrder)
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
        public async Task<IEnumerable<SalesOrderItem>> GetByProductAsync(
    int productId)
        {
            return await _context.SalesOrderItems
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }
        public async Task<IEnumerable<SalesOrderItem>> GetBySalesOrderIdAsync(
            int salesOrderId)
        {
            return await _context.SalesOrderItems
                .Where(x => x.SalesOrderId == salesOrderId)
                .ToListAsync();
        }
       
// =====================================================
// STATISTICS
// GET:
// /api/sales-order-items/stats
// =====================================================

public async Task<SalesOrderItemStatistics>
    GetStatisticsAsync()
        {
            var query = _context.SalesOrderItems
                .AsNoTracking();

            var statistics =
                new SalesOrderItemStatistics
                {
                    // Total number of order items
                    TotalItems =
                        await query.CountAsync(),

                    // Number of different sales orders
                    DistinctSalesOrders =
                        await query
                            .Select(x => x.SalesOrderId)
                            .Distinct()
                            .CountAsync(),

                    // Number of different products
                    DistinctProducts =
                        await query
                            .Select(x => x.ProductId)
                            .Distinct()
                            .CountAsync(),

                    // Total quantity
                    TotalQuantity =
                        await query
                            .Select(x => (decimal?)x.Quantity)
                            .SumAsync() ?? 0,

                    // Total amount
                    TotalAmount =
                        await query
                            .Select(x => (decimal?)x.TotalAmount)
                            .SumAsync() ?? 0,

                    // Total tax
                    TotalTaxAmount =
                        await query
                            .Select(x => (decimal?)x.TaxAmount)
                            .SumAsync() ?? 0,

                    // Total discount
                    TotalDiscount =
                        await query
                            .Select(x => (decimal?)x.Discount)
                            .SumAsync() ?? 0,

                    // Average unit price
                    AverageUnitPrice =
                        await query
                            .Select(x => (decimal?)x.UnitPrice)
                            .AverageAsync() ?? 0
                };

            return statistics;
        }


        // =====================================================
        // SORTING
        // GET:
        // /api/sales-order-items?sort=line_number
        // =====================================================

        public async Task<IEnumerable<SalesOrderItem>>
            GetSortedAsync(string? sort)
        {
            var query = _context.SalesOrderItems
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                // ---------------------------------------------
                // SALES ORDER ITEM ID ASC
                // ---------------------------------------------

                case "line_number":
                case "line_number_asc":
                case "id_asc":

                    query = query.OrderBy(x =>
                        x.SalesOrderItemId);

                    break;

                // ---------------------------------------------
                // SALES ORDER ITEM ID DESC
                // ---------------------------------------------

                case "line_number_desc":
                case "id_desc":

                    query = query.OrderByDescending(x =>
                        x.SalesOrderItemId);

                    break;

                // ---------------------------------------------
                // QUANTITY ASC
                // ---------------------------------------------

                case "quantity_asc":

                    query = query.OrderBy(x =>
                        x.Quantity);

                    break;

                // ---------------------------------------------
                // QUANTITY DESC
                // ---------------------------------------------

                case "quantity_desc":

                    query = query.OrderByDescending(x =>
                        x.Quantity);

                    break;

                // ---------------------------------------------
                // UNIT PRICE ASC
                // ---------------------------------------------

                case "unit_price_asc":

                    query = query.OrderBy(x =>
                        x.UnitPrice);

                    break;

                // ---------------------------------------------
                // UNIT PRICE DESC
                // ---------------------------------------------

                case "unit_price_desc":

                    query = query.OrderByDescending(x =>
                        x.UnitPrice);

                    break;

                // ---------------------------------------------
                // TOTAL AMOUNT ASC
                // ---------------------------------------------

                case "amount_asc":
                case "total_amount_asc":

                    query = query.OrderBy(x =>
                        x.TotalAmount);

                    break;

                // ---------------------------------------------
                // TOTAL AMOUNT DESC
                // ---------------------------------------------

                case "amount_desc":
                case "total_amount_desc":

                    query = query.OrderByDescending(x =>
                        x.TotalAmount);

                    break;

                // ---------------------------------------------
                // DEFAULT
                // ---------------------------------------------

                default:

                    query = query.OrderByDescending(x =>
                        x.SalesOrderItemId);

                    break;
            }

            return await query.ToListAsync();
        }


        public async Task<IEnumerable<SalesOrderItem>> GetByProductIdAsync(
            int productId)
        {
            return await _context.SalesOrderItems
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }
       
// =====================================================
// PAGINATION
// GET:
// /api/sales-order-items?page=1&limit=25
// =====================================================

public async Task<(
    IEnumerable<SalesOrderItem> Items,
    int TotalCount)>
    GetPagedAsync(
        int page,
        int limit)
        {
            // -------------------------------------------------
            // VALIDATE PAGE
            // -------------------------------------------------

            if (page < 1)
                page = 1;

            // -------------------------------------------------
            // VALIDATE LIMIT
            // -------------------------------------------------

            if (limit < 1)
                limit = 25;

            // Maximum records per request
            if (limit > 100)
                limit = 100;

            // -------------------------------------------------
            // QUERY
            // -------------------------------------------------

            var query = _context.SalesOrderItems
                .Include(x => x.SalesOrder)
                .Include(x => x.Product)
                .AsNoTracking();

            // -------------------------------------------------
            // TOTAL COUNT
            // -------------------------------------------------

            var totalCount =
                await query.CountAsync();

            // -------------------------------------------------
            // PAGED DATA
            // -------------------------------------------------

            var items =
                await query
                    .OrderByDescending(x =>
                        x.SalesOrderItemId)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            // -------------------------------------------------
            // RETURN
            // -------------------------------------------------

            return (
                items,
                totalCount
            );
        }


        public async Task AddAsync(SalesOrderItem salesOrderItem)
        {
            await _context.SalesOrderItems.AddAsync(salesOrderItem);
        }

        public Task UpdateAsync(SalesOrderItem salesOrderItem)
        {
            _context.SalesOrderItems.Update(salesOrderItem);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int salesOrderItemId)
        {
            var entity = await GetByIdAsync(salesOrderItemId);

            if (entity != null)
            {
                _context.SalesOrderItems.Remove(entity);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}