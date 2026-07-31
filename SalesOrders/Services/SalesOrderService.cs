using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrders.Interfaces;

namespace Marketplacesellerportal.SalesOrders.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly ISalesOrderRepository _repository;

        public SalesOrderService(ISalesOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SalesOrder>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SalesOrder?> GetByIdAsync(int salesOrderId)
        {
            return await _repository.GetByIdAsync(salesOrderId);
        }

        public async Task<IEnumerable<SalesOrder>> GetBySellerAsync(int sellerId)
        {
            return await _repository.GetBySellerAsync(sellerId);
        }

        public async Task<IEnumerable<SalesOrder>> GetByCustomerAsync(int customerId)
        {
            return await _repository.GetByCustomerAsync(customerId);
        }

        public async Task<IEnumerable<SalesOrder>> GetByStatusAsync(string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        public async Task<SalesOrder?> GetBySalesOrderNumberAsync(string salesOrderNumber)
        {
            return await _repository.GetBySalesOrderNumberAsync(salesOrderNumber);
        }

        public async Task<SalesOrder> CreateAsync(SalesOrder salesOrder)
        {
            salesOrder.CreatedDate = DateTime.Now;

            if (salesOrder.OrderDate == DateTime.MinValue)
                salesOrder.OrderDate = DateTime.Now;

            await _repository.AddAsync(salesOrder);
            await _repository.SaveChangesAsync();

            return salesOrder;
        }

        public async Task<bool> UpdateAsync(int salesOrderId, SalesOrder salesOrder)
        {
            var existing = await _repository.GetByIdAsync(salesOrderId);

            if (existing == null)
                return false;

            existing.SellerId = salesOrder.SellerId;
            existing.CustomerId = salesOrder.CustomerId;
            existing.SalesOrderNumber = salesOrder.SalesOrderNumber;
            existing.OrderDate = salesOrder.OrderDate;
            existing.Status = salesOrder.Status;
            existing.TotalAmount = salesOrder.TotalAmount;
            existing.Remarks = salesOrder.Remarks;
            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int salesOrderId)
        {
            var existing = await _repository.GetByIdAsync(salesOrderId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(salesOrderId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
