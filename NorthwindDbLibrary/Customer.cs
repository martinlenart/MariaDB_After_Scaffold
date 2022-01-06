using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NorthwindDbLibrary
{
    [Table("customers")]
    [Index(nameof(City), Name = "city")]
    [Index(nameof(Company), Name = "company")]
    [Index(nameof(FirstName), Name = "first_name")]
    [Index(nameof(LastName), Name = "last_name")]
    [Index(nameof(StateProvince), Name = "state_province")]
    [Index(nameof(ZipPostalCode), Name = "zip_postal_code")]
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("company")]
        [StringLength(50)]
        public string Company { get; set; }
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("email_address")]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Column("job_title")]
        [StringLength(50)]
        public string JobTitle { get; set; }
        [Column("business_phone")]
        [StringLength(25)]
        public string BusinessPhone { get; set; }
        [Column("home_phone")]
        [StringLength(25)]
        public string HomePhone { get; set; }
        [Column("mobile_phone")]
        [StringLength(25)]
        public string MobilePhone { get; set; }
        [Column("fax_number")]
        [StringLength(25)]
        public string FaxNumber { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("city")]
        [StringLength(50)]
        public string City { get; set; }
        [Column("state_province")]
        [StringLength(50)]
        public string StateProvince { get; set; }
        [Column("zip_postal_code")]
        [StringLength(15)]
        public string ZipPostalCode { get; set; }
        [Column("country_region")]
        [StringLength(50)]
        public string CountryRegion { get; set; }
        [Column("web_page")]
        public string WebPage { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("attachments")]
        public byte[] Attachments { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
