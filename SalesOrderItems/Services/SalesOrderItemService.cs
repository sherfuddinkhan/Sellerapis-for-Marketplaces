using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrderItems.Interfaces;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrderItems.DTOs;
using Marketplacesellerportal.SalesOrderItems.Interfaces;


namespace Marketplacesellerportal.SalesOrderItems.Services
{
    public class SalesOrderItemService : ISalesOrderItemService
    {
        private readonly ISalesOrderItemRepository _repository;

        public SalesOrderItemService(ISalesOrderItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<SalesOrderItem>> SearchAsync(
    string? search)
        {
            return await _repository.SearchAsync(search);
        }

        public async Task<SalesOrderItemStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        public async Task<(
            IEnumerable<SalesOrderItem> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        public async Task<IEnumerable<SalesOrderItem>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }
        public async Task<IEnumerable<SalesOrderItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SalesOrderItem?> GetByIdAsync(int salesOrderItemId)
        {
            return await _repository.GetByIdAsync(salesOrderItemId);
        }

        public async Task<IEnumerable<SalesOrderItem>> GetBySalesOrderAsync(int salesOrderId)
        {
            return await _repository.GetBySalesOrderAsync(salesOrderId);
        }

        public async Task<IEnumerable<SalesOrderItem>> GetByProductAsync(int productId)
        {
            return await _repository.GetByProductAsync(productId);
        }

        public async Task<SalesOrderItem> CreateAsync(SalesOrderItem salesOrderItem)
        {
            await _repository.AddAsync(salesOrderItem);
            await _repository.SaveChangesAsync();

            return salesOrderItem;
        }

        public async Task<bool> UpdateAsync(int salesOrderItemId, SalesOrderItem salesOrderItem)
        {
            var existing = await _repository.GetByIdAsync(salesOrderItemId);

            if (existing == null)
                return false;

            existing.SalesOrderId = salesOrderItem.SalesOrderId;
            existing.ProductId = salesOrderItem.ProductId;
            existing.Quantity = salesOrderItem.Quantity;
            existing.UnitPrice = salesOrderItem.UnitPrice;
            existing.Discount = salesOrderItem.Discount;
            existing.TaxAmount = salesOrderItem.TaxAmount;
            existing.TotalAmount = salesOrderItem.TotalAmount;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int salesOrderItemId)
        {
            var existing = await _repository.GetByIdAsync(salesOrderItemId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(salesOrderItemId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
