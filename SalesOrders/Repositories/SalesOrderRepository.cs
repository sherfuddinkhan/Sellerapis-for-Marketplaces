using Microsoft.EntityFrameworkCore;
using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrders.DTOs;
using Marketplacesellerportal.SalesOrders.Interfaces;

namespace Marketplacesellerportal.SalesOrders.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // GET ALL
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> GetAllAsync()
        {
            return await _context.SalesOrders
                .AsNoTracking()
                .ToListAsync();
        }

        // =====================================================
        // GET BY ID
        // =====================================================

        public async Task<SalesOrder?> GetByIdAsync(int id)
        {
            return await _context.SalesOrders
                .FirstOrDefaultAsync(x =>
                    x.SalesOrderId == id);
        }

        // =====================================================
        // GET BY SELLER
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> GetBySellerAsync(
            int sellerId)
        {
            return await _context.SalesOrders
                .AsNoTracking()
                .Where(x => x.SellerId == sellerId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY CUSTOMER
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> GetByCustomerAsync(
            int customerId)
        {
            return await _context.SalesOrders
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        // =====================================================
        // GET BY STATUS
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> GetByStatusAsync(
            string status)
        {
            return await _context.SalesOrders
                .AsNoTracking()
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        // =====================================================
        // GET BY SALES ORDER NUMBER
        // =====================================================

        public async Task<SalesOrder?> GetBySalesOrderNumberAsync(
            string salesOrderNumber)
        {
            return await _context.SalesOrders
                .FirstOrDefaultAsync(x =>
                    x.SalesOrderNumber == salesOrderNumber);
        }

        // =====================================================
        // SEARCH
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> SearchAsync(
            string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return await GetAllAsync();

            search = search.Trim();

            return await _context.SalesOrders
                .AsNoTracking()
                .Where(x =>
                    x.SalesOrderNumber.Contains(search) ||
                    x.Status.Contains(search) ||
                    x.Remarks.Contains(search))
                .ToListAsync();
        }

        // =====================================================
        // SORT
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> GetSortedAsync(
            string? sort)
        {
            var query = _context.SalesOrders
                .AsNoTracking()
                .AsQueryable();

            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query
                    .OrderByDescending(x => x.SalesOrderId)
                    .ToListAsync();
            }

            switch (sort.ToLower())
            {
                case "salesorderid":
                case "id":
                    query = query
                        .OrderBy(x => x.SalesOrderId);
                    break;

                case "salesordernumber":
                case "number":
                    query = query
                        .OrderBy(x => x.SalesOrderNumber);
                    break;

                case "orderdate":
                case "date":
                    query = query
                        .OrderByDescending(x => x.OrderDate);
                    break;

                case "status":
                    query = query
                        .OrderBy(x => x.Status);
                    break;

                case "totalamount":
                case "amount":
                    query = query
                        .OrderByDescending(x => x.TotalAmount);
                    break;

                case "sellerid":
                    query = query
                        .OrderBy(x => x.SellerId);
                    break;

                case "customerid":
                    query = query
                        .OrderBy(x => x.CustomerId);
                    break;

                default:
                    query = query
                        .OrderByDescending(x => x.SalesOrderId);
                    break;
            }

            return await query.ToListAsync();
        }

        // =====================================================
        // PAGINATION
        // =====================================================

        public async Task<PagedResult<SalesOrder>> GetPagedAsync(
    int page,
    int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 15;

            var query = _context.SalesOrders
                .AsNoTracking()
                .OrderByDescending(x => x.SalesOrderId);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return new PagedResult<SalesOrder>
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                Items = items
            };
        }
        public async Task<IEnumerable<SalesOrder>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
        {
            return await _context.SalesOrders
                .AsNoTracking()
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .OrderByDescending(x => x.SalesOrderId)
                .ToListAsync();
        }

        // =====================================================
        // STATISTICS
        // =====================================================

        public async Task<SalesOrderStatistics> GetStatisticsAsync()
        {
            var query = _context.SalesOrders
                .AsNoTracking();

            var totalOrders = await query.CountAsync();

            var totalAmount = await query
                .Select(x => (decimal?)x.TotalAmount)
                .SumAsync() ?? 0;

            var pendingOrders = await query
                .CountAsync(x => x.Status == "Pending");

            var confirmedOrders = await query
                .CountAsync(x => x.Status == "Confirmed");

            var completedOrders = await query
                .CountAsync(x => x.Status == "Completed");

            var cancelledOrders = await query
                .CountAsync(x => x.Status == "Cancelled");

            return new SalesOrderStatistics
            {
                TotalOrders = totalOrders,
                TotalAmount = totalAmount,
                PendingOrders = pendingOrders,
                ConfirmedOrders = confirmedOrders,
                CompletedOrders = completedOrders,
                CancelledOrders = cancelledOrders
            };
        }

        // =====================================================
        // CREATE
        // =====================================================

        public async Task AddAsync(
            SalesOrder salesOrder)
        {
            await _context.SalesOrders.AddAsync(salesOrder);
        }

        // =====================================================
        // UPDATE
        // =====================================================

        public async Task UpdateAsync(
            SalesOrder salesOrder)
        {
            _context.SalesOrders.Update(salesOrder);

            await Task.CompletedTask;
        }

        // =====================================================
        // DELETE
        // =====================================================

        public async Task DeleteAsync(int id)
        {
            var salesOrder = await _context.SalesOrders
                .FirstOrDefaultAsync(x =>
                    x.SalesOrderId == id);

            if (salesOrder != null)
            {
                _context.SalesOrders.Remove(salesOrder);
            }
        }

        // =====================================================
        // SAVE
        // =====================================================

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}