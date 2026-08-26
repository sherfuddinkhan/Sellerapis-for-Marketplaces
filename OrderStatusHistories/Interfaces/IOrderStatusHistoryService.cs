using Marketplacesellerportal.Models;
using Marketplacesellerportal.OrderStatusHistories.DTOs;

namespace Marketplacesellerportal.OrderStatusHistories.Interfaces
{
    public interface IOrderStatusHistoryService
    {
        Task<IEnumerable<OrderStatusHistory>> GetAllAsync();

        Task<OrderStatusHistory?> GetByIdAsync(int historyId);

        Task<IEnumerable<OrderStatusHistory>> GetByOrderIdAsync(int orderId);

        Task<IEnumerable<OrderStatusHistory>> GetByStatusAsync(string status);

        Task<OrderStatusHistory> CreateAsync(OrderStatusHistory history);
        Task<IEnumerable<OrderStatusHistory>> SearchAsync(
    string? search);

        Task<OrderStatusHistoryStatistics>
            GetStatisticsAsync();

        Task<(
            IEnumerable<OrderStatusHistory> Items,
            int TotalCount)>
            GetPagedByOrderIdAsync(
                int orderId,
                int page,
                int limit);

        Task<IEnumerable<OrderStatusHistory>>
            GetSortedAsync(
                string? sort);
        Task<bool> UpdateAsync(int historyId, OrderStatusHistory history);

        Task<bool> DeleteAsync(int historyId);
    }
}
