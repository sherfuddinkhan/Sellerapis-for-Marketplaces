using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.PurchaseReturns.Interfaces
{
    public interface IPurchaseReturnService
    {
        Task<IEnumerable<PurchaseReturn>> GetAllAsync();

        Task<PurchaseReturn?> GetByIdAsync(int purchaseReturnId);

        Task<IEnumerable<PurchaseReturn>> GetByPurchaseOrderIdAsync(int purchaseOrderId);

        Task<IEnumerable<PurchaseReturn>> GetBySupplierIdAsync(int supplierId);

        Task<IEnumerable<PurchaseReturn>> GetByGoodsReceiptNoteIdAsync(int goodsReceiptNoteId);

        Task<IEnumerable<PurchaseReturn>> GetByStatusAsync(string status);

        Task<PurchaseReturn?> GetPurchaseReturnAsync(
            int purchaseOrderId,
            int supplierId,
            int purchaseReturnId);

        Task<PurchaseReturn> CreateAsync(PurchaseReturn purchaseReturn);

        Task<bool> UpdateAsync(int purchaseReturnId, PurchaseReturn purchaseReturn);

        Task<bool> DeleteAsync(int purchaseReturnId);
    }
}
