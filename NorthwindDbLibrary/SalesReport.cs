using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("sales_reports")]
    public partial class SalesReport
    {
        [Key]
        [Column("group_by")]
        [StringLength(50)]
        public string GroupBy { get; set; }
        [Column("display")]
        [StringLength(50)]
        public string Display { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("filter_row_source")]
        public string FilterRowSource { get; set; }
        [Column("default")]
        public bool Default { get; set; }
    }
}
