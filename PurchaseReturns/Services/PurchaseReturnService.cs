using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseReturns.Interfaces;

namespace Marketplacesellerportal.PurchaseReturns.Services
{
    public class PurchaseReturnService : IPurchaseReturnService
    {
        private readonly IPurchaseReturnRepository _repository;

        public PurchaseReturnService(IPurchaseReturnRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PurchaseReturn>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PurchaseReturn?> GetByIdAsync(int purchaseReturnId)
        {
            return await _repository.GetByIdAsync(purchaseReturnId);
        }

        public async Task<IEnumerable<PurchaseReturn>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _repository.GetByPurchaseOrderIdAsync(purchaseOrderId);
        }

        public async Task<IEnumerable<PurchaseReturn>> GetBySupplierIdAsync(int supplierId)
        {
            return await _repository.GetBySupplierIdAsync(supplierId);
        }

        public async Task<IEnumerable<PurchaseReturn>> GetByGoodsReceiptNoteIdAsync(int goodsReceiptNoteId)
        {
            return await _repository.GetByGoodsReceiptNoteIdAsync(goodsReceiptNoteId);
        }

        public async Task<IEnumerable<PurchaseReturn>> GetByStatusAsync(string status)
        {
            return await _repository.GetByStatusAsync(status);
        }

        public async Task<PurchaseReturn?> GetPurchaseReturnAsync(
            int purchaseOrderId,
            int supplierId,
            int purchaseReturnId)
        {
            return await _repository.GetPurchaseReturnAsync(
                purchaseOrderId,
                supplierId,
                purchaseReturnId);
        }

        public async Task<PurchaseReturn> CreateAsync(PurchaseReturn purchaseReturn)
        {
            purchaseReturn.CreatedDate = DateTime.Now;

            if (purchaseReturn.ReturnDate == null)
                purchaseReturn.ReturnDate = DateTime.Now;

            if (string.IsNullOrWhiteSpace(purchaseReturn.Status))
                purchaseReturn.Status = "Pending";

            await _repository.AddAsync(purchaseReturn);
            await _repository.SaveChangesAsync();

            return purchaseReturn;
        }

        public async Task<bool> UpdateAsync(int purchaseReturnId, PurchaseReturn purchaseReturn)
        {
            var existing = await _repository.GetByIdAsync(purchaseReturnId);

            if (existing == null)
                return false;

            existing.PurchaseOrderId = purchaseReturn.PurchaseOrderId;
            existing.GoodsReceiptNoteId = purchaseReturn.GoodsReceiptNoteId;
            existing.SupplierId = purchaseReturn.SupplierId;
            existing.PurchaseReturnNumber = purchaseReturn.PurchaseReturnNumber;
            existing.ReturnDate = purchaseReturn.ReturnDate;
            existing.Reason = purchaseReturn.Reason;
            existing.TotalAmount = purchaseReturn.TotalAmount;
            existing.Status = purchaseReturn.Status;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int purchaseReturnId)
        {
            var existing = await _repository.GetByIdAsync(purchaseReturnId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(purchaseReturnId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
