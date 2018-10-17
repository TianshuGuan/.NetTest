using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoDATA.DAL;
using ContosoModels.Models;

namespace ContosoData.Repositories
{
   public class CourseRepository: GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ContosoDBContext context) : base(context)
        {
        }

        public void Enroll(Student student, Course course)
        {
            _context.Enrollments.Add(new Enrollment(student.Id, course.Id));
        }
    }

    public interface ICourseRepository : IRepository<Course>
    {
        void Enroll(Student student, Course course);
    }
}
