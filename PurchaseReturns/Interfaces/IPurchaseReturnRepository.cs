using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.PurchaseReturns.Interfaces
{
    public interface IPurchaseReturnRepository
    {
        Task<IEnumerable<PurchaseReturn>> GetAllAsync();

        Task<PurchaseReturn?> GetByIdAsync(int purchaseReturnId);

        Task<IEnumerable<PurchaseReturn>> GetByPurchaseOrderIdAsync(int purchaseOrderId);

        Task<IEnumerable<PurchaseReturn>> GetBySupplierIdAsync(int supplierId);

        Task<IEnumerable<PurchaseReturn>> GetByGoodsReceiptNoteIdAsync(int goodsReceiptNoteId);
        Task<IEnumerable<PurchaseReturn>> GetBySellerCustomerAsync(
    int sellerId,
    int customerId);
        Task<IEnumerable<PurchaseReturn>> GetByStatusAsync(string status);

        Task<PurchaseReturn?> GetPurchaseReturnAsync(
            int purchaseOrderId,
            int supplierId,
            int purchaseReturnId);

        Task AddAsync(PurchaseReturn purchaseReturn);

        Task UpdateAsync(PurchaseReturn purchaseReturn);

        Task DeleteAsync(int purchaseReturnId);

        Task SaveChangesAsync();
    }
}
