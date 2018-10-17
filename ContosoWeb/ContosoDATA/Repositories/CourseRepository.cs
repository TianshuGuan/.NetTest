using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoDATA.DAL;
using ContosoModels.Models;

namespace ContosoData.Repositories
{
   public class CourseRepository: GenericRepository<Course>, ICoursepository
    {
        public CourseRepository(ContosoDBContext context) : base(context)
        {
        }
    }

    public interface ICoursepository : IRepository<Course>
    {
    }
}
