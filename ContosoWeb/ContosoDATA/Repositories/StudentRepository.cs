using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoDATA.DAL;
using ContosoModels.Models;

namespace ContosoData.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ContosoDBContext context) : base(context)
        {
            
        }

        public List<Student> GetStudentByLastName(string lastName)
        {
            var student = _context.Person.OfType<Student>().Where(s => s.LastName == lastName);
            return student.ToList();
        }
    }

    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetStudentByLastName(string lastName);
    }
}