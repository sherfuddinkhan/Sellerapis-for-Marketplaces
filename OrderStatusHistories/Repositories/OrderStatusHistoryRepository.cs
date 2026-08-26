using Marketplacesellerportal.Database;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.OrderStatusHistories.DTOs;
using Marketplacesellerportal.OrderStatusHistories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Marketplacesellerportal.OrderStatusHistories.Repositories
{
    public class OrderStatusHistoryRepository : IOrderStatusHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderStatusHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderStatusHistory>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
        {
            return await _context.OrderStatusHistories
                .Where(x =>
                    x.SellerId == sellerId &&
                    x.CustomerId == customerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<OrderStatusHistory>> GetAllAsync()
        {
            return await _context.OrderStatusHistories.ToListAsync();
        }

        public async Task<OrderStatusHistory?> GetByIdAsync(int historyId)
        {
            return await _context.OrderStatusHistories
                .FirstOrDefaultAsync(x => x.OrderStatusHistoryId == historyId);
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderStatusHistories
                .Where(x => x.OrderId == orderId)
                .OrderByDescending(x => x.ChangedOn)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetByStatusAsync(string status)
        {
            return await _context.OrderStatusHistories
                .Where(x => x.Status == status)
                .ToListAsync();
        }
       
        public async Task AddAsync(OrderStatusHistory history)
        {
            await _context.OrderStatusHistories.AddAsync(history);
        }

        public Task UpdateAsync(OrderStatusHistory history)
        {
            _context.OrderStatusHistories.Update(history);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int historyId)
        {
            var entity = await GetByIdAsync(historyId);

            if (entity != null)
                _context.OrderStatusHistories.Remove(entity);
        }
        public async Task<IEnumerable<OrderStatusHistory>> SearchAsync(
    string? search)
        {
            var query = _context.OrderStatusHistories
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    (x.Status != null &&
                     x.Status.Contains(search)) ||

                    (x.Remarks != null &&
                     x.Remarks.Contains(search)));
            }

            return await query.ToListAsync();
        }
        public async Task<OrderStatusHistoryStatistics> GetStatisticsAsync()
        {
            var query = _context.OrderStatusHistories
                .AsNoTracking();

            return new OrderStatusHistoryStatistics
            {
                TotalRecords =
                    await query.CountAsync(),

                DistinctOrders =
                    await query
                        .Select(x => x.OrderId)
                        .Distinct()
                        .CountAsync(),

                DistinctStatuses =
                    await query
                        .Where(x => x.Status != null)
                        .Select(x => x.Status)
                        .Distinct()
                        .CountAsync(),

                FirstChangedOn =
                    await query
                        .Select(x => x.ChangedOn)
                        .MinAsync(),

                LastChangedOn =
                    await query
                        .Select(x => x.ChangedOn)
                        .MaxAsync()
            };
        }
        public async Task<(
    IEnumerable<OrderStatusHistory> Items,
    int TotalCount)>
    GetPagedByOrderIdAsync(
        int orderId,
        int page,
        int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 10;

            if (limit > 100)
                limit = 100;

            var query = _context.OrderStatusHistories
                .AsNoTracking()
                .Where(x => x.OrderId == orderId);

            var totalCount =
                await query.CountAsync();

            var items =
                await query
                    .OrderByDescending(x => x.Timestamp)
                    .Skip((page - 1) * limit)
                    .Take(limit)
                    .ToListAsync();

            return (items, totalCount);
        }
        public async Task<IEnumerable<OrderStatusHistory>>
    GetSortedAsync(string? sort)
        {
            var query = _context.OrderStatusHistories
                .AsNoTracking()
                .AsQueryable();

            switch (sort?.ToLower())
            {
                case "timestamp_asc":

                    query = query
                        .OrderBy(x => x.Timestamp);

                    break;

                case "timestamp_desc":

                    query = query
                        .OrderByDescending(x => x.Timestamp);

                    break;

                case "status_asc":

                    query = query
                        .OrderBy(x => x.Status);

                    break;

                case "status_desc":

                    query = query
                        .OrderByDescending(x => x.Status);

                    break;

                default:

                    query = query
                        .OrderByDescending(x => x.Timestamp);

                    break;
            }

            return await query.ToListAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
