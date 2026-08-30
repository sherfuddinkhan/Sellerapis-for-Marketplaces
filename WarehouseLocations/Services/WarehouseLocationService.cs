using Marketplacesellerportal.Models;
using Marketplacesellerportal.WarehouseLocations.Interfaces;
using Marketplacesellerportal.WarehouseLocations.DTOs;
namespace Marketplacesellerportal.WarehouseLocations.Services
{
    public class WarehouseLocationService : IWarehouseLocationService
    {
        private readonly IWarehouseLocationRepository _repository;

        public WarehouseLocationService(IWarehouseLocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WarehouseLocation>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<IEnumerable<WarehouseLocation>>
    GetByCustomerIdAsync(int customerId)
        {
            return await _repository.GetByCustomerIdAsync(customerId);
        }

        public async Task<IEnumerable<WarehouseLocation>>
            GetByWarehouseCustomerAsync(
                int warehouseId,
                int customerId)
        {
            return await _repository.GetByWarehouseCustomerAsync(
                warehouseId,
                customerId);
        }
        public async Task<IEnumerable<WarehouseLocation>> SearchAsync(
    string search)
        {
            return await _repository.SearchAsync(search);
        }

        public async Task<IEnumerable<WarehouseLocation>> GetSortedAsync(
            string? sort)
        {
            return await _repository.GetSortedAsync(sort);
        }

        public async Task<PagedResult<WarehouseLocation>> GetPagedAsync(
            int page,
            int limit)
        {
            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        public async Task<WarehouseLocationStatistics> GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }
        public async Task<WarehouseLocation?> GetByIdAsync(int locationId)
        {
            return await _repository.GetByIdAsync(locationId);
        }

        public async Task<IEnumerable<WarehouseLocation>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _repository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<WarehouseLocation?> GetLocationAsync(int warehouseId, int locationId, int customerId)
        {
            return await _repository.GetLocationAsync(warehouseId, locationId, customerId);
        }

        public async Task<WarehouseLocation> CreateAsync(WarehouseLocation location)
        {
            location.CreatedDate = DateTime.Now;

            await _repository.AddAsync(location);
            await _repository.SaveChangesAsync();

            return location;
        }

        public async Task<bool> UpdateAsync(int locationId, WarehouseLocation location)
        {
            var existing = await _repository.GetByIdAsync(locationId);

            if (existing == null)
                return false;

            existing.LocationCode = location.LocationCode;
            existing.LocationName = location.LocationName;
            existing.Description = location.Description;
            existing.IsActive = location.IsActive;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int locationId)
        {
            var existing = await _repository.GetByIdAsync(locationId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(locationId);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
