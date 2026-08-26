using Marketplacesellerportal.Models;
using Marketplacesellerportal.Warehouses.DTOs;
using Marketplacesellerportal.Warehouses.Interfaces;

namespace Marketplacesellerportal.Warehouses.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _repository;

        public WarehouseService(
            IWarehouseRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<Warehouse?>
            GetByIdAsync(
                int warehouseId)
        {
            return await _repository.GetByIdAsync(
                warehouseId);
        }

        // =========================================================
        // GET BY SELLER
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetBySellerIdAsync(
                int sellerId)
        {
            return await _repository.GetBySellerIdAsync(
                sellerId);
        }

        // =========================================================
        // GET BY CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetByCustomerIdAsync(
                int customerId)
        {
            return await _repository.GetByCustomerIdAsync(
                customerId);
        }

        // =========================================================
        // GET BY SELLER + CUSTOMER
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId)
        {
            return await _repository.GetBySellerCustomerAsync(
                sellerId,
                customerId);
        }

        // =========================================================
        // GET BY CITY
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetByCityAsync(
                string city)
        {
            return await _repository.GetByCityAsync(
                city);
        }

        // =========================================================
        // GET BY STATE
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetByStateAsync(
                string state)
        {
            return await _repository.GetByStateAsync(
                state);
        }

        // =========================================================
        // GET SPECIFIC WAREHOUSE
        //
        // seller + customer + warehouse
        // =========================================================

        public async Task<Warehouse?>
            GetWarehouseAsync(
                int sellerId,
                int customerId,
                int warehouseId)
        {
            return await _repository.GetWarehouseAsync(
                sellerId,
                customerId,
                warehouseId);
        }

        // =========================================================
        // SEARCH + FILTER
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            SearchAsync(
                string? search,
                string? status)
        {
            return await _repository.SearchAsync(
                search,
                status);
        }

        // =========================================================
        // STATISTICS
        // =========================================================

        public async Task<WarehouseStatistics>
            GetStatisticsAsync()
        {
            return await _repository.GetStatisticsAsync();
        }

        // =========================================================
        // FILTERS
        // =========================================================

        public async Task<WarehouseFilters>
            GetFiltersAsync()
        {
            return await _repository.GetFiltersAsync();
        }

        // =========================================================
        // PAGINATION
        // =========================================================

        public async Task<(
            IEnumerable<Warehouse> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit)
        {
            if (page < 1)
                page = 1;

            if (limit < 1)
                limit = 10;

            if (limit > 100)
                limit = 100;

            return await _repository.GetPagedAsync(
                page,
                limit);
        }

        // =========================================================
        // SORTING
        // =========================================================

        public async Task<IEnumerable<Warehouse>>
            GetSortedAsync(
                string? sort)
        {
            return await _repository.GetSortedAsync(
                sort);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<Warehouse>
            CreateAsync(
                Warehouse warehouse)
        {
            warehouse.CreatedDate = DateTime.Now;

            await _repository.AddAsync(
                warehouse);

            await _repository.SaveChangesAsync();

            return warehouse;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        public async Task<bool>
            UpdateAsync(
                int warehouseId,
                Warehouse warehouse)
        {
            var existing =
                await _repository.GetByIdAsync(
                    warehouseId);

            if (existing == null)
                return false;

            existing.WarehouseCode =
                warehouse.WarehouseCode;

            existing.WarehouseName =
                warehouse.WarehouseName;

            existing.AddressLine1 =
                warehouse.AddressLine1;

            existing.AddressLine2 =
                warehouse.AddressLine2;

            existing.City =
                warehouse.City;

            existing.State =
                warehouse.State;

            existing.Country =
                warehouse.Country;

            existing.PostalCode =
                warehouse.PostalCode;

            existing.ContactPerson =
                warehouse.ContactPerson;

            existing.Phone =
                warehouse.Phone;

            existing.Email =
                warehouse.Email;

            existing.IsActive =
                warehouse.IsActive;

            existing.UpdatedDate =
                DateTime.Now;

            await _repository.UpdateAsync(
                existing);

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool>
            DeleteAsync(
                int warehouseId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    warehouseId);

            if (existing == null)
                return false;

            await _repository.DeleteAsync(
                warehouseId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}