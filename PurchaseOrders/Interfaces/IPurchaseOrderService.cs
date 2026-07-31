using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.PurchaseOrders.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrder>> GetAllAsync();

        Task<PurchaseOrder?> GetByIdAsync(int purchaseOrderId);

        Task<IEnumerable<PurchaseOrder>> GetBySellerIdAsync(int sellerId);

        Task<IEnumerable<PurchaseOrder>> GetBySupplierIdAsync(int supplierId);

  

        Task<PurchaseOrder?> GetBySellerSupplierAndPurchaseOrderIdAsync(
            int sellerId,
            int supplierId,
            int purchaseOrderId);

        Task<PurchaseOrder> CreateAsync(PurchaseOrder purchaseOrder);

        Task<bool> UpdateAsync(
            int purchaseOrderId,
            PurchaseOrder purchaseOrder);

        Task<bool> DeleteAsync(int purchaseOrderId);
    }
}