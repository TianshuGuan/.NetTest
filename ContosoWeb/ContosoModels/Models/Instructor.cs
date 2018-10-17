using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModels.Models
{
    public class Instructor :Person
    {
        [DataType(DataType.DateTime)]
        public DateTime HiredDate { get; set; }
        
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}
