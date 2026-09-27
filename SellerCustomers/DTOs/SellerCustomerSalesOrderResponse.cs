namespace Marketplacesellerportal.SellerCustomers.DTOs
{
    public class SellerCustomerSalesOrderResponse
    {
        public int SalesOrderId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string SalesOrderNumber { get; set; } = string.Empty;

        // =====================================================
        // UNIWARE MANDATORY - YOU MISSED ALL THESE
        // =====================================================
        public string? SalesOrderCode { get; set; }
        public string? DisplayOrderCode { get; set; } // SO-TN-2026-005
        public string? ChannelCode { get; set; } = "CUSTOM";
        public string? FacilityCode { get; set; } = "WH-TN-001";
        public string? UniwareFacilityCode { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public string? OrderType { get; set; } = "CART";
        public string? CurrencyCode { get; set; } = "INR";

        public DateTime OrderDate { get; set; }
        public DateTime? ChannelCreatedDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? StatusCode { get; set; }
        public string? FulfillmentStatus { get; set; }

        // Financial breakdown - YOU MISSED
        public decimal TotalAmount { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? ShippingCharges { get; set; }
        public decimal? CodAmount { get; set; }
        public decimal? TotalQuantity { get; set; }
        public int? TotalItems { get; set; }

        public string? Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // Address - YOU MISSED
        public string? ShippingAddress { get; set; }
        public string? BillingAddress { get; set; }
        public string? StateCode { get; set; } // 36
        public string? CountryCode { get; set; } = "IN";

        // =====================================================
        // TOPAZ PAYLOAD FIELDS - 77 missing params fix
        // =====================================================
        public string? Company_Name { get; set; }
        public string? Company_Address { get; set; }
        public string? Company_City { get; set; }
        public string? Company_State { get; set; }
        public string? Company_PINCode { get; set; }
        public string? Phone_no { get; set; }
        public string? Email_Address { get; set; }
        public string? gstin { get; set; }

        // YOU MISSED THESE 10 TOPAZ FIELDS
        public string? SupplierRef { get; set; }
        public string? BuyersOrderNo { get; set; }
        public DateTime? BuyersOrderDate { get; set; }
        public string? DespatchedThrough { get; set; }
        public string? Destination { get; set; }
        public string? TermsOfDelivery { get; set; }
        public decimal? RoundOff { get; set; }
        public string? TotalInWords { get; set; }
        public string? Company_PAN { get; set; }
        public string? Company_CIN { get; set; }

        public string? DeliveryNote { get; set; }
        public string? ModeorTermsOfPayment { get; set; }
        public string? OtherReferences { get; set; }
        public string? DespatchedDocumentNumber { get; set; }
        public DateTime? DeliveryNoteDate { get; set; }
        public string? EWayBillNumber { get; set; }
        public string? VehicleNo { get; set; }
        public string? Distance { get; set; }
        public string? TYear { get; set; }
        public string? Transport { get; set; }
        public string? TransporterName { get; set; }
        public string? TransporterID { get; set; }
        public string? TransporterDocNo { get; set; }
        public string? TransportMode { get; set; }
        public int? Pid { get; set; }
        public int? KeyID { get; set; }

        // Line items
        public List<SellerCustomerSalesOrderItemResponse> Items { get; set; } = new();
    }

}