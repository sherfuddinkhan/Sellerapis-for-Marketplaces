using Marketplacesellerportal.DTOs;
using Marketplacesellerportal.VendorItemMasters.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendorItemMasterEntity = Marketplacesellerportal.Models.VendorItemMaster;

namespace Marketplacesellerportal.VendorItemMasters.Interfaces
{
    public interface IVendorItemMasterRepository
    {
        Task<VendorItemMasterEntity?> GetByIdAsync(int id, int sellerId, int customerId);
        Task<(List<VendorItemMasterEntity> Items, int TotalCount)> GetListAsync(VendorItemMasterListRequest request);
        Task<VendorItemMasterEntity> CreateAsync(VendorItemMasterEntity entity);
        Task<VendorItemMasterEntity?> UpdateAsync(VendorItemMasterEntity entity);
        Task<bool> DeleteAsync(int id, int sellerId, int customerId);
        Task<bool> ExistsByVendorSkuAsync(string vendorSku, int vendorId, int sellerId, int customerId);
    }
}
