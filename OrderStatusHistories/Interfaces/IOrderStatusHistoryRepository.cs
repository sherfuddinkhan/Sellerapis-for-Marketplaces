using Marketplacesellerportal.Models;
using Marketplacesellerportal.OrderStatusHistories.DTOs;
namespace Marketplacesellerportal.OrderStatusHistories.Interfaces
{
    public interface IOrderStatusHistoryRepository
    {
        Task<IEnumerable<OrderStatusHistory>> GetAllAsync();

        Task<OrderStatusHistory?> GetByIdAsync(int historyId);

        Task<IEnumerable<OrderStatusHistory>> GetByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderStatusHistory>> GetBySellerCustomerAsync(int sellerId,int customerId);
        Task<IEnumerable<OrderStatusHistory>> GetByStatusAsync(string status);

        Task AddAsync(OrderStatusHistory history);

        Task UpdateAsync(OrderStatusHistory history);

        Task DeleteAsync(int historyId);
        Task<IEnumerable<OrderStatusHistory>> SearchAsync(string? search);

        Task<OrderStatusHistoryStatistics> GetStatisticsAsync();

        Task<(IEnumerable<OrderStatusHistory> Items, int TotalCount)> GetPagedByOrderIdAsync(int orderId,int page,int limit);

        Task<IEnumerable<OrderStatusHistory>> GetSortedAsync(string? sort);
        Task SaveChangesAsync();
    }
}