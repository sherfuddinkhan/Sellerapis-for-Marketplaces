using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.Interfaces
{
    public interface IInvoiceTaxDetailRepository
    {
        Task<List<InvoiceTaxDetail>> GetAllAsync();
        Task<InvoiceTaxDetail?> GetByIdAsync(int id);
        Task<InvoiceTaxDetail> CreateAsync(InvoiceTaxDetail entity);
        Task<bool> UpdateAsync(InvoiceTaxDetail entity);
        Task<bool> DeleteAsync(int id);
    }
}