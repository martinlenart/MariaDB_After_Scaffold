using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("employee_privileges")]
    [Index(nameof(EmployeeId), Name = "employee_id")]
    [Index(nameof(PrivilegeId), Name = "privilege_id")]
    public partial class EmployeePrivilege
    {
        [Key]
        [Column("employee_id", TypeName = "int(11)")]
        public int EmployeeId { get; set; }
        [Key]
        [Column("privilege_id", TypeName = "int(11)")]
        public int PrivilegeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("EmployeePrivileges")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(PrivilegeId))]
        [InverseProperty("EmployeePrivileges")]
        public virtual Privilege Privilege { get; set; }
    }
}
