using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Marketplaces.Interfaces
{
    public interface IMarketplaceRepository
    {
        Task<IEnumerable<Marketplace>> GetAllAsync();

        Task<Marketplace?> GetByIdAsync(
            int marketplaceId);

        Task<Marketplace?> GetByCodeAsync(
            string marketplaceCode);

        Task<IEnumerable<Marketplace>> GetActiveAsync();

        Task<IEnumerable<Marketplace>> SearchAsync(
            string? search);

        Task<IEnumerable<Marketplace>> GetSortedAsync(
            string? sort);

        Task AddAsync(
            Marketplace marketplace);

        Task UpdateAsync(
            Marketplace marketplace);

        Task DeleteAsync(
            int marketplaceId);

        Task SaveChangesAsync();
    }
}
