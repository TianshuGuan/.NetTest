using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoDATA.DAL;
using ContosoModels.Models;

namespace ContosoData.Repositories
{
   public class DepartmentRepository: GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ContosoDBContext context) : base(context)
        {
        }

        public IEnumerable<Department> GetAllDepartmentsIncludeCourses()
        {
            var departments = _context.Departments.Include(d => d.Courses).ToList();
            return departments;
        }

        public IEnumerable<Department> GetAllDepartmentsLazyCourses()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }
    }

    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> GetAllDepartmentsIncludeCourses();
        IEnumerable<Department> GetAllDepartmentsLazyCourses();

    }
}
