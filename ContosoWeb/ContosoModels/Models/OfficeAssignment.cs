using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModels.Models
{
    public class OfficeAssignment:IEntity
    {
        [Key]
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }

        [MaxLength(150)]
        public string Location { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDateTime { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDateTime { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; }


    }
}
