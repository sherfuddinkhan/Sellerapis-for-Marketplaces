using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Interfaces
{
    public interface IPicklistRepository
    {
        Task<List<Picklist>> GetAllAsync();

        Task<Picklist?> GetByCodeAsync(string picklistCode);

        Task<Picklist> CreateAsync(Picklist entity);

        Task<bool> UpdateAsync(Picklist entity);

        Task<bool> DeleteAsync(string picklistCode);
    }
}
