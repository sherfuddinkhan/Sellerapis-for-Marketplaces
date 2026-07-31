using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Suppliers.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllAsync();

        Task<Supplier?> GetByIdAsync(int supplierId);

        Task<IEnumerable<Supplier>> GetBySellerIdAsync(int sellerId);

        Task<Supplier?> GetSupplierAsync(int sellerId, int supplierId);

        Task<Supplier> CreateAsync(Supplier supplier);

        Task<bool> UpdateAsync(int supplierId, Supplier supplier);

        Task<bool> DeleteAsync(int supplierId);
    }
}
