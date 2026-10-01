using Marketplacesellerportal.Models;

using SupplierContactModel = Marketplacesellerportal.Models.SupplierContacts;

namespace Marketplacesellerportal.SupplierContact.Interfaces
{
    public interface ISupplierContactRepository
    {
        Task<List<SupplierContactModel>> GetAllAsync();

        Task<SupplierContactModel?> GetByIdAsync(int id);

        Task<SupplierContactModel> CreateAsync(
            SupplierContactModel entity);

        Task<bool> UpdateAsync(
            SupplierContactModel entity);

        Task<bool> DeleteAsync(int id);
    }
}