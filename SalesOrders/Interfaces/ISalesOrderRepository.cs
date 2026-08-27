using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrders.DTOs;

namespace Marketplacesellerportal.SalesOrders.Interfaces
{
    public interface ISalesOrderRepository
    {
        Task<IEnumerable<SalesOrder>> GetAllAsync();

        Task<SalesOrder?> GetByIdAsync(int id);

        Task<IEnumerable<SalesOrder>> GetBySellerAsync(
            int sellerId);

        Task<IEnumerable<SalesOrder>> GetByCustomerAsync(
            int customerId);

        Task<IEnumerable<SalesOrder>> GetByStatusAsync(
            string status);

        Task<SalesOrder?> GetBySalesOrderNumberAsync(
            string salesOrderNumber);

        // SEARCH
        Task<IEnumerable<SalesOrder>> SearchAsync(
            string search);

        // SORT
        Task<IEnumerable<SalesOrder>> GetSortedAsync(
            string? sort);

        // PAGINATION
        Task<PagedResult<SalesOrder>> GetPagedAsync(
            int page,
            int limit);

        // STATISTICS
        Task<SalesOrderStatistics> GetStatisticsAsync();

        // CRUD
        Task AddAsync(SalesOrder salesOrder);

        Task UpdateAsync(SalesOrder salesOrder);
        Task<IEnumerable<SalesOrder>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId);
        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}