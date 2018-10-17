using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModels.Models
{
    public class Department:BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public int Budget { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        public byte[] RowVeersion { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }

        public virtual ICollection<Course> Courses { get; set; }


    }
}
