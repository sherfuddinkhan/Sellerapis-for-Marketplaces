using Marketplacesellerportal.Models;
using Marketplacesellerportal.SharedKernel.Interfaces;

namespace Marketplacesellerportal.Sellers.Interfaces
{
    public interface ISellerRepository : IGenericRepository<Seller>
    {
        Task<Seller?> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(int sellerId);
    }
}
