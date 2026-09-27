using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("SalesOrders")]
    public class SalesOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesOrderId { get; set; }

        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int? Pid { get; set; }
        public int? KeyID { get; set; }

        [MaxLength(100)]
        public string? SalesOrderNumber { get; set; } = string.Empty;

        // =====================================================
        // UNIWARE / CHANNEL
        // =====================================================
        [MaxLength(100)] public string? SalesOrderCode { get; set; }
        [MaxLength(100)] public string? DisplayOrderCode { get; set; }
        [MaxLength(100)] public string? ChannelOrderId { get; set; }
        [MaxLength(100)] public string? ExternalOrderId { get; set; }
        [MaxLength(50)] public string? ChannelCode { get; set; } = "CUSTOM";
        [MaxLength(50)] public string? PaymentMethodCode { get; set; } = "Prepaid";
        [MaxLength(50)] public string? PaymentMethod { get; set; } = "Prepaid";
        [MaxLength(10)] public string? CurrencyCode { get; set; } = "INR";
        [MaxLength(50)] public string? ShippingMethodCode { get; set; } = "STANDARD";
        [MaxLength(50)] public string? CourierCode { get; set; }
        [MaxLength(50)] public string? CustomerCode { get; set; }
        [MaxLength(200)] public string? CustomerName { get; set; }
        [MaxLength(200)] public string? CustomerEmail { get; set; }
        [MaxLength(20)] public string? CustomerPhone { get; set; }
        public decimal? CodAmount { get; set; }
        public string? FulfillmentTat { get; set; }
        public bool? IsThirdPartyShipping { get; set; } = false;
        public bool? IsGiftWrap { get; set; } = false;
        [MaxLength(500)] public string? GiftMessage { get; set; }
        [MaxLength(200)] public string? NotificationEmail { get; set; }
        [MaxLength(20)] public string? NotificationMobile { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }

        [MaxLength(100)] public string? FacilityCode { get; set; } = "WH-TN-001";
        [MaxLength(100)] public string? UniwareFacilityCode { get; set; } = "WH-TN-001";
        [MaxLength(50)] public string? Type { get; set; } = "CART";
        public DateTime? ChannelCreatedDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        [MaxLength(50)] public string? StatusCode { get; set; } = "CREATED";
        [MaxLength(50)] public string? FulfillmentStatus { get; set; } = "PENDING";
        public decimal? TotalQuantity { get; set; }
        public int? TotalItems { get; set; }
        [MaxLength(500)] public string? ShippingAddress { get; set; }
        [MaxLength(500)] public string? BillingAddress { get; set; }
        [MaxLength(10)] public string? CountryCode { get; set; } = "IN";
        [MaxLength(10)] public string? StateCode { get; set; } = "36";
        [Column(TypeName = "decimal(18,2)")] public decimal? ShippingCharges { get; set; }

        // MONEY - ALL NULLABLE TO AVOID SqlNullValueException
        [Column(TypeName = "decimal(18,2)")] public decimal? SubTotal { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")] public decimal? DiscountAmount { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")] public decimal? TaxAmount { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")] public decimal? ShippingAmount { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")] public decimal? RoundOffAmount { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")] public decimal? TotalAmount { get; set; } = 0;

        public DateTime? OrderDate { get; set; } = DateTime.UtcNow;
        [MaxLength(50)] public string? Status { get; set; } = "Confirmed";
        [MaxLength(1000)] public string? Remarks { get; set; }

        // BILL FROM
        [Column("Company_Name")] public string? Company_Name { get; set; }
        [Column("Company_Address")] public string? Company_Address { get; set; }
        [Column("Company_City")] public string? Company_City { get; set; }
        [Column("Company_State")] public string? Company_State { get; set; }
        [Column("Company_PINCode")] public string? Company_PINCode { get; set; }
        [Column("Phone_no")] public string? Phone_no { get; set; }
        [Column("Email_Address")] public string? Email_Address { get; set; }

        [NotMapped] public string? CompanyName { get => Company_Name; set => Company_Name = value; }
        [NotMapped] public string? CompanyAddress { get => Company_Address; set => Company_Address = value; }
        [NotMapped] public string? CompanyCity { get => Company_City; set => Company_City = value; }
        [NotMapped] public string? CompanyState { get => Company_State; set => Company_State = value; }
        [NotMapped] public string? CompanyPinCode { get => Company_PINCode; set => Company_PINCode = value; }
        [NotMapped] public string? PhoneNo { get => Phone_no; set => Phone_no = value; }
        [NotMapped] public string? EmailAddress { get => Email_Address; set => Email_Address = value; }

        [MaxLength(50)] public string? GSTIN { get; set; }
        [NotMapped] public string? Gstin { get => GSTIN; set => GSTIN = value; }

        [MaxLength(100)] public string? DeliveryNote { get; set; }
        [MaxLength(200)] public string? ModeorTermsOfPayment { get; set; }
        [MaxLength(200)] public string? OtherReferences { get; set; }
        [MaxLength(100)] public string? DespatchedDocumentNumber { get; set; }
        public DateTime? DeliveryNoteDate { get; set; }
        [MaxLength(100)] public string? EWayBillNumber { get; set; }
        [MaxLength(20)] public string? VehicleNo { get; set; }
        [MaxLength(20)] public string? Distance { get; set; }
        [MaxLength(20)] public string? TYear { get; set; }
        [MaxLength(100)] public string? Transport { get; set; }
        [MaxLength(200)] public string? TransporterName { get; set; }
        [MaxLength(100)] public string? TransporterID { get; set; }
        [MaxLength(100)] public string? TransporterDocNo { get; set; }
        [MaxLength(50)] public string? TransportMode { get; set; }

        [MaxLength(200)] public string? SupplierRef { get; set; }
        [MaxLength(100)] public string? BuyersOrderNo { get; set; }
        public DateTime? BuyersOrderDate { get; set; }
        [MaxLength(100)] public string? DespatchedThrough { get; set; }
        [MaxLength(100)] public string? Destination { get; set; }
        [MaxLength(200)] public string? TermsOfDelivery { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? RoundOff { get; set; }
        [MaxLength(500)] public string? TotalInWords { get; set; }

        [MaxLength(50)] public string? TransactionType { get; set; } = "REG";

        public string? ShipToGSTIN { get; set; }
        public string? ShipToCompanyName { get; set; }
        public string? ShipToLegalName { get; set; }
        public string? ShipToAddress { get; set; }
        public string? ShipToCity { get; set; }
        public string? ShipToState { get; set; }
        public string? ShipToStateCode { get; set; }
        public string? ShipToPinCode { get; set; }
        public string? ShipToPhone { get; set; }
        public string? ShipToEmail { get; set; }

        public string? DispatchFromGSTIN { get; set; }
        public string? DispatchFromCompanyName { get; set; }
        public string? DispatchFromLegalName { get; set; }
        public string? DispatchFromAddress { get; set; }
        public string? DispatchFromCity { get; set; }
        public string? DispatchFromState { get; set; }
        public string? DispatchFromStateCode { get; set; }
        public string? DispatchFromPinCode { get; set; }
        public string? DispatchFromPhone { get; set; }

        public string? IrnNumber { get; set; }
        public string? AckNo { get; set; }
        public DateTime? AckDate { get; set; }
        public string? SignedInvoice { get; set; }
        public string? SignedQRCode { get; set; }

        public string? BillOfLandingOrLRRRNo { get; set; }
        public string? PurchaseOrderNo { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }


        // ADD THESE 4 if missing
        public string? ShippingAddressLine1 { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingState { get; set; }
        public string? ShippingPincode { get; set; }


        // =========================================================
        // UNIWARE API HELPERS - NOT IN DB, ONLY FOR JSON PAYLOAD
        // =========================================================
        [NotMapped]
        public bool CashOnDelivery => (CodAmount ?? 0) > 0;

        [NotMapped]
        public bool IsCod => CashOnDelivery; // Uniware alias

        [NotMapped]
        public List<object> UniwareAddresses
        {
            get
            {
                var shipAddress = ShippingAddressLine1 ?? Customer?.AddressLine1 ?? "";
                var city = ShippingCity ?? Customer?.City ?? "";
                var state = ShippingState ?? Customer?.State ?? "";
                var pincode = ShippingPincode ?? Customer?.PostalCode ?? "";

                return new List<object>
        {
            new {
                addressType = "shipping",
                name = CustomerName?? Customer?.CustomerName,
                addressLine1 = shipAddress,
                city = city,
                state = state,
                pincode = pincode,
                phone = CustomerPhone?? Customer?.Phone,
                email = CustomerEmail?? Customer?.Email,
                country = "IN"
            },
            new {
                addressType = "billing",
                name = CustomerName?? Customer?.CustomerName,
                addressLine1 = shipAddress,
                city = city,
                state = state,
                pincode = pincode,
                phone = CustomerPhone?? Customer?.Phone,
                email = CustomerEmail?? Customer?.Email,
                country = "IN"
            }
        };
            }
        }

        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(100)] public string? CreatedBy { get; set; } = "System";
        [MaxLength(100)] public string? UpdatedBy { get; set; }
        public bool? IsCancelled { get; set; } = false;
        public DateTime? CancelledDate { get; set; }
        public string? CancelReason { get; set; }
        [Timestamp] public byte[]? RowVersion { get; set; }

        [ForeignKey(nameof(SellerId))] public virtual Seller? Seller { get; set; }
        [ForeignKey(nameof(CustomerId))] public virtual Customer? Customer { get; set; }

        public virtual ICollection<SalesOrderItem> SaleOrderItems { get; set; } = new List<SalesOrderItem>();
        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();

        [NotMapped] public ICollection<SalesOrderItem> Items => SaleOrderItems;
    }
}
