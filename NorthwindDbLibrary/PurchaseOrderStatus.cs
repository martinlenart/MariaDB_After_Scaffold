using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("purchase_order_status")]
    public partial class PurchaseOrderStatus
    {
        public PurchaseOrderStatus()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; }

        [InverseProperty(nameof(PurchaseOrder.Status))]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
