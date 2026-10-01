using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.VendorItemCustomFields.Interfaces
{
    public interface IVendorItemCustomFieldService
    {
        Task<List<VendorItemCustomField>> GetAllAsync();
        Task<VendorItemCustomField?> GetByIdAsync(int id);
        Task<VendorItemCustomField> CreateAsync(VendorItemCustomField entity);
        Task<bool> UpdateAsync(int id, VendorItemCustomField entity);
        Task<bool> DeleteAsync(int id);
    }
}