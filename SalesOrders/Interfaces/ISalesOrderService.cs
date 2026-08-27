using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrders.DTOs;
namespace Marketplacesellerportal.SalesOrders.Interfaces
{
    public interface ISalesOrderService
    {
        Task<IEnumerable<SalesOrder>> GetAllAsync();

        Task<SalesOrder?> GetByIdAsync(
            int id);

        Task<IEnumerable<SalesOrder>> GetBySellerAsync(
            int sellerId);
        Task<IEnumerable<SalesOrder>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId);
        Task<IEnumerable<SalesOrder>> GetByCustomerAsync(
            int customerId);

        Task<IEnumerable<SalesOrder>> GetByStatusAsync(
            string status);

        Task<SalesOrder?> GetBySalesOrderNumberAsync(
            string salesOrderNumber);

        Task<IEnumerable<SalesOrder>> SearchAsync(
            string search);

        Task<IEnumerable<SalesOrder>> GetSortedAsync(
            string? sort);

        Task<PagedResult<SalesOrder>> GetPagedAsync(
            int page,
            int limit);

        Task<SalesOrderStatistics> GetStatisticsAsync();

        Task<SalesOrder> CreateAsync(
            SalesOrder salesOrder);

        Task<bool> UpdateAsync(
            int id,
            SalesOrder salesOrder);

        Task<bool> DeleteAsync(
            int id);
    }
}