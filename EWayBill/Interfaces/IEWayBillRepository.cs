using Marketplacesellerportal.EWayBill.DTOs;
namespace Marketplacesellerportal.EWayBill.Interfaces
{
    public interface IEWayBillRepository
    {
        Task SaveEWayBillAsync(int invoiceId, EWayBillResponse res, GenerateEWayBillRequest req);
    }
}
