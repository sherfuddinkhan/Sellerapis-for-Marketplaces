using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesOrderItems.Interfaces
{
    public interface ISalesOrderItemService
    {
        Task<IEnumerable<SalesOrderItem>> GetAllAsync();

        Task<SalesOrderItem?> GetByIdAsync(int salesOrderItemId);

        Task<IEnumerable<SalesOrderItem>> GetBySalesOrderAsync(int salesOrderId);

        Task<IEnumerable<SalesOrderItem>> GetByProductAsync(int productId);

        Task<SalesOrderItem> CreateAsync(SalesOrderItem salesOrderItem);

        Task<bool> UpdateAsync(int salesOrderItemId, SalesOrderItem salesOrderItem);

        Task<bool> DeleteAsync(int salesOrderItemId);
    }
}
