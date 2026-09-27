using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplacesellerportal.Models
{
    [Table("Shipments")]
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }

        [Required]
        public int SellerId { get; set; } = 6;

        [Required]
        public int CustomerId { get; set; } = 3;

        // ORDER LINKING
        [Required]
        public int OrderId { get; set; }

        public int? SalesOrderId { get; set; }
        public int? DeliveryChallanId { get; set; }

        [MaxLength(100)]
        public string? SalesOrderNumber { get; set; }

        [MaxLength(100)]
        public string? DisplayOrderCode { get; set; }

        // UNIWARE PACKAGE - MANDATORY
        [MaxLength(100)]
        public string? ShipmentNumber { get; set; }

        [MaxLength(100)]
        public string? ShippingPackageCode { get; set; }

        [MaxLength(100)]
        public string? ShippingPackageNumber { get; set; }

        [MaxLength(100)]
        public string? ChannelCode { get; set; } = "CUSTOM";

        [MaxLength(100)]
        public string? FacilityCode { get; set; } = "WH-TN-001";

        [MaxLength(100)]
        public string? UniwareFacilityCode { get; set; }

        // COURIER
        [MaxLength(100)]
        public string? CourierName { get; set; }

        [MaxLength(100)]
        public string? CourierCode { get; set; }

        [MaxLength(100)]
        public string? ShippingMethodCode { get; set; } = "STANDARD";

        [MaxLength(200)]
        public string? TrackingNumber { get; set; }

        [MaxLength(200)]
        public string? AwbNumber { get; set; }

        [MaxLength(500)]
        public string? CourierTrackingUrl { get; set; }

        [MaxLength(500)]
        public string? ShippingLabelUrl { get; set; }

        [MaxLength(500)]
        public string? InvoiceUrl { get; set; }

        public bool IsCod { get; set; } = false;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? CodAmount { get; set; }

        // DATES - FIXED: No duplicate DeliveryDate
        public DateTime? ShipmentDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // STATUS
        [MaxLength(50)]
        public string? ShipmentStatus { get; set; } = "CREATED";

        [MaxLength(50)]
        public string? ShippingPackageStatus { get; set; } = "CREATED";

        [MaxLength(50)]
        public string? CourierStatus { get; set; }

        [MaxLength(500)]
        public string? StatusRemarks { get; set; }

        // DIMENSIONS - FIXED: All decimal? to match DB
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Length { get; set; } = 20;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Width { get; set; } = 15;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Height { get; set; } = 10;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Weight { get; set; } = 0.5m;

        [MaxLength(20)]
        public string? DimUnit { get; set; } = "CM";

        [MaxLength(20)]
        public string? WeightUnit { get; set; } = "KG";

        // TRANSPORT / E-WAY BILL
        [MaxLength(50)]
        public string? VehicleNo { get; set; }

        [MaxLength(200)]
        public string? TransporterName { get; set; }

        [MaxLength(100)]
        public string? TransporterID { get; set; }

        [MaxLength(100)]
        public string? TransporterDocNo { get; set; }

        [MaxLength(50)]
        public string? TransportMode { get; set; } = "Road";

        [MaxLength(50)]
        public string? Distance { get; set; }

        [MaxLength(100)]
        public string? EWayBillNumber { get; set; }

        // FINANCIAL - FIXED: decimal to match DB
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ShippingCharges { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { get; set; }

        // ADDRESS
        [MaxLength(1000)]
        public string? ShippingAddress { get; set; }

        // AUDIT - FIXED: Added missing UpdatedBy
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(100)]
        public string? CreatedBy { get; set; } = "System";

        [MaxLength(100)]
        public string? UpdatedBy { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        // CALCULATED - FIXED: All NotMapped
        [NotMapped]
        public DateTime DeliveryDate => ExpectedDeliveryDate ?? DateTime.UtcNow;

        [NotMapped]
        public string? Status => ShipmentStatus;

        [NotMapped]
        public bool IsShipped => ShipmentStatus == "SHIPPED" || ShippingPackageStatus == "SHIPPED";

        [NotMapped]
        public bool IsDelivered => ShipmentStatus == "DELIVERED";

        // NAVIGATION
        [ForeignKey(nameof(SalesOrderId))]
        public virtual SalesOrder? SalesOrder { get; set; }
    }
}