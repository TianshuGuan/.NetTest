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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void AddCourse(Course course)
        {
            using (var transaction = new TransactionScope())
            {
                _courseRepository.Add(course);
                _courseRepository.SaveChanges();
                transaction.Complete();
            }
        }

        public void Enroll(Student student, Course course)
        {
            using (var transaction = new TransactionScope())
            {
                _courseRepository.Enroll(student, course);
                _courseRepository.SaveChanges();
                transaction.Complete();
            }
                
        }

        public IEnumerable<Course> GetAllCourse()
        {
            return _courseRepository.GetAll();
        }

        public IEnumerable<Course> GetAllCourseByDepartment(int departmentId)
        {
            return _courseRepository.GetMany(c => c.DepartmentId == departmentId);
        }

        public IEnumerable<Course> GetAllCourseByInstructor(int instructorId)
        {
            return _courseRepository.FindByInclude(i => i.Id == instructorId, c => c.Instructors);
        }

        public void UpdateCourse(Course course)
        {
            using (var transaction = new TransactionScope())
            {
                _courseRepository.Update(course);
                _courseRepository.SaveChanges();
                transaction.Complete();
            }
        }
    }

    public interface ICourseService
    {
        void Enroll(Student student, Course course);
        IEnumerable<Course> GetAllCourse();
        IEnumerable<Course> GetAllCourseByDepartment(int departmentId);
        IEnumerable<Course> GetAllCourseByInstructor(int instructorId);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
    }
}
