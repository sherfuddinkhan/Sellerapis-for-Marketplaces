using Marketplacesellerportal.Models;
using Marketplacesellerportal.ProductInventories.Interfaces;

namespace Marketplacesellerportal.ProductInventories.Services
{
    public class ProductInventoryService : IProductInventoryService
    {
        private readonly IProductInventoryRepository _repository;

        public ProductInventoryService(IProductInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductInventory>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductInventory?> GetByIdAsync(int productInventoryId)
        {
            return await _repository.GetByIdAsync(productInventoryId);
        }

        public async Task<IEnumerable<ProductInventory>> GetBySellerIdAsync(int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        public async Task<IEnumerable<ProductInventory>> GetByProductIdAsync(int productId)
        {
            return await _repository.GetByProductIdAsync(productId);
        }

        public async Task<IEnumerable<ProductInventory>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _repository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<ProductInventory?> GetInventoryAsync(
            int sellerId,
            int productId,
            int warehouseId,
            int locationId)
        {
            return await _repository.GetInventoryAsync(
                sellerId,
                productId,
                warehouseId,
                locationId);
        }

        public async Task<ProductInventory> CreateAsync(ProductInventory productInventory)
        {
            productInventory.CreatedDate = DateTime.Now;
            productInventory.LastStockUpdate = DateTime.Now;

            await _repository.AddAsync(productInventory);
            await _repository.SaveChangesAsync();

            return productInventory;
        }

        public async Task<bool> UpdateAsync(
            int productInventoryId,
            ProductInventory productInventory)
        {
            var existing = await _repository.GetByIdAsync(productInventoryId);

            if (existing == null)
                return false;

            existing.SellerId = productInventory.SellerId;
            existing.ProductId = productInventory.ProductId;
            existing.WarehouseId = productInventory.WarehouseId;
            existing.LocationId = productInventory.LocationId;
            existing.Quantity = productInventory.Quantity;
            existing.ReservedQuantity = productInventory.ReservedQuantity;
            existing.DamagedQuantity = productInventory.DamagedQuantity;
            existing.ReorderLevel = productInventory.ReorderLevel;
            existing.ReorderQuantity = productInventory.ReorderQuantity;
            existing.LastStockUpdate = DateTime.Now;
            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int productInventoryId)
        {
            var existing = await _repository.GetByIdAsync(productInventoryId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(productInventoryId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
