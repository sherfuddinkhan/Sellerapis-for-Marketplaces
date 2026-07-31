using Marketplacesellerportal.Models;

namespace Marketplacesellerportal.SalesInvoices.Interfaces
{
    public interface ISalesInvoiceRepository
    {
        Task<IEnumerable<SalesInvoice>> GetAllAsync();

        Task<SalesInvoice?> GetByIdAsync(int salesInvoiceId);

        Task<IEnumerable<SalesInvoice>> GetBySalesOrderAsync(int salesOrderId);

        Task<IEnumerable<SalesInvoice>> GetByStatusAsync(string status);

        Task<IEnumerable<SalesInvoice>> GetByPaymentStatusAsync(string paymentStatus);

        Task<SalesInvoice?> GetByInvoiceNumberAsync(string invoiceNumber);

        Task AddAsync(SalesInvoice salesInvoice);

        Task UpdateAsync(SalesInvoice salesInvoice);

        Task DeleteAsync(int salesInvoiceId);

        Task SaveChangesAsync();
    }
}
