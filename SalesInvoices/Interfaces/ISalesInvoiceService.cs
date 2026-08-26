using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesInvoices.DTOs;

namespace Marketplacesellerportal.SalesInvoices.Interfaces
{
    public interface ISalesInvoiceService
    {
        Task<IEnumerable<SalesInvoice>> GetAllAsync();

        Task<SalesInvoice?> GetByIdAsync(int salesInvoiceId);

        Task<IEnumerable<SalesInvoice>> GetBySalesOrderAsync(int salesOrderId);

        Task<IEnumerable<SalesInvoice>> GetByStatusAsync(string status);

        Task<IEnumerable<SalesInvoice>> GetByPaymentStatusAsync(string paymentStatus);

        Task<SalesInvoice?> GetByInvoiceNumberAsync(string invoiceNumber);

        Task<SalesInvoice> CreateAsync(SalesInvoice salesInvoice);

        Task<bool> UpdateAsync(int salesInvoiceId,UpdateSalesInvoiceRequest request);

        Task<bool> DeleteAsync(int salesInvoiceId);
    }
}