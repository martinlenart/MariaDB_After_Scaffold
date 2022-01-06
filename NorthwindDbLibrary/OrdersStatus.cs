using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("orders_status")]
    public partial class OrdersStatus
    {
        public OrdersStatus()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("id", TypeName = "tinyint(4)")]
        public sbyte Id { get; set; }
        [Required]
        [Column("status_name")]
        [StringLength(50)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(Order.Status))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
