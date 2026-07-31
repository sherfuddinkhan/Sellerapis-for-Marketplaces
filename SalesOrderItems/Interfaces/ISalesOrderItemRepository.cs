using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesOrderItems.Interfaces
{
    public interface ISalesOrderItemRepository
    {
        Task<IEnumerable<SalesOrderItem>> GetAllAsync();

        Task<SalesOrderItem?> GetByIdAsync(int salesOrderItemId);

        Task<IEnumerable<SalesOrderItem>> GetBySalesOrderAsync(int salesOrderId);

        Task<IEnumerable<SalesOrderItem>> GetByProductAsync(int productId);

        Task AddAsync(SalesOrderItem salesOrderItem);

        Task UpdateAsync(SalesOrderItem salesOrderItem);

        Task DeleteAsync(int salesOrderItemId);

        Task SaveChangesAsync();
    }
}
