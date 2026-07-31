
using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesOrders.Interfaces
{
    public interface ISalesOrderService
    {
        Task<IEnumerable<SalesOrder>> GetAllAsync();

        Task<SalesOrder?> GetByIdAsync(int salesOrderId);

        Task<IEnumerable<SalesOrder>> GetBySellerAsync(int sellerId);

        Task<IEnumerable<SalesOrder>> GetByCustomerAsync(int customerId);

        Task<IEnumerable<SalesOrder>> GetByStatusAsync(string status);

        Task<SalesOrder?> GetBySalesOrderNumberAsync(string salesOrderNumber);

        Task<SalesOrder> CreateAsync(SalesOrder salesOrder);

        Task<bool> UpdateAsync(int salesOrderId, SalesOrder salesOrder);

        Task<bool> DeleteAsync(int salesOrderId);
    }
}
