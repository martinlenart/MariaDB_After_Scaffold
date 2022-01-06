using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("privileges")]
    public partial class Privilege
    {
        public Privilege()
        {
            EmployeePrivileges = new HashSet<EmployeePrivilege>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("privilege_name")]
        [StringLength(50)]
        public string PrivilegeName { get; set; }

        [InverseProperty(nameof(EmployeePrivilege.Privilege))]
        public virtual ICollection<EmployeePrivilege> EmployeePrivileges { get; set; }
    }
}
