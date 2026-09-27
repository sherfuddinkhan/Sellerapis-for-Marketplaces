using Marketplacesellerportal.EWayBill.DTOs;
namespace Marketplacesellerportal.EWayBill.Interfaces
{
    public interface IEWayBillService
    {
        Task<EWayBillResponse> GenerateAsync(int invoiceId, GenerateEWayBillRequest req);
    }
}
