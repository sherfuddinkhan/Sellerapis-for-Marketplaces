using Microsoft.AspNetCore.Mvc;
using Marketplacesellerportal.Models;
using Marketplacesellerportal.SalesInvoices.DTOs;
using Marketplacesellerportal.SalesInvoices.Interfaces;
using System.Linq;
namespace Marketplacesellerportal.SalesInvoices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesInvoiceController : ControllerBase
    {
        private readonly ISalesInvoiceService _service;

        public SalesInvoiceController(ISalesInvoiceService service)
        {
            _service = service;
        }

        // =========================================================
        // GET ALL SALES INVOICES
        // =========================================================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            var response = result.Select(invoice => new
            {
                invoice.SalesInvoiceId,
                invoice.SalesOrderId,
                invoice.SellerId,
                invoice.CustomerId,

                invoice.CompanyName,
                invoice.MobileNo,
                invoice.EmailAddress,
                invoice.CompanyAddress,
                invoice.CompanyCity,
                invoice.CompanyState,
                invoice.CompanyPINCode,
                invoice.CustomerGSTIN,

                invoice.InvoiceNumber,
                invoice.InvoiceDate,
                invoice.InvoiceScenario,
                invoice.Category,
                invoice.TransactionType,

                invoice.PurchaseOrderNo,
                invoice.PurchaseOrderDate,
                invoice.OtherReferences,
                invoice.DespatchedDocumentNumber,

                invoice.UserGSTIN,
                invoice.DocumentType,
                invoice.SupplyType,
                invoice.PlaceOfSupply,
                invoice.StateCode,
                invoice.FinancialYear,
                invoice.ReverseCharge,

                invoice.DeliveryNote,
                invoice.DeliveryNoteDate,
                invoice.EWayBillNumber,
                invoice.VehicleNo,
                invoice.Distance,
                invoice.Transport,
                invoice.TransporterName,
                invoice.TransporterID,
                invoice.TransporterDocNo,
                invoice.TransportMode,
                invoice.Destination,
                invoice.BillOfLandingOrLRRRNo,
                invoice.DespatchedThrough,
                invoice.ModeOrTermsOfPayment,

                invoice.Id,
                invoice.RefId,

                invoice.SubTotal,
                invoice.DiscountAmount,
                invoice.TaxAmount,
                invoice.TotalAmount,
                invoice.PaidAmount,
                invoice.BalanceAmount,

                invoice.PaymentMode,
                invoice.PaymentStatus,
                invoice.Status,
                invoice.Remarks,

                invoice.CreatedDate,
                invoice.UpdatedDate,

                Items = invoice.Items?
                    .Select(item => new
                    {
                        item.SalesInvoiceItemId,
                        item.SalesInvoiceId,
                        item.ProductId,

                        item.Quantity,
                        item.UnitPrice,
                        item.Discount,
                        item.TaxAmount,
                        item.TotalAmount,

                        item.Pid,
                        item.InvoiceXID,
                        item.Description,
                        item.Uom,
                        item.QuantityAmount,

                        item.InvoiceDiscountType,
                        item.InvoiceDiscountValue,
                        item.InvoiceDiscountAmount,
                        item.TotalRateBeforeDiscount,

                        item.Hsncode,

                        item.GstPer,
                        item.SgstPer,
                        item.SgstAmount,
                        item.CgstPer,
                        item.CgstAmount,
                        item.IgstPer,
                        item.IgstAmount,
                        item.AfterGSTAmount,
                        item.TaxType,

                        item.MfgDate,
                        item.ExpDate,

                        item.Cases,
                        item.ColorCode,
                        item.ColorAmount,

                        item.Remarks,
                        item.ItemXID,
                        item.BrandXID,

                        item.IsReward,
                        item.IsAdditionalCharges,
                        item.MaterialTypeXid,
                        item.SpecificationTypeXid,
                        item.ProjectAssetDetailXID,
                        item.SpecificationTypeDetailName,
                        item.IsPurchasing
                    })
                    .ToList(),

                Payments = invoice.Payments?
                    .Select(payment => new
                    {
                        payment.SalesInvoicePaymentId,
                        payment.SalesInvoiceId,
                        payment.PaymentDate,
                        payment.PaymentMode,
                        payment.Amount,
                        payment.ReferenceNumber,
                        payment.Remarks
                    })
                    .ToList(),

                AdditionalCharges = invoice.AdditionalCharges?
                    .Select(charge => new
                    {
                        charge.SalesInvoiceAdditionalChargeId,
                        charge.SalesInvoiceId,
                        charge.ChargeName,
                        charge.ChargeType,
                        charge.Amount,
                        charge.TaxPercentage,
                        charge.TaxAmount,
                        charge.TotalAmount,
                        charge.Remarks
                    })
                    .ToList()
            });

            return Ok(response);
        }

        // =========================================================
        // GET SALES INVOICE BY ID
        // =========================================================
        // =========================================================
        // GET SALES INVOICE BY ID (WITH DTO MAPPING)
        // =========================================================

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _service.GetByIdAsync(id);

            if (invoice == null)
            {
                return NotFound(new
                {
                    message = $"Sales invoice with ID {id} not found.",
                    salesInvoiceId = id
                });
            }

            // Map EF Core Entity to Clean DTO to prevent JSON circular reference errors
            var response = new
            {
                invoice.SalesInvoiceId,
                invoice.SalesOrderId,
                invoice.SellerId,
                invoice.CustomerId,

                invoice.CompanyName,
                invoice.MobileNo,
                invoice.EmailAddress,
                invoice.CompanyAddress,
                invoice.CompanyCity,
                invoice.CompanyState,
                invoice.CompanyPINCode,
                invoice.CustomerGSTIN,

                invoice.InvoiceNumber,
                invoice.InvoiceDate,
                invoice.InvoiceScenario,
                invoice.Category,
                invoice.TransactionType,

                invoice.PurchaseOrderNo,
                invoice.PurchaseOrderDate,
                invoice.OtherReferences,
                invoice.DespatchedDocumentNumber,

                invoice.UserGSTIN,
                invoice.DocumentType,
                invoice.SupplyType,
                invoice.PlaceOfSupply,
                invoice.StateCode,
                invoice.FinancialYear,
                invoice.ReverseCharge,

                invoice.DeliveryNote,
                invoice.DeliveryNoteDate,
                invoice.EWayBillNumber,
                invoice.VehicleNo,
                invoice.Distance,
                invoice.Transport,
                invoice.TransporterName,
                invoice.TransporterID,
                invoice.TransporterDocNo,
                invoice.TransportMode,
                invoice.Destination,
                invoice.BillOfLandingOrLRRRNo,
                invoice.DespatchedThrough,
                invoice.ModeOrTermsOfPayment,

                invoice.Id,
                invoice.RefId,

                invoice.SubTotal,
                invoice.DiscountAmount,
                invoice.TaxAmount,
                invoice.TotalAmount,
                invoice.PaidAmount,
                invoice.BalanceAmount,

                invoice.PaymentMode,
                invoice.PaymentStatus,
                invoice.Status,
                invoice.Remarks,

                invoice.CreatedDate,
                invoice.UpdatedDate,

                Items = invoice.Items?.Select(item => new
                {
                    item.SalesInvoiceItemId,
                    item.SalesInvoiceId,
                    item.ProductId,
                    item.Quantity,
                    item.UnitPrice,
                    item.Discount,
                    item.TaxAmount,
                    item.TotalAmount,
                    item.Pid,
                    item.InvoiceXID,
                    item.Description,
                    item.Uom,
                    item.QuantityAmount,
                    item.InvoiceDiscountType,
                    item.InvoiceDiscountValue,
                    item.InvoiceDiscountAmount,
                    item.TotalRateBeforeDiscount,
                    item.Hsncode,
                    item.GstPer,
                    item.SgstPer,
                    item.SgstAmount,
                    item.CgstPer,
                    item.CgstAmount,
                    item.IgstPer,
                    item.IgstAmount,
                    item.AfterGSTAmount,
                    item.TaxType,
                    item.MfgDate,
                    item.ExpDate,
                    item.Cases,
                    item.ColorCode,
                    item.ColorAmount,
                    item.Remarks,
                    item.ItemXID,
                    item.BrandXID,
                    item.IsReward,
                    item.IsAdditionalCharges,
                    item.MaterialTypeXid,
                    item.SpecificationTypeXid,
                    item.ProjectAssetDetailXID,
                    item.SpecificationTypeDetailName,
                    item.IsPurchasing
                }) ?? Enumerable.Empty<object>(),

                Payments = invoice.Payments?.Select(payment => new
                {
                    payment.SalesInvoicePaymentId,
                    payment.SalesInvoiceId,
                    payment.PaymentDate,
                    payment.PaymentMode,
                    payment.Amount,
                    payment.ReferenceNumber,
                    payment.Remarks
                }) ?? Enumerable.Empty<object>(),

                AdditionalCharges = invoice.AdditionalCharges?.Select(charge => new
                {
                    charge.SalesInvoiceAdditionalChargeId,
                    charge.SalesInvoiceId,
                    charge.ChargeName,
                    charge.ChargeType,
                    charge.Amount,
                    charge.TaxPercentage,
                    charge.TaxAmount,
                    charge.TotalAmount,
                    charge.Remarks
                }) ?? Enumerable.Empty<object>()
            };

            return Ok(response);
        }

        // =========================================================
        // GET BY SALES ORDER ID
        // =========================================================

        [HttpGet("salesorder/{salesOrderId}")]
        public async Task<IActionResult> GetBySalesOrder(int salesOrderId)
        {
            var result = await _service.GetBySalesOrderAsync(salesOrderId);

            return Ok(result);
        }

        // =========================================================
        // GET BY STATUS
        // =========================================================

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var result = await _service.GetByStatusAsync(status);

            return Ok(result);
        }

        // =========================================================
        // GET BY PAYMENT STATUS
        // =========================================================

        [HttpGet("paymentstatus/{paymentStatus}")]
        public async Task<IActionResult> GetByPaymentStatus(string paymentStatus)
        {
            var result = await _service.GetByPaymentStatusAsync(paymentStatus);

            return Ok(result);
        }

        // =========================================================
        // GET BY INVOICE NUMBER
        // =========================================================

        [HttpGet("number/{invoiceNumber}")]
        public async Task<IActionResult> GetByInvoiceNumber(string invoiceNumber)
        {
            var result = await _service.GetByInvoiceNumberAsync(invoiceNumber);

            if (result == null)
                return NotFound(new
                {
                    message = "Sales invoice not found."
                });

            return Ok(result);
        }

        // =========================================================
        // CREATE SALES INVOICE
        // =========================================================

        // =========================================================
        // CREATE SALES INVOICE
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateSalesInvoiceRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // =====================================================
            // CREATE PARENT SALES INVOICE
            // =====================================================

            var salesInvoice = new SalesInvoice
            {
                // =================================================
                // REFERENCE DETAILS
                // =================================================

                SalesOrderId = request.SalesOrderId,
                SellerId = request.SellerId,
                CustomerId = request.CustomerId,

                // =================================================
                // CUSTOMER / BUYER SNAPSHOT
                // =================================================

                CompanyName = request.CompanyName,
                MobileNo = request.MobileNo,
                EmailAddress = request.EmailAddress,
                CompanyAddress = request.CompanyAddress,
                CompanyCity = request.CompanyCity,
                CompanyState = request.CompanyState,
                CompanyPINCode = request.CompanyPINCode,
                CustomerGSTIN = request.CustomerGSTIN,

                // =================================================
                // INVOICE DETAILS
                // =================================================

                InvoiceNumber = request.InvoiceNumber,
                InvoiceDate = request.InvoiceDate,
                InvoiceScenario = request.InvoiceScenario,
                Category = request.Category,
                TransactionType = request.TransactionType,

                // =================================================
                // PO / REFERENCE DETAILS
                // =================================================

                PurchaseOrderNo = request.PurchaseOrderNo,
                PurchaseOrderDate = request.PurchaseOrderDate,
                OtherReferences = request.OtherReferences,
                DespatchedDocumentNumber = request.DespatchedDocumentNumber,

                // =================================================
                // GST / TAX DETAILS
                // =================================================

                UserGSTIN = request.UserGSTIN,
                DocumentType = request.DocumentType,
                SupplyType = request.SupplyType,
                PlaceOfSupply = request.PlaceOfSupply,
                StateCode = request.StateCode,
                FinancialYear = request.FinancialYear,
                ReverseCharge = request.ReverseCharge,

                // =================================================
                // TRANSPORT / DELIVERY DETAILS
                // =================================================

                DeliveryNote = request.DeliveryNote,
                DeliveryNoteDate = request.DeliveryNoteDate,
                EWayBillNumber = request.EWayBillNumber,
                VehicleNo = request.VehicleNo,
                Distance = request.Distance,
                Transport = request.Transport,
                TransporterName = request.TransporterName,
                TransporterID = request.TransporterID,
                TransporterDocNo = request.TransporterDocNo,
                TransportMode = request.TransportMode,
                Destination = request.Destination,
                BillOfLandingOrLRRRNo = request.BillOfLandingOrLRRRNo,
                DespatchedThrough = request.DespatchedThrough,
                ModeOrTermsOfPayment = request.ModeOrTermsOfPayment,

                // =================================================
                // ID / REFERENCE DETAILS
                // =================================================

                Id = request.Id,
                RefId = request.RefId,

                // =================================================
                // AMOUNT DETAILS
                // =================================================

                SubTotal = request.SubTotal,
                DiscountAmount = request.DiscountAmount,
                TaxAmount = request.TaxAmount,
                TotalAmount = request.TotalAmount,
                PaidAmount = request.PaidAmount,
                BalanceAmount = request.BalanceAmount,

                // =================================================
                // PAYMENT / STATUS
                // =================================================

                PaymentMode = request.PaymentMode,
                PaymentStatus = request.PaymentStatus,
                Status = request.Status,
                Remarks = request.Remarks,

                // =================================================
                // CHILD COLLECTIONS
                // =================================================

                Items = request.Items?
                    .Select(item => new SalesInvoiceItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        Discount = item.Discount,
                        TaxAmount = item.TaxAmount,
                        TotalAmount = item.TotalAmount,

                        Pid = item.Pid,
                        InvoiceXID = item.InvoiceXID,
                        Description = item.Description,
                        Uom = item.Uom,
                        QuantityAmount = item.QuantityAmount,
                        InvoiceDiscountType = item.InvoiceDiscountType,
                        InvoiceDiscountValue = item.InvoiceDiscountValue,
                        InvoiceDiscountAmount = item.InvoiceDiscountAmount,
                        TotalRateBeforeDiscount =
                            item.TotalRateBeforeDiscount,

                        Hsncode = item.Hsncode,

                        GstPer = item.GstPer,
                        SgstPer = item.SgstPer,
                        SgstAmount = item.SgstAmount,
                        CgstPer = item.CgstPer,
                        CgstAmount = item.CgstAmount,
                        IgstPer = item.IgstPer,
                        IgstAmount = item.IgstAmount,
                        AfterGSTAmount = item.AfterGSTAmount,
                        TaxType = item.TaxType,

                        MfgDate = item.MfgDate,
                        ExpDate = item.ExpDate,
                        Cases = item.Cases,
                        ColorCode = item.ColorCode,
                        ColorAmount = item.ColorAmount,
                        Remarks = item.Remarks,
                        ItemXID = item.ItemXID,
                        BrandXID = item.BrandXID,

                        IsReward = item.IsReward,
                        IsAdditionalCharges = item.IsAdditionalCharges,
                        MaterialTypeXid = item.MaterialTypeXid,
                        SpecificationTypeXid = item.SpecificationTypeXid,
                        ProjectAssetDetailXID =
                            item.ProjectAssetDetailXID,
                        SpecificationTypeDetailName =
                            item.SpecificationTypeDetailName,
                        IsPurchasing = item.IsPurchasing
                    })
                    .ToList() ?? new List<SalesInvoiceItem>(),

                Payments = request.Payments?
                    .Select(payment => new SalesInvoicePayment
                    {
                        PaymentDate = payment.PaymentDate,
                        PaymentMode = payment.PaymentMode,
                        Amount = payment.Amount,
                        ReferenceNumber = payment.ReferenceNumber,
                        Remarks = payment.Remarks
                    })
                    .ToList() ?? new List<SalesInvoicePayment>(),

                AdditionalCharges = request.AdditionalCharges?
                    .Select(charge =>
                        new SalesInvoiceAdditionalCharge
                        {
                            ChargeName = charge.ChargeName,
                            ChargeType = charge.ChargeType,
                            Amount = charge.Amount,
                            TaxPercentage = charge.TaxPercentage,
                            TaxAmount = charge.TaxAmount,
                            TotalAmount = charge.TotalAmount,
                            Remarks = charge.Remarks
                        })
                    .ToList()
                    ?? new List<SalesInvoiceAdditionalCharge>()
            };

            // =====================================================
            // SAVE COMPLETE INVOICE
            // =====================================================

            var result = await _service.CreateAsync(salesInvoice);

            return Ok(result);
        }

        // =========================================================
        // UPDATE SALES INVOICE
        // =========================================================

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
     int id,
     [FromBody] UpdateSalesInvoiceRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, request);

            if (!updated)
            {
                return NotFound(new
                {
                    message = "Sales invoice not found.",
                    salesInvoiceId = id
                });
            }

            return Ok(new
            {
                message = "Sales invoice updated successfully.",
                salesInvoiceId = id
            });
        }

        // =========================================================
        // GET SALES INVOICES BY SELLER + CUSTOMER
        //
        // GET /api/SalesInvoice/seller/6/customer/3
        // =========================================================

        [HttpGet("seller/{sellerId:int}/customer/{customerId:int}")]
        public async Task<IActionResult> GetBySellerAndCustomer(
            int sellerId,
            int customerId)
        {
            var result =
                await _service.GetBySellerAndCustomerAsync(
                    sellerId,
                    customerId);

            if (result == null || !result.Any())
            {
                return NotFound(new
                {
                    message = "No sales invoices found for the specified seller and customer.",
                    sellerId,
                    customerId
                });
            }

            var response = result.Select(invoice => new
            {
                invoice.SalesInvoiceId,
                invoice.SalesOrderId,
                invoice.SellerId,
                invoice.CustomerId,

                invoice.CompanyName,
                invoice.MobileNo,
                invoice.EmailAddress,
                invoice.CompanyAddress,
                invoice.CompanyCity,
                invoice.CompanyState,
                invoice.CompanyPINCode,
                invoice.CustomerGSTIN,

                invoice.InvoiceNumber,
                invoice.InvoiceDate,
                invoice.InvoiceScenario,
                invoice.Category,
                invoice.TransactionType,

                invoice.PurchaseOrderNo,
                invoice.PurchaseOrderDate,
                invoice.OtherReferences,
                invoice.DespatchedDocumentNumber,

                invoice.UserGSTIN,
                invoice.DocumentType,
                invoice.SupplyType,
                invoice.PlaceOfSupply,
                invoice.StateCode,
                invoice.FinancialYear,
                invoice.ReverseCharge,

                invoice.DeliveryNote,
                invoice.DeliveryNoteDate,
                invoice.EWayBillNumber,
                invoice.VehicleNo,
                invoice.Distance,
                invoice.Transport,
                invoice.TransporterName,
                invoice.TransporterID,
                invoice.TransporterDocNo,
                invoice.TransportMode,
                invoice.Destination,
                invoice.BillOfLandingOrLRRRNo,
                invoice.DespatchedThrough,
                invoice.ModeOrTermsOfPayment,

                invoice.Id,
                invoice.RefId,

                invoice.SubTotal,
                invoice.DiscountAmount,
                invoice.TaxAmount,
                invoice.TotalAmount,
                invoice.PaidAmount,
                invoice.BalanceAmount,

                invoice.PaymentMode,
                invoice.PaymentStatus,
                invoice.Status,
                invoice.Remarks,

                invoice.CreatedDate,
                invoice.UpdatedDate,

                Items = invoice.Items?
                    .Select(item => new
                    {
                        item.SalesInvoiceItemId,
                        item.SalesInvoiceId,
                        item.ProductId,

                        item.Quantity,
                        item.UnitPrice,
                        item.Discount,
                        item.TaxAmount,
                        item.TotalAmount,

                        item.Pid,
                        item.InvoiceXID,
                        item.Description,
                        item.Uom,
                        item.QuantityAmount,

                        item.InvoiceDiscountType,
                        item.InvoiceDiscountValue,
                        item.InvoiceDiscountAmount,
                        item.TotalRateBeforeDiscount,

                        item.Hsncode,

                        item.GstPer,
                        item.SgstPer,
                        item.SgstAmount,
                        item.CgstPer,
                        item.CgstAmount,
                        item.IgstPer,
                        item.IgstAmount,
                        item.AfterGSTAmount,
                        item.TaxType,

                        item.MfgDate,
                        item.ExpDate,

                        item.Cases,
                        item.ColorCode,
                        item.ColorAmount,

                        item.Remarks,
                        item.ItemXID,
                        item.BrandXID,

                        item.IsReward,
                        item.IsAdditionalCharges,
                        item.MaterialTypeXid,
                        item.SpecificationTypeXid,
                        item.ProjectAssetDetailXID,
                        item.SpecificationTypeDetailName,
                        item.IsPurchasing
                    })
                    .ToList(),

                Payments = invoice.Payments?
                    .Select(payment => new
                    {
                        payment.SalesInvoicePaymentId,
                        payment.SalesInvoiceId,
                        payment.PaymentDate,
                        payment.PaymentMode,
                        payment.Amount,
                        payment.ReferenceNumber,
                        payment.Remarks
                    })
                    .ToList(),

                AdditionalCharges = invoice.AdditionalCharges?
                    .Select(charge => new
                    {
                        charge.SalesInvoiceAdditionalChargeId,
                        charge.SalesInvoiceId,
                        charge.ChargeName,
                        charge.ChargeType,
                        charge.Amount,
                        charge.TaxPercentage,
                        charge.TaxAmount,
                        charge.TotalAmount,
                        charge.Remarks
                    })
                    .ToList()
            });

            return Ok(response);
        }
        // =========================================================
        // DELETE SALES INVOICE
        // =========================================================

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Sales invoice not found.",
                    salesInvoiceId = id
                });
            }

            return Ok(new
            {
                message = "Sales invoice deleted successfully.",
                salesInvoiceId = id
            });
        }
    }
}