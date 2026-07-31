using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.PurchaseOrderItems.Interfaces
{
    public interface IPurchaseOrderItemRepository
    {
        Task<IEnumerable<PurchaseOrderItem>> GetAllAsync();

        Task<PurchaseOrderItem?> GetByIdAsync(int purchaseOrderItemId);

        Task<IEnumerable<PurchaseOrderItem>> GetByPurchaseOrderIdAsync(int purchaseOrderId);

        Task<PurchaseOrderItem?> GetByPurchaseOrderAndItemIdAsync(
            int purchaseOrderId,
            int purchaseOrderItemId);

        Task AddAsync(PurchaseOrderItem item);

        Task UpdateAsync(PurchaseOrderItem item);

        Task DeleteAsync(int purchaseOrderItemId);

        Task SaveChangesAsync();
    }
}
