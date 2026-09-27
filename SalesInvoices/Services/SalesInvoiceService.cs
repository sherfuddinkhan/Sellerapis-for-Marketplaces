using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesInvoices.DTOs;
using Marketplacesellerportal.SalesInvoices.Interfaces;

namespace Marketplacesellerportal.SalesInvoices.Services
{
    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly ISalesInvoiceRepository _repository;

        public SalesInvoiceService(
            ISalesInvoiceRepository repository)
        {
            _repository = repository;
        }

        // =========================================================
        // GET ALL
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<SalesInvoice>>
    GetBySellerAndCustomerAsync(
        int sellerId,
        int customerId)
        {
            return await _repository
                .GetBySellerAndCustomerAsync(
                    sellerId,
                    customerId);
        }
        // =========================================================
        // GET BY ID
        // =========================================================

        public async Task<SalesInvoice?> GetByIdAsync(
            int salesInvoiceId)
        {
            return await _repository.GetByIdAsync(
                salesInvoiceId);
        }

        // =========================================================
        // GET BY SALES ORDER
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetBySalesOrderAsync(
            int salesOrderId)
        {
            return await _repository.GetBySalesOrderAsync(
                salesOrderId);
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetByStatusAsync(
            string status)
        {
            return await _repository.GetByStatusAsync(
                status);
        }

        // =========================================================
        // GET BY PAYMENT STATUS
        // =========================================================

        public async Task<IEnumerable<SalesInvoice>> GetByPaymentStatusAsync(
            string paymentStatus)
        {
            return await _repository.GetByPaymentStatusAsync(
                paymentStatus);
        }

        // =========================================================
        // GET BY INVOICE NUMBER
        // =========================================================

        public async Task<SalesInvoice?> GetByInvoiceNumberAsync(
            string invoiceNumber)
        {
            return await _repository.GetByInvoiceNumberAsync(
                invoiceNumber);
        }

        // =========================================================
        // CREATE
        // =========================================================

        public async Task<SalesInvoice> CreateAsync(
            SalesInvoice salesInvoice)
        {
            // -----------------------------------------------------
            // Created date
            // -----------------------------------------------------

            salesInvoice.CreatedDate = DateTime.Now;

            // -----------------------------------------------------
            // Invoice date
            // -----------------------------------------------------

            if (salesInvoice.InvoiceDate == DateTime.MinValue)
            {
                salesInvoice.InvoiceDate = DateTime.Now;
            }

            // -----------------------------------------------------
            // Add complete invoice aggregate
            // -----------------------------------------------------

            await _repository.AddAsync(
                salesInvoice);

            await _repository.SaveChangesAsync();

            return salesInvoice;
        }

        // =========================================================
        // UPDATE
        //
        // PUT replaces the complete invoice aggregate:
        //
        // Parent
        // + Items
        // + Payments
        // + Additional Charges
        // =========================================================

        public async Task<bool> UpdateAsync(
            int salesInvoiceId,
            UpdateSalesInvoiceRequest request)
        {
            // =====================================================
            // LOAD EXISTING INVOICE
            // =====================================================

            var existing =
                await _repository.GetByIdAsync(
                    salesInvoiceId);

            if (existing == null)
            {
                return false;
            }

            // =====================================================
            // CUSTOMER / BUYER SNAPSHOT
            // =====================================================

            existing.CompanyName =
                request.CompanyName;

            existing.MobileNo =
                request.MobileNo;

            existing.EmailAddress =
                request.EmailAddress;

            existing.CompanyAddress =
                request.CompanyAddress;

            existing.CompanyCity =
                request.CompanyCity;

            existing.CompanyState =
                request.CompanyState;

            existing.CompanyPINCode =
                request.CompanyPINCode;

            existing.CustomerGSTIN =
                request.CustomerGSTIN;

            // =====================================================
            // REFERENCE DETAILS
            // =====================================================

            existing.SalesOrderId =
                request.SalesOrderId;

            existing.SellerId =
                request.SellerId;

            existing.CustomerId =
                request.CustomerId;

            // =====================================================
            // INVOICE DETAILS
            // =====================================================

            existing.InvoiceNumber =
                request.InvoiceNumber;

            existing.InvoiceDate =
                request.InvoiceDate;

            existing.InvoiceScenario =
                request.InvoiceScenario;

            existing.Category =
                request.Category;

            existing.TransactionType =
                request.TransactionType;

            // =====================================================
            // PURCHASE ORDER / REFERENCES
            // =====================================================

            existing.PurchaseOrderNo =
                request.PurchaseOrderNo;

            existing.PurchaseOrderDate =
                request.PurchaseOrderDate;

            existing.OtherReferences =
                request.OtherReferences;

            existing.DespatchedDocumentNumber =
                request.DespatchedDocumentNumber;

            // =====================================================
            // GST / TAX DETAILS
            // =====================================================

            existing.UserGSTIN =
                request.UserGSTIN;

            existing.DocumentType =
                request.DocumentType;

            existing.SupplyType =
                request.SupplyType;

            existing.PlaceOfSupply =
                request.PlaceOfSupply;

            existing.StateCode =
                request.StateCode;

            existing.FinancialYear =
                request.FinancialYear;

            existing.ReverseCharge =
                request.ReverseCharge;

            // =====================================================
            // TRANSPORT / DELIVERY
            // =====================================================

            existing.DeliveryNote =
                request.DeliveryNote;

            existing.DeliveryNoteDate =
                request.DeliveryNoteDate;

            existing.EWayBillNumber =
                request.EWayBillNumber;

            existing.VehicleNo =
                request.VehicleNo;

            existing.Distance =
                request.Distance;

            existing.Transport =
                request.Transport;

            existing.TransporterName =
                request.TransporterName;

            existing.TransporterID =
                request.TransporterID;

            existing.TransporterDocNo =
                request.TransporterDocNo;

            existing.TransportMode =
                request.TransportMode;

            existing.Destination =
                request.Destination;

            existing.BillOfLandingOrLRRRNo =
                request.BillOfLandingOrLRRRNo;

            existing.DespatchedThrough =
                request.DespatchedThrough;

            existing.ModeOrTermsOfPayment =
                request.ModeOrTermsOfPayment;

            // =====================================================
            // EXTERNAL REFERENCES
            // =====================================================

            existing.Id =
                request.Id;

            existing.RefId =
                request.RefId;

            // =====================================================
            // AMOUNTS
            // =====================================================

            existing.SubTotal =
                request.SubTotal;

            existing.DiscountAmount =
                request.DiscountAmount;

            existing.TaxAmount =
                request.TaxAmount;

            existing.TotalAmount =
                request.TotalAmount;

            existing.PaidAmount =
                request.PaidAmount;

            existing.BalanceAmount =
                request.BalanceAmount;

            // =====================================================
            // PAYMENT / STATUS
            // =====================================================

            existing.PaymentMode =
                request.PaymentMode;

            existing.PaymentStatus =
                request.PaymentStatus;

            existing.Status =
                request.Status;

            existing.Remarks =
                request.Remarks;

            // =====================================================
            // AUDIT
            // =====================================================

            existing.UpdatedDate =
                DateTime.Now;

            // =====================================================
            // REMOVE EXISTING CHILDREN
            //
            // PUT semantics:
            // Request collections become the new collections.
            // =====================================================

            await _repository.DeleteItemsAsync(
                salesInvoiceId);

            await _repository.DeletePaymentsAsync(
                salesInvoiceId);

            await _repository.DeleteAdditionalChargesAsync(
                salesInvoiceId);

            // =====================================================
            // ADD UPDATED ITEMS
            // =====================================================

            existing.Items = request.Items?

                .Select(item => new SalesInvoiceItem
                {
                    SalesInvoiceId =
                        salesInvoiceId,

                    ProductId =
                        item.ProductId,

                    Quantity =
                        item.Quantity,

                    UnitPrice =
                        item.UnitPrice,

                    Discount =
                        item.Discount,

                    TaxAmount =
                        item.TaxAmount,

                    TotalAmount =
                        item.TotalAmount,

                    Pid =
                        item.Pid,

                    InvoiceXID =
                        item.InvoiceXID,

                    Description =
                        item.Description,

                    Uom =
                        item.Uom,

                    QuantityAmount =
                        item.QuantityAmount,

                    InvoiceDiscountType =
                        item.InvoiceDiscountType,

                    InvoiceDiscountValue =
                        item.InvoiceDiscountValue,

                    InvoiceDiscountAmount =
                        item.InvoiceDiscountAmount,

                    TotalRateBeforeDiscount =
                        item.TotalRateBeforeDiscount,

                    Hsncode =
                        item.Hsncode,

                    GstPer =
                        item.GstPer,

                    SgstPer =
                        item.SgstPer,

                    SgstAmount =
                        item.SgstAmount,

                    CgstPer =
                        item.CgstPer,

                    CgstAmount =
                        item.CgstAmount,

                    IgstPer =
                        item.IgstPer,

                    IgstAmount =
                        item.IgstAmount,

                    AfterGSTAmount =
                        item.AfterGSTAmount,

                    TaxType =
                        item.TaxType,

                    MfgDate =
                        item.MfgDate,

                    ExpDate =
                        item.ExpDate,

                    Cases =
                        item.Cases,

                    ColorCode =
                        item.ColorCode,

                    ColorAmount =
                        item.ColorAmount,

                    Remarks =
                        item.Remarks,

                    ItemXID =
                        item.ItemXID,

                    BrandXID =
                        item.BrandXID,

                    IsReward =
                        item.IsReward,

                    IsAdditionalCharges =
                        item.IsAdditionalCharges,

                    MaterialTypeXid =
                        item.MaterialTypeXid,

                    SpecificationTypeXid =
                        item.SpecificationTypeXid,

                    ProjectAssetDetailXID =
                        item.ProjectAssetDetailXID,

                    SpecificationTypeDetailName =
                        item.SpecificationTypeDetailName,

                    IsPurchasing =
                        item.IsPurchasing
                })

                .ToList()
                ?? new List<SalesInvoiceItem>();

            // =====================================================
            // ADD UPDATED PAYMENTS
            // =====================================================

            existing.Payments = request.Payments?

                .Select(payment => new SalesInvoicePayment
                {
                    SalesInvoiceId =
                        salesInvoiceId,

                    PaymentDate =
                        payment.PaymentDate,

                    PaymentMode =
                        payment.PaymentMode,

                    Amount =
                        payment.Amount,

                    ReferenceNumber =
                        payment.ReferenceNumber,

                    Remarks =
                        payment.Remarks
                })

                .ToList()
                ?? new List<SalesInvoicePayment>();

            // =====================================================
            // ADD UPDATED ADDITIONAL CHARGES
            // =====================================================

            existing.AdditionalCharges =
                request.AdditionalCharges?

                .Select(charge =>
                    new SalesInvoiceAdditionalCharge
                    {
                        SalesInvoiceId =
                            salesInvoiceId,

                        ChargeName =
                            charge.ChargeName,

                        ChargeType =
                            charge.ChargeType,

                        Amount =
                            charge.Amount,

                        TaxPercentage =
                            charge.TaxPercentage,

                        TaxAmount =
                            charge.TaxAmount,

                        TotalAmount =
                            charge.TotalAmount,

                        Remarks =
                            charge.Remarks
                    })

                .ToList()
                ?? new List<SalesInvoiceAdditionalCharge>();

            // =====================================================
            // UPDATE PARENT
            // =====================================================

            await _repository.UpdateAsync(
                existing);

            // =====================================================
            // SAVE EVERYTHING
            // =====================================================

            await _repository.SaveChangesAsync();

            return true;
        }

        // =========================================================
        // DELETE
        // =========================================================

        public async Task<bool> DeleteAsync(
            int salesInvoiceId)
        {
            var existing =
                await _repository.GetByIdAsync(
                    salesInvoiceId);

            if (existing == null)
            {
                return false;
            }

            await _repository.DeleteAsync(
                salesInvoiceId);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}