using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Sellers.Interfaces
{
    public interface ISellerService
    {
        Task<IEnumerable<Seller>> GetAllAsync();
        Task<Seller?> GetByIdAsync(int id);
        Task<Seller> CreateAsync(Seller seller);
        Task UpdateAsync(Seller seller);
        Task DeleteAsync(int id);
    }
}