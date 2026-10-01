using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SaleOrderAddresses.Interfaces
{
    public interface ISaleOrderAddressService
    {
        Task<List<SaleOrderAddress>> GetAllAsync();
        Task<SaleOrderAddress?> GetByIdAsync(int id);
        Task<SaleOrderAddress> CreateAsync(SaleOrderAddress entity);
        Task<bool> UpdateAsync(int id, SaleOrderAddress entity);
        Task<bool> DeleteAsync(int id);
    }
}
