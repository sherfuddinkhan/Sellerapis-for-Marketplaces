using Marketplacesellerportal.Models;
using Marketplacesellerportal.Warehouses.Interfaces;

namespace Marketplacesellerportal.Warehouses.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _repository;

        public WarehouseService(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Warehouse?> GetByIdAsync(int warehouseId)
        {
            return await _repository.GetByIdAsync(warehouseId);
        }

        public async Task<IEnumerable<Warehouse>> GetBySellerIdAsync(int sellerId)
        {
            return await _repository.GetBySellerIdAsync(sellerId);
        }

        public async Task<Warehouse?> GetWarehouseAsync(int sellerId, int warehouseId)
        {
            return await _repository.GetWarehouseAsync(sellerId, warehouseId);
        }

        public async Task<Warehouse> CreateAsync(Warehouse warehouse)
        {
            warehouse.CreatedDate = DateTime.Now;

            await _repository.AddAsync(warehouse);
            await _repository.SaveChangesAsync();

            return warehouse;
        }

        public async Task<bool> UpdateAsync(int warehouseId, Warehouse warehouse)
        {
            var existing = await _repository.GetByIdAsync(warehouseId);

            if (existing == null)
                return false;

            existing.WarehouseCode = warehouse.WarehouseCode;
            existing.WarehouseName = warehouse.WarehouseName;
            existing.AddressLine1 = warehouse.AddressLine1;
            existing.AddressLine2 = warehouse.AddressLine2;
            existing.City = warehouse.City;
            existing.State = warehouse.State;
            existing.Country = warehouse.Country;
            existing.PostalCode = warehouse.PostalCode;
            existing.ContactPerson = warehouse.ContactPerson;
            existing.Phone = warehouse.Phone;
            existing.Email = warehouse.Email;
            existing.IsActive = warehouse.IsActive;
            existing.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int warehouseId)
        {
            var existing = await _repository.GetByIdAsync(warehouseId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(warehouseId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
