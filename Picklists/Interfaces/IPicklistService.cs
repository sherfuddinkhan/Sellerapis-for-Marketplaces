using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Picklists.Interfaces
{
    public interface IPicklistService
    {
        Task<List<Picklist>> GetAllAsync();

        Task<Picklist?> GetByCodeAsync(string picklistCode);

        Task<Picklist> CreateAsync(Picklist entity);

        Task<bool> UpdateAsync(string picklistCode, Picklist entity);

        Task<bool> DeleteAsync(string picklistCode);
    }
}