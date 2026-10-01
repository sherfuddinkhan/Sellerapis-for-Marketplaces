using SupplierContactModel = Marketplacesellerportal.Models.SupplierContacts;

namespace Marketplacesellerportal.SupplierContact.Interfaces
{
    public interface ISupplierContactService
    {
        Task<List<SupplierContactModel>> GetAllAsync();

        Task<SupplierContactModel?> GetByIdAsync(int id);

        Task<SupplierContactModel> CreateAsync(
            SupplierContactModel entity);

        Task<bool> UpdateAsync(
            int id,
            SupplierContactModel entity);

        Task<bool> DeleteAsync(int id);
    }
}