using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("purchase_orders")]
    [Index(nameof(CreatedBy), Name = "created_by")]
    [Index(nameof(Id), Name = "id", IsUnique = true)]
    [Index(nameof(StatusId), Name = "status_id")]
    [Index(nameof(SupplierId), Name = "supplier_id")]
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            InventoryTransactions = new HashSet<InventoryTransaction>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("supplier_id", TypeName = "int(11)")]
        public int? SupplierId { get; set; }
        [Column("created_by", TypeName = "int(11)")]
        public int? CreatedBy { get; set; }
        [Column("submitted_date", TypeName = "datetime")]
        public DateTime? SubmittedDate { get; set; }
        [Column("creation_date", TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
        [Column("status_id", TypeName = "int(11)")]
        public int? StatusId { get; set; }
        [Column("expected_date", TypeName = "datetime")]
        public DateTime? ExpectedDate { get; set; }
        [Column("shipping_fee")]
        public decimal ShippingFee { get; set; }
        [Column("taxes")]
        public decimal Taxes { get; set; }
        [Column("payment_date", TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }
        [Column("payment_amount")]
        public decimal? PaymentAmount { get; set; }
        [Column("payment_method")]
        [StringLength(50)]
        public string PaymentMethod { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("approved_by", TypeName = "int(11)")]
        public int? ApprovedBy { get; set; }
        [Column("approved_date", TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        [Column("submitted_by", TypeName = "int(11)")]
        public int? SubmittedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Employee.PurchaseOrders))]
        public virtual Employee CreatedByNavigation { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(PurchaseOrderStatus.PurchaseOrders))]
        public virtual PurchaseOrderStatus Status { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("PurchaseOrders")]
        public virtual Supplier Supplier { get; set; }
        [InverseProperty(nameof(InventoryTransaction.PurchaseOrder))]
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        [InverseProperty(nameof(PurchaseOrderDetail.PurchaseOrder))]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
