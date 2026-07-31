using Marketplacesellerportal.Models;

public interface IPurchaseOrderRepository
{
    Task<IEnumerable<PurchaseOrder>> GetAllAsync();

    Task<PurchaseOrder?> GetByIdAsync(int purchaseOrderId);

    Task<IEnumerable<PurchaseOrder>> GetBySellerIdAsync(int sellerId);

    Task<IEnumerable<PurchaseOrder>> GetBySupplierIdAsync(int supplierId);

    Task<PurchaseOrder?> GetBySellerAndPurchaseOrderIdAsync(
        int sellerId,
        int purchaseOrderId);

    Task<PurchaseOrder?> GetBySellerSupplierAndPurchaseOrderIdAsync(
        int sellerId,
        int supplierId,
        int purchaseOrderId);

    Task AddAsync(PurchaseOrder purchaseOrder);

    Task UpdateAsync(PurchaseOrder purchaseOrder);

    Task DeleteAsync(int purchaseOrderId);

    Task SaveChangesAsync();
}
