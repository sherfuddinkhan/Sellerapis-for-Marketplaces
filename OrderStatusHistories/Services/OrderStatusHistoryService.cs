using Marketplacesellerportal.Models;
using Marketplacesellerportal.OrderStatusHistories.DTOs;
using Marketplacesellerportal.OrderStatusHistories.Interfaces;
using Marketplacesellerportal.OrderStatusHistories.Repositories;

namespace Marketplacesellerportal.OrderStatusHistories.Services
{
    public class OrderStatusHistoryService : IOrderStatusHistoryService
    {
        private readonly IOrderStatusHistoryRepository _repository;

        public OrderStatusHistoryService(IOrderStatusHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OrderStatusHistory?> GetByIdAsync(int orderStatusHistoryId)
        {
            return await _repository.GetByIdAsync(orderStatusHistoryId);
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetByOrderIdAsync(int orderId)
        {
            return await _repository.GetByOrderIdAsync(orderId);
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetByStatusAsync(string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        public async Task<OrderStatusHistory> CreateAsync(OrderStatusHistory history)
        {
            history.ChangedOn = DateTime.Now;

            await _repository.AddAsync(history);
            await _repository.SaveChangesAsync();

            return history;
        }
        public async Task<IEnumerable<OrderStatusHistory>>
    SearchAsync(string? search)
        {
            return await _repository.SearchAsync(search);
        }
        public async Task<OrderStatusHistoryStatistics>
    GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }
        public async Task<(
    IEnumerable<OrderStatusHistory> Items,
    int TotalCount)>
    GetPagedByOrderIdAsync(
        int orderId,
        int page,
        int limit)
        {
            return await _repository.GetPagedByOrderIdAsync(
                orderId,
                page,
                limit);
        }
        public async Task<IEnumerable<OrderStatusHistory>>
    GetSortedAsync(string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }
        public async Task<bool> UpdateAsync(
            int orderStatusHistoryId,
            OrderStatusHistory history)
        {
            var existing =
                await _repository.GetByIdAsync(orderStatusHistoryId);

            if (existing == null)
                return false;

            existing.OrderId = history.OrderId;
            existing.Status = history.Status;
            existing.Remarks = history.Remarks;
            existing.ChangedOn = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int orderStatusHistoryId)
        {
            var existing =
                await _repository.GetByIdAsync(orderStatusHistoryId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(orderStatusHistoryId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}