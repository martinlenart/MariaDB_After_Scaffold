using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("order_details")]
    [Index(nameof(StatusId), Name = "fk_order_details_order_details_status1_idx")]
    [Index(nameof(OrderId), Name = "fk_order_details_orders1_idx")]
    [Index(nameof(Id), Name = "id")]
    [Index(nameof(InventoryId), Name = "inventory_id")]
    [Index(nameof(ProductId), Name = "product_id")]
    [Index(nameof(PurchaseOrderId), Name = "purchase_order_id")]
    public partial class OrderDetail
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("order_id", TypeName = "int(11)")]
        public int OrderId { get; set; }
        [Column("product_id", TypeName = "int(11)")]
        public int? ProductId { get; set; }
        [Column("quantity")]
        public decimal Quantity { get; set; }
        [Column("unit_price")]
        public decimal? UnitPrice { get; set; }
        [Column("discount")]
        public double Discount { get; set; }
        [Column("status_id", TypeName = "int(11)")]
        public int? StatusId { get; set; }
        [Column("date_allocated", TypeName = "datetime")]
        public DateTime? DateAllocated { get; set; }
        [Column("purchase_order_id", TypeName = "int(11)")]
        public int? PurchaseOrderId { get; set; }
        [Column("inventory_id", TypeName = "int(11)")]
        public int? InventoryId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(OrderDetailsStatus.OrderDetails))]
        public virtual OrderDetailsStatus Status { get; set; }
    }
}
