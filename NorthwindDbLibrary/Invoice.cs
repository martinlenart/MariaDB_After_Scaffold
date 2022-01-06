using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("invoices")]
    [Index(nameof(OrderId), Name = "fk_invoices_orders1_idx")]
    [Index(nameof(Id), Name = "id")]
    public partial class Invoice
    {
        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("order_id", TypeName = "int(11)")]
        public int? OrderId { get; set; }
        [Column("invoice_date", TypeName = "datetime")]
        public DateTime? InvoiceDate { get; set; }
        [Column("due_date", TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        [Column("tax")]
        public decimal? Tax { get; set; }
        [Column("shipping")]
        public decimal? Shipping { get; set; }
        [Column("amount_due")]
        public decimal? AmountDue { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Invoices")]
        public virtual Order Order { get; set; }
    }
}
