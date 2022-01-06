using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("products")]
    [Index(nameof(ProductCode), Name = "product_code")]
    public partial class Product
    {
        public Product()
        {
            InventoryTransactions = new HashSet<InventoryTransaction>();
            OrderDetails = new HashSet<OrderDetail>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        [Column("supplier_ids")]
        public string SupplierIds { get; set; }
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("product_code")]
        [StringLength(25)]
        public string ProductCode { get; set; }
        [Column("product_name")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("standard_cost")]
        public decimal? StandardCost { get; set; }
        [Column("list_price")]
        public decimal ListPrice { get; set; }
        [Column("reorder_level", TypeName = "int(11)")]
        public int? ReorderLevel { get; set; }
        [Column("target_level", TypeName = "int(11)")]
        public int? TargetLevel { get; set; }
        [Column("quantity_per_unit")]
        [StringLength(50)]
        public string QuantityPerUnit { get; set; }
        [Column("discontinued")]
        public bool Discontinued { get; set; }
        [Column("minimum_reorder_quantity", TypeName = "int(11)")]
        public int? MinimumReorderQuantity { get; set; }
        [Column("category")]
        [StringLength(50)]
        public string Category { get; set; }
        [Column("attachments")]
        public byte[] Attachments { get; set; }

        [InverseProperty(nameof(InventoryTransaction.Product))]
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        [InverseProperty(nameof(OrderDetail.Product))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [InverseProperty(nameof(PurchaseOrderDetail.Product))]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
