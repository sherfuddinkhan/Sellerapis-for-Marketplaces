using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SupplierAddresses.Interfaces
{
    public interface ISupplierAddressRepository
    {
        Task<List<SupplierAddress>> GetAllAsync();
        Task<SupplierAddress?> GetByIdAsync(int id);
        Task<SupplierAddress> CreateAsync(SupplierAddress entity);
        Task<bool> UpdateAsync(SupplierAddress entity);
        Task<bool> DeleteAsync(int id);
    }
}
