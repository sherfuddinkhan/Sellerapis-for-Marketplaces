using Marketplacesellerportal.Models;
using Marketplacesellerportal.PurchaseOrderItems.Interfaces;

namespace Marketplacesellerportal.PurchaseOrderItems.Services
{
    public class PurchaseOrderItemService : IPurchaseOrderItemService
    {
        private readonly IPurchaseOrderItemRepository _repository;

        public PurchaseOrderItemService(IPurchaseOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PurchaseOrderItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PurchaseOrderItem?> GetByIdAsync(int purchaseOrderItemId)
        {
            return await _repository.GetByIdAsync(purchaseOrderItemId);
        }

        public async Task<IEnumerable<PurchaseOrderItem>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _repository.GetByPurchaseOrderIdAsync(purchaseOrderId);
        }

        public async Task<PurchaseOrderItem?> GetByPurchaseOrderAndItemIdAsync(
            int purchaseOrderId,
            int purchaseOrderItemId)
        {
            return await _repository.GetByPurchaseOrderAndItemIdAsync(
                purchaseOrderId,
                purchaseOrderItemId);
        }

        public async Task<PurchaseOrderItem> CreateAsync(PurchaseOrderItem item)
        {
            await _repository.AddAsync(item);
            await _repository.SaveChangesAsync();

            return item;
        }

        public async Task<bool> UpdateAsync(
            int purchaseOrderItemId,
            PurchaseOrderItem item)
        {
            var existing = await _repository.GetByIdAsync(purchaseOrderItemId);

            if (existing == null)
                return false;

            existing.ProductId = item.ProductId;
            existing.Quantity = item.Quantity;
            existing.UnitPrice = item.UnitPrice;
            existing.Discount = item.Discount;
            existing.TaxAmount = item.TaxAmount;
            existing.TotalAmount = item.TotalAmount;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int purchaseOrderItemId)
        {
            var existing = await _repository.GetByIdAsync(purchaseOrderItemId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(purchaseOrderItemId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
