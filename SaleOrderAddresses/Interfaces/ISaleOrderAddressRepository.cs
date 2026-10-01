using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Interfaces
{
    public interface ISaleOrderAddressRepository
    {
        Task<List<SaleOrderAddress>> GetAllAsync();
        Task<SaleOrderAddress?> GetByIdAsync(int id);
        Task<SaleOrderAddress> CreateAsync(SaleOrderAddress entity);
        Task<bool> UpdateAsync(SaleOrderAddress entity);
        Task<bool> DeleteAsync(int id);
    }
}
