using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("purchase_order_details")]
    [Index(nameof(Id), Name = "id")]
    [Index(nameof(InventoryId), Name = "inventory_id")]
    [Index(nameof(ProductId), Name = "product_id")]
    [Index(nameof(PurchaseOrderId), Name = "purchase_order_id")]
    public partial class PurchaseOrderDetail
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("purchase_order_id", TypeName = "int(11)")]
        public int PurchaseOrderId { get; set; }
        [Column("product_id", TypeName = "int(11)")]
        public int? ProductId { get; set; }
        [Column("quantity")]
        public decimal Quantity { get; set; }
        [Column("unit_cost")]
        public decimal UnitCost { get; set; }
        [Column("date_received", TypeName = "datetime")]
        public DateTime? DateReceived { get; set; }
        [Column("posted_to_inventory")]
        public bool PostedToInventory { get; set; }
        [Column("inventory_id", TypeName = "int(11)")]
        public int? InventoryId { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty(nameof(InventoryTransaction.PurchaseOrderDetails))]
        public virtual InventoryTransaction Inventory { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("PurchaseOrderDetails")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        [InverseProperty("PurchaseOrderDetails")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
