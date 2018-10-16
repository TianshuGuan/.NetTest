using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModels.Models
{
    public class Role :BaseEntity
    {
        [MaxLength(50)]
        public string RoleName { get; set; }
        [MaxLength(200)]
        public string Descriptioin { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
