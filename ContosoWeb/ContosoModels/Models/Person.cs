using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModels.Models
{
    public class Person :BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(200)]
        [RegularExpression(@"^\w +@[a-zA-Z_]+?\.[a-zA-Z]{2,4}$")]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string AddressLine1 { get; set; }
        [MaxLength(150)]
        public string AddressLine2 { get; set; }

        public int UnitOrAppartmentNumber  { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(20)]
        public string State { get; set; }
        [MaxLength(9)]
        [RegularExpression(@"^(?!0{5})(\d{5})(?!-?0{4})(-?\d{4})?$")]
        public string ZipCode { get; set; }
        [MaxLength(20)]
        public string PassWord { get; set; }
        [MaxLength(20)]
        public string Salt { get; set; }

        public bool IsLocked { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastLockedDateTime { get; set; }

        public int FailedAttempt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        
    }
}
