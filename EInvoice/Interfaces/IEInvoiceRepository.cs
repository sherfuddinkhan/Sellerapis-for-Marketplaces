using Marketplacesellerportal.EInvoice.DTOs;
namespace Marketplacesellerportal.EInvoice.Interfaces
{
    public interface IEInvoiceRepository
    {
        Task SaveEinvoiceAsync(int invoiceId, EinvoiceResponse response);
    }
}
