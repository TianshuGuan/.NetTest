using ContosoData.Repositories;
using ContosoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ContosoService.Services
{
   public class InstructorService: IInstructorService
   {
       private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _instructorRepository.GetAll();
        }

        public Instructor GetInstructorById(int id)
        {
            return _instructorRepository.GetById(id);
        }
        //get instructors by last name
        public IEnumerable<Instructor> GetInstructorByName(string FirstName,string LastName)
        {
            return _instructorRepository.GetMany(i => i.LastName == LastName && i.FirstName == FirstName);
        }

        public void CreateInstructor(Instructor instructor)
        {
            using (var transaction = new TransactionScope())
            {
                _instructorRepository.Add(instructor);
                _instructorRepository.SaveChanges();
                transaction.Complete();
            }
        }

        public void UpdateInstructor(Instructor instructor)
        {
            using (var transaction = new TransactionScope())
            {
                _instructorRepository.Update(instructor);
                _instructorRepository.SaveChanges();
                transaction.Complete();
            }
        }

        public IEnumerable<Instructor> GetInstructorByDepartment(int departmentId)
        {
            return _instructorRepository.FindByInclude(d => d.Id == departmentId, i => i.Department);
        }

        public IEnumerable<Instructor> GetInstructorByCourse(int courseId)
        {
            return _instructorRepository.FindByInclude(c => c.Id == courseId, i => i.Courses);
        }
    }

   public interface IInstructorService
    {
        IEnumerable<Instructor> GetAllInstructors();
        Instructor GetInstructorById(int id);
        IEnumerable<Instructor> GetInstructorByName(string FirstName, string LastName);
        IEnumerable<Instructor> GetInstructorByDepartment(int departmentId);
        IEnumerable<Instructor> GetInstructorByCourse(int courseId);
        void CreateInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
    }
}
