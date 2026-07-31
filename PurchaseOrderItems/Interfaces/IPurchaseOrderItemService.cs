using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.PurchaseOrderItems.Interfaces
{
    public interface IPurchaseOrderItemService
    {
        Task<IEnumerable<PurchaseOrderItem>> GetAllAsync();

        Task<PurchaseOrderItem?> GetByIdAsync(int purchaseOrderItemId);

        Task<IEnumerable<PurchaseOrderItem>> GetByPurchaseOrderIdAsync(int purchaseOrderId);

        Task<PurchaseOrderItem?> GetByPurchaseOrderAndItemIdAsync(
            int purchaseOrderId,
            int purchaseOrderItemId);

        Task<PurchaseOrderItem> CreateAsync(PurchaseOrderItem item);

        Task<bool> UpdateAsync(
            int purchaseOrderItemId,
            PurchaseOrderItem item);

        Task<bool> DeleteAsync(int purchaseOrderItemId);
    }
}