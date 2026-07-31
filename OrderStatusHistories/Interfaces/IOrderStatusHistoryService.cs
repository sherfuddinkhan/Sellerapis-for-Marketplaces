using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.OrderStatusHistories.Interfaces
{
    public interface IOrderStatusHistoryService
    {
        Task<IEnumerable<OrderStatusHistory>> GetAllAsync();

        Task<OrderStatusHistory?> GetByIdAsync(int historyId);

        Task<IEnumerable<OrderStatusHistory>> GetByOrderIdAsync(int orderId);

        Task<IEnumerable<OrderStatusHistory>> GetByStatusAsync(string status);

        Task<OrderStatusHistory> CreateAsync(OrderStatusHistory history);

        Task<bool> UpdateAsync(int historyId, OrderStatusHistory history);

        Task<bool> DeleteAsync(int historyId);
    }
}
