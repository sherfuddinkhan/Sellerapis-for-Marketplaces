using Marketplacesellerportal.Models;
using Marketplacesellerportal.Warehouses.DTOs;

namespace Marketplacesellerportal.Warehouses.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>>
            GetAllAsync();

        Task<Warehouse?>
            GetByIdAsync(
                int warehouseId);

        Task<Warehouse?>
            GetWarehouseAsync(
                int sellerId,
                int customerId,
                int warehouseId);

        Task<IEnumerable<Warehouse>>
            GetBySellerIdAsync(
                int sellerId);

        Task<IEnumerable<Warehouse>>
            GetByCustomerIdAsync(
                int customerId);

        Task<IEnumerable<Warehouse>>
            GetBySellerCustomerAsync(
                int sellerId,
                int customerId);

        Task<IEnumerable<Warehouse>>
            GetByCityAsync(
                string city);

        Task<IEnumerable<Warehouse>>
            GetByStateAsync(
                string state);

        Task<IEnumerable<Warehouse>>
            SearchAsync(
                string? search,
                string? status);

        Task<WarehouseStatistics>
            GetStatisticsAsync();

        Task<WarehouseFilters>
            GetFiltersAsync();

        Task<(
            IEnumerable<Warehouse> Items,
            int TotalCount)>
            GetPagedAsync(
                int page,
                int limit);

        Task<IEnumerable<Warehouse>>
            GetSortedAsync(
                string? sort);

        Task AddAsync(
            Warehouse warehouse);

        Task UpdateAsync(
            Warehouse warehouse);

        Task DeleteAsync(
            int warehouseId);

        Task SaveChangesAsync();
    }
}