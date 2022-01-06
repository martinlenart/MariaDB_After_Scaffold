using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("inventory_transactions")]
    [Index(nameof(CustomerOrderId), Name = "customer_order_id")]
    [Index(nameof(ProductId), Name = "product_id")]
    [Index(nameof(PurchaseOrderId), Name = "purchase_order_id")]
    [Index(nameof(TransactionType), Name = "transaction_type")]
    public partial class InventoryTransaction
    {
        public InventoryTransaction()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("transaction_type", TypeName = "tinyint(4)")]
        public sbyte TransactionType { get; set; }
        [Column("transaction_created_date", TypeName = "datetime")]
        public DateTime? TransactionCreatedDate { get; set; }
        [Column("transaction_modified_date", TypeName = "datetime")]
        public DateTime? TransactionModifiedDate { get; set; }
        [Column("product_id", TypeName = "int(11)")]
        public int ProductId { get; set; }
        [Column("quantity", TypeName = "int(11)")]
        public int Quantity { get; set; }
        [Column("purchase_order_id", TypeName = "int(11)")]
        public int? PurchaseOrderId { get; set; }
        [Column("customer_order_id", TypeName = "int(11)")]
        public int? CustomerOrderId { get; set; }
        [Column("comments")]
        [StringLength(255)]
        public string Comments { get; set; }

        [ForeignKey(nameof(CustomerOrderId))]
        [InverseProperty(nameof(Order.InventoryTransactions))]
        public virtual Order CustomerOrder { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("InventoryTransactions")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        [InverseProperty("InventoryTransactions")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        [ForeignKey(nameof(TransactionType))]
        [InverseProperty(nameof(InventoryTransactionType.InventoryTransactions))]
        public virtual InventoryTransactionType TransactionTypeNavigation { get; set; }
        [InverseProperty(nameof(PurchaseOrderDetail.Inventory))]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
