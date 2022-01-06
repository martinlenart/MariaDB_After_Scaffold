using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("strings")]
    public partial class String
    {
        [Key]
        [Column("string_id", TypeName = "int(11)")]
        public int StringId { get; set; }
        [Column("string_data")]
        [StringLength(255)]
        public string StringData { get; set; }
    }
}
