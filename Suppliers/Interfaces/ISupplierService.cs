using Marketplacesellerportal.Models;
using Marketplacesellerportal.Suppliers.DTOs;

namespace Marketplacesellerportal.Suppliers.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllAsync();

        Task<Supplier?> GetByIdAsync(int supplierId);

        Task<IEnumerable<Supplier>> GetBySellerIdAsync(int sellerId);

        Task<Supplier?> GetSupplierAsync(int sellerId, int supplierId);
        Task<IEnumerable<Supplier>> SearchAsync(string search);

        Task<IEnumerable<Supplier>> GetSortedAsync(string? sort);

        Task<PagedResult<Supplier>> GetPagedAsync(
            int page,
            int limit);

        Task<SupplierStatistics> GetStatisticsAsync();
        Task<Supplier> CreateAsync(Supplier supplier);

        Task<bool> UpdateAsync(int supplierId, Supplier supplier);

        Task<bool> DeleteAsync(int supplierId);
    }
}
