namespace Marketplacesellerportal.Models
{
    public class SalesOrder
    {
        public int SalesOrderId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string SalesOrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // =====================================================
        // TOPAZ PAYLOAD FIELDS - 25 FIELDS ADDED
        // This fixes CS1061 'SalesOrder' does not contain 'KeyID'
        // =====================================================
        public string? Company_Name { get; set; } // TOPAZ
        public string? Company_Address { get; set; }
        public string? Company_City { get; set; } // Hyderabad
        public string? Company_State { get; set; } // TELANGANA
        public string? Company_PINCode { get; set; } // 500081
        public string? Phone_no { get; set; } // 9160422485
        public string? Email_Address { get; set; }
        public string? Gstin { get; set; } // 36AARFB4347G037
        public string? DeliveryNote { get; set; } // TOPAZ/015/26-27
        public string? ModeorTermsOfPayment { get; set; } // 50% Advance
        public string? OtherReferences { get; set; }
        public string? DespatchedDocumentNumber { get; set; }
        public DateTime? DeliveryNoteDate { get; set; }
        public string? EWayBillNumber { get; set; }
        public string? VehicleNo { get; set; } // TS09AB1234
        public string? Distance { get; set; } // 100 KM
        public string? TYear { get; set; } // 26-27
        public string? Transport { get; set; } // VRL Logistics
        public string? TransporterName { get; set; }
        public string? TransporterID { get; set; }
        public string? TransporterDocNo { get; set; } // LR987654321
        public string? TransportMode { get; set; } // Road Transport
        public string? StateCode { get; set; } // 36
        public int? Pid { get; set; } // 16
        public int? KeyID { get; set; } // 85 - THIS FIXES YOUR CS1061 ERROR
    }
}