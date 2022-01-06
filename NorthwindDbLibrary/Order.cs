using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("orders")]
    [Index(nameof(CustomerId), Name = "customer_id")]
    [Index(nameof(EmployeeId), Name = "employee_id")]
    [Index(nameof(StatusId), Name = "fk_orders_orders_status1")]
    [Index(nameof(Id), Name = "id")]
    [Index(nameof(ShipZipPostalCode), Name = "ship_zip_postal_code")]
    [Index(nameof(ShipperId), Name = "shipper_id")]
    [Index(nameof(TaxStatusId), Name = "tax_status")]
    public partial class Order
    {
        public Order()
        {
            InventoryTransactions = new HashSet<InventoryTransaction>();
            Invoices = new HashSet<Invoice>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("employee_id", TypeName = "int(11)")]
        public int? EmployeeId { get; set; }
        [Column("customer_id", TypeName = "int(11)")]
        public int? CustomerId { get; set; }
        [Column("order_date", TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column("shipped_date", TypeName = "datetime")]
        public DateTime? ShippedDate { get; set; }
        [Column("shipper_id", TypeName = "int(11)")]
        public int? ShipperId { get; set; }
        [Column("ship_name")]
        [StringLength(50)]
        public string ShipName { get; set; }
        [Column("ship_address")]
        public string ShipAddress { get; set; }
        [Column("ship_city")]
        [StringLength(50)]
        public string ShipCity { get; set; }
        [Column("ship_state_province")]
        [StringLength(50)]
        public string ShipStateProvince { get; set; }
        [Column("ship_zip_postal_code")]
        [StringLength(50)]
        public string ShipZipPostalCode { get; set; }
        [Column("ship_country_region")]
        [StringLength(50)]
        public string ShipCountryRegion { get; set; }
        [Column("shipping_fee")]
        public decimal? ShippingFee { get; set; }
        [Column("taxes")]
        public decimal? Taxes { get; set; }
        [Column("payment_type")]
        [StringLength(50)]
        public string PaymentType { get; set; }
        [Column("paid_date", TypeName = "datetime")]
        public DateTime? PaidDate { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("tax_rate")]
        public double? TaxRate { get; set; }
        [Column("tax_status_id", TypeName = "tinyint(4)")]
        public sbyte? TaxStatusId { get; set; }
        [Column("status_id", TypeName = "tinyint(4)")]
        public sbyte? StatusId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Orders")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(ShipperId))]
        [InverseProperty("Orders")]
        public virtual Shipper Shipper { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(OrdersStatus.Orders))]
        public virtual OrdersStatus Status { get; set; }
        [ForeignKey(nameof(TaxStatusId))]
        [InverseProperty(nameof(OrdersTaxStatus.Orders))]
        public virtual OrdersTaxStatus TaxStatus { get; set; }
        [InverseProperty(nameof(InventoryTransaction.CustomerOrder))]
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        [InverseProperty(nameof(Invoice.Order))]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty(nameof(OrderDetail.Order))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
