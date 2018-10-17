using ContosoData.Repositories;
using ContosoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contoso.Service
{
   public class DepartmentService: IDepartmentService
   {
       private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
           return _departmentRepository.GetAll();
        }

       public IEnumerable<Department> GetAllDepartmentsIncludeCourses()
       {
           return _departmentRepository.GetAllDepartmentsIncludeCourses();
       }
   }

   public interface IDepartmentService
   {
       IEnumerable<Department> GetAllDepartments();
       IEnumerable<Department> GetAllDepartmentsIncludeCourses();
    }
}
