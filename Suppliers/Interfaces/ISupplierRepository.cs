using Marketplacesellerportal.Models;
using Marketplacesellerportal.Suppliers.DTOs;

namespace Marketplacesellerportal.Suppliers.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();

        Task<Supplier?> GetByIdAsync(int supplierId);

        Task<IEnumerable<Supplier>> GetBySellerIdAsync(int sellerId);
        Task<IEnumerable<Supplier>> SearchAsync(string search);

        Task<IEnumerable<Supplier>> GetSortedAsync(string? sort);

        Task<PagedResult<Supplier>> GetPagedAsync(
            int page,
            int limit);

        Task<SupplierStatistics> GetStatisticsAsync();
        Task<Supplier?> GetSupplierAsync(int sellerId, int supplierId);

        Task AddAsync(Supplier supplier);

        Task UpdateAsync(Supplier supplier);
        Task<IEnumerable<Supplier>> GetBySellerCustomerAsync(int sellerId,int customerId);
        Task DeleteAsync(int supplierId);

        Task SaveChangesAsync();
    }
}
