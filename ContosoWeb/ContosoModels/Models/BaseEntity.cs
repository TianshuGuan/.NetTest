using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModels.Models
{
    public abstract class BaseEntity:BaseModel
    {
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
