using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.VendorItemCustomFields.Interfaces
{
    public interface IVendorItemCustomFieldRepository
    {
        Task<List<VendorItemCustomField>> GetAllAsync();
        Task<VendorItemCustomField?> GetByIdAsync(int id);
        Task<VendorItemCustomField> CreateAsync(VendorItemCustomField entity);
        Task<bool> UpdateAsync(int id, VendorItemCustomField entity); // <-- must be (int id, entity)
        Task<bool> DeleteAsync(int id);
    }
}