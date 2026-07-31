using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.CustomerReturns.Interfaces
{
    public interface ICustomerReturnService
    {
        Task<IEnumerable<CustomerReturn>> GetAllAsync();

        Task<CustomerReturn?> GetByIdAsync(int customerReturnId);

        Task<IEnumerable<CustomerReturn>> GetBySalesInvoiceAsync(int salesInvoiceId);

        Task<IEnumerable<CustomerReturn>> GetByProductAsync(int productId);

        Task<IEnumerable<CustomerReturn>> GetByStatusAsync(string status);

        Task<CustomerReturn?> GetByReturnNumberAsync(string returnNumber);

        Task<CustomerReturn> CreateAsync(CustomerReturn customerReturn);

        Task<bool> UpdateAsync(int customerReturnId, CustomerReturn customerReturn);

        Task<bool> DeleteAsync(int customerReturnId);
    }
}
