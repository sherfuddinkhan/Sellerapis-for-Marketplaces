using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SupplierAddresses.Interfaces
{
    public interface ISupplierAddressService
    {
        Task<List<SupplierAddress>> GetAllAsync();
        Task<SupplierAddress?> GetByIdAsync(int id);
        Task<SupplierAddress> CreateAsync(SupplierAddress entity);
        Task<bool> UpdateAsync(int id, SupplierAddress entity);
        Task<bool> DeleteAsync(int id);
    }
}
