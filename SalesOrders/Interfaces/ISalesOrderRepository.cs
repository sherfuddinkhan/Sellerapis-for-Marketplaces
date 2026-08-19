using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesOrders.Interfaces
{
    public interface ISalesOrderRepository
    {
        Task<IEnumerable<SalesOrder>> GetAllAsync();

        Task<SalesOrder?> GetByIdAsync(int salesOrderId);

        Task<IEnumerable<SalesOrder>> GetBySellerAsync(int sellerId);

        Task<IEnumerable<SalesOrder>> GetByCustomerAsync(int customerId);

        Task<IEnumerable<SalesOrder>> GetByStatusAsync(string status);

        Task<SalesOrder?> GetBySalesOrderNumberAsync(string salesOrderNumber);
        Task<IEnumerable<SalesOrder>> GetBySellerCustomerAsync(int sellerId,int customerId);
        Task AddAsync(SalesOrder salesOrder);

        Task UpdateAsync(SalesOrder salesOrder);

        Task DeleteAsync(int salesOrderId);

        Task SaveChangesAsync();
    }
}
