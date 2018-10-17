using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModels.Models
{
    public class Enrollment :BaseEntity
    {
        public Enrollment(int student, int course)
        {
            this.StudentId = student;
            this.CourseId = course;
        }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }

        public Grade? Grades { get; set; }

        public enum Grade
        {
            A,
            B,
            C,
            D,
            F
        }
    }
}
