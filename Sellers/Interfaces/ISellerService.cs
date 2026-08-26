using Marketplacesellerportal.Models;
using Marketplacesellerportal.Sellers.DTOs;

namespace Marketplacesellerportal.Sellers.Interfaces
{
    public interface ISellerService
    {
        Task<IEnumerable<Seller>> GetAllAsync();
        Task<Seller?> GetByIdAsync(int id);
        Task<Seller> CreateAsync(Seller seller);
        Task UpdateAsync(Seller seller);
        Task DeleteAsync(int id);
        Task<IEnumerable<Seller>> SearchAsync(string? search);
        Task<SellerStatistics> GetStatisticsAsync();
        Task<(IEnumerable<Seller> Items, int TotalCount)> GetPagedAsync(int page, int limit);
        Task<IEnumerable<Seller>> GetSortedAsync(string? sort); 
        Task<IEnumerable<Seller>> GetByStatusAsync(bool isActive);
    }
}