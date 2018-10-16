
using Contoso.Data.Repositories;
using ContosoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoService.Service
{
    public class DepartmentService : IDepartmentService
    {
        private DepartmentRepository departmentrepo;

        public IEnumerable<Department> GetAllDepartment()
        {
            return departmentrepo.GetAllDepartmentsLazyCourses();
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int Id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartment();

        Department GetDepartmentById(int Id);
    }
}
