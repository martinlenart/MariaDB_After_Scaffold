using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("inventory_transaction_types")]
    public partial class InventoryTransactionType
    {
        public InventoryTransactionType()
        {
            InventoryTransactions = new HashSet<InventoryTransaction>();
        }

        [Key]
        [Column("id", TypeName = "tinyint(4)")]
        public sbyte Id { get; set; }
        [Required]
        [Column("type_name")]
        [StringLength(50)]
        public string TypeName { get; set; }

        [InverseProperty(nameof(InventoryTransaction.TransactionTypeNavigation))]
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
