using Marketplacesellerportal.EInvoice.DTOs;
namespace Marketplacesellerportal.EInvoice.Interfaces
{
    public interface IEInvoiceService
    {
        Task<EinvoiceResponse> GenerateAsync(int invoiceId, GenerateEinvoiceRequest req);
        Task<object> GetPrintViewAsync(int invoiceId);
    }
}
