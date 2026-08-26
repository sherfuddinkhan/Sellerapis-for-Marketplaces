using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Marketplaces.Interfaces
{
    public interface IMarketplaceService
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

        Task<Marketplace> CreateAsync(
            Marketplace marketplace);

        Task<bool> UpdateAsync(
            int marketplaceId,
            Marketplace marketplace);

        Task<bool> DeleteAsync(
            int marketplaceId);
    }
}
