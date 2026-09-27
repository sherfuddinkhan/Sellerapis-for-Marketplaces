using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.VendorItemMaster.DTOs;
using Marketplacesellerportal.VendorItemMasters.DTOs;
using System.Threading.Tasks;

namespace Marketplacesellerportal.VendorItemMasters.Interfaces
{
    public interface IVendorItemMasterService
    {
        Task<VendorItemMasterResponse> GetByIdAsync(int id, int sellerId, int customerId);
        Task<VendorItemMasterListResponse> GetListAsync(VendorItemMasterListRequest request);
        Task<VendorItemMasterResponse> CreateAsync(VendorItemMasterModel model);
        Task<VendorItemMasterResponse> UpdateAsync(int id, VendorItemMasterModel model);
        Task<VendorItemMasterResponse> DeleteAsync(int id, int sellerId, int customerId);
    }
}