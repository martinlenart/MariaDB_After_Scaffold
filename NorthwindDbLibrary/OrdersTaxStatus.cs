using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("orders_tax_status")]
    public partial class OrdersTaxStatus
    {
        public OrdersTaxStatus()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("id", TypeName = "tinyint(4)")]
        public sbyte Id { get; set; }
        [Required]
        [Column("tax_status_name")]
        [StringLength(50)]
        public string TaxStatusName { get; set; }

        [InverseProperty(nameof(Order.TaxStatus))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
