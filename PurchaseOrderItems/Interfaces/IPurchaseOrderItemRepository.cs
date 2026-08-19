using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.PurchaseOrderItems.Interfaces
{
    public interface IPurchaseOrderItemRepository
    {
        Task<IEnumerable<PurchaseOrderItem>> GetAllAsync();

        Task<PurchaseOrderItem?> GetByIdAsync(int purchaseOrderItemId);

        Task<PurchaseOrderItem?> GetByPurchaseOrderAndItemIdAsync(
            int purchaseOrderId,
            int purchaseOrderItemId);
        Task<IEnumerable<PurchaseOrderItem>> GetByPurchaseOrderIdAsync(
    int purchaseOrderId);
        Task<IEnumerable<PurchaseOrderItem>> GetByPurchaseOrdersAsync(
            int sellerId,
            int customerId,
            List<int> purchaseOrderIds);

        Task AddAsync(PurchaseOrderItem item);

        Task UpdateAsync(PurchaseOrderItem item);

        Task DeleteAsync(int purchaseOrderItemId);

        Task SaveChangesAsync();
    }
}