using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesOrderItems.Interfaces
{
    public interface ISalesOrderItemRepository
    {
        Task<IEnumerable<SalesOrderItem>> GetAllAsync();

        Task<SalesOrderItem?> GetByIdAsync(int salesOrderItemId);

        Task<IEnumerable<SalesOrderItem>> GetBySalesOrderAsync(int salesOrderId);

        Task<IEnumerable<SalesOrderItem>> GetByProductAsync(int productId);
        Task<IEnumerable<SalesOrderItem>> GetBySalesOrderIdAsync(int productId);

        Task AddAsync(SalesOrderItem salesOrderItem);
        Task<IEnumerable<SalesOrderItem>> GetBySalesOrdersAsync(
    List<int> salesOrderIds);
        Task UpdateAsync(SalesOrderItem salesOrderItem);

        Task DeleteAsync(int salesOrderItemId);
       
        Task SaveChangesAsync();
    }
}