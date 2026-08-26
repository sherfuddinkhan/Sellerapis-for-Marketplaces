using Marketplacesellerportal.Models;
using Marketplacesellerportal.Sellers.DTOs;
using Marketplacesellerportal.SharedKernel.Interfaces;

namespace Marketplacesellerportal.Sellers.Interfaces
{
    public interface ISellerRepository : IGenericRepository<Seller>
    {
        Task<Seller?> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(int sellerId);
        Task<IEnumerable<Seller>> SearchAsync(string? search); 
        Task<SellerStatistics> GetStatisticsAsync();
        Task<(IEnumerable<Seller> Items, int TotalCount)> GetPagedAsync(int page, int limit);
        Task<IEnumerable<Seller>> GetSortedAsync(string? sort);
        Task<IEnumerable<Seller>> GetByStatusAsync(bool isActive);
    }
}
