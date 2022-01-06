using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("order_details_status")]
    public partial class OrderDetailsStatus
    {
        public OrderDetailsStatus()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("status_name")]
        [StringLength(50)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(OrderDetail.Status))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
