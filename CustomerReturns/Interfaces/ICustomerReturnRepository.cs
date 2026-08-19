using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.CustomerReturns.Interfaces
{
    public interface ICustomerReturnRepository
    {
        Task<IEnumerable<CustomerReturn>> GetAllAsync();

        Task<CustomerReturn?> GetByIdAsync(
            int customerReturnId);

        Task<IEnumerable<CustomerReturn>> GetBySellerIdAsync(
            int sellerId);

        Task<IEnumerable<CustomerReturn>> GetByCustomerIdAsync(
            int customerId);
        Task<IEnumerable<CustomerReturn>> GetByStatusAsync(
    string status);
        Task<IEnumerable<CustomerReturn>> GetBySellerCustomerAsync(
            int sellerId,
            int customerId);

        Task<IEnumerable<CustomerReturn>> GetBySalesInvoiceAsync(
            int salesInvoiceId);

        Task<IEnumerable<CustomerReturn>> GetByProductAsync(
            int productId);

        Task<CustomerReturn?> GetByReturnNumberAsync(
            string returnNumber);

        Task AddAsync(CustomerReturn customerReturn);

        Task UpdateAsync(CustomerReturn customerReturn);

        Task DeleteAsync(int customerReturnId);

        Task SaveChangesAsync();
    }
}