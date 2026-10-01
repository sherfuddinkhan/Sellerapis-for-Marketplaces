using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.InvoiceTaxDetails.Interfaces
{
    public interface IInvoiceTaxDetailService
    {
        Task<List<InvoiceTaxDetail>> GetAllAsync();
        Task<InvoiceTaxDetail?> GetByIdAsync(int id);
        Task<InvoiceTaxDetail> CreateAsync(InvoiceTaxDetail entity);
        Task<bool> UpdateAsync(int id, InvoiceTaxDetail entity);
        Task<bool> DeleteAsync(int id);
    }
}
