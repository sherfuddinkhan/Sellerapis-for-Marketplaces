
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesOrders.DTOs;
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

        // =====================================================
        // GET ALL
        // =====================================================
        public async Task<IEnumerable<SalesOrder>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }
        public async Task<IEnumerable<SalesOrder>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =====================================================
        // GET BY ID
        // =====================================================

        public async Task<SalesOrder?> GetByIdAsync(int salesOrderId)
        {
            return await _repository.GetByIdAsync(salesOrderId);
        }

        // =====================================================
        // GET BY SELLER
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> GetBySellerAsync(
            int sellerId)
        {
            return await _repository.GetBySellerAsync(sellerId);
        }

        // =====================================================
        // GET BY CUSTOMER
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> GetByCustomerAsync(
            int customerId)
        {
            return await _repository.GetByCustomerAsync(customerId);
        }

        // =====================================================
        // GET BY STATUS
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> GetByStatusAsync(
            string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        // =====================================================
        // GET BY SALES ORDER NUMBER
        // =====================================================

        public async Task<SalesOrder?> GetBySalesOrderNumberAsync(
            string salesOrderNumber)
        {
            return await _repository
                .GetBySalesOrderNumberAsync(salesOrderNumber);
        }

        // =====================================================
        // SEARCH
        // =====================================================
        // GET /api/sales-orders?search=SO-5520
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> SearchAsync(
            string search)
        {
            return await _repository.SearchAsync(search);
        }

        // =====================================================
        // SORT
        // =====================================================
        // GET /api/sales-orders?sort=order_date
        // =====================================================

        public async Task<IEnumerable<SalesOrder>> GetSortedAsync(
            string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }

        // =====================================================
        // PAGINATION
        // =====================================================
        // GET /api/sales-orders?page=1&limit=10
        // =====================================================

        public async Task<PagedResult<SalesOrder>> GetPagedAsync(
            int page,
            int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =====================================================
        // STATISTICS
        // =====================================================
        // GET /api/sales-orders/stats
        // =====================================================

        public async Task<SalesOrderStatistics> GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        // =====================================================
        // CREATE
        // =====================================================

        public async Task<SalesOrder> CreateAsync(
            SalesOrder salesOrder)
        {
            salesOrder.CreatedDate = DateTime.Now;

            if (salesOrder.OrderDate == DateTime.MinValue)
            {
                salesOrder.OrderDate = DateTime.Now;
            }

            await _repository.AddAsync(salesOrder);
            await _repository.SaveChangesAsync();

            return salesOrder;
        }

        // =====================================================
        // UPDATE
        // =====================================================

        public async Task<bool> UpdateAsync(
            int salesOrderId,
            SalesOrder salesOrder)
        {
            var existing =
                await _repository.GetByIdAsync(
                    salesOrderId);

            if (existing == null)
                return false;

            existing.SellerId =
                salesOrder.SellerId;

            existing.CustomerId =
                salesOrder.CustomerId;

            existing.SalesOrderNumber =
                salesOrder.SalesOrderNumber;

            existing.OrderDate =
                salesOrder.OrderDate;

            existing.Status =
                salesOrder.Status;

            existing.TotalAmount =
                salesOrder.TotalAmount;

            existing.Remarks =
                salesOrder.Remarks;

            existing.UpdatedDate =
                DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        // =====================================================
        // DELETE
        // =====================================================

        public async Task<bool> DeleteAsync(
            int salesOrderId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    salesOrderId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                salesOrderId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

