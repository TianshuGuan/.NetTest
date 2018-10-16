using ContosoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoWeb.Models
{
    public class StudentDTO:PersonDTO
    {
        public StudentDTO()
        {

        }

        public StudentDTO(Student student)
        {
            this.AddressLine1 = student.AddressLine1;
            this.AddressLine2 = student.AddressLine2;
            this.City = student.City;
            this.DateOfBirth = student.DateOfBirth;
            this.Email = student.Email;
            this.EnrollmentDate = student.EnrollmentDate;
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.MiddleName = student.MiddleName;
            this.Phone = student.Phone;
            this.State = student.State;
            this.UnitOrAppartmentNumber = student.UnitOrAppartmentNumber;
            this.ZipCode = student.ZipCode;
        }

        public DateTime EnrollmentDate { get; set; }


    }
}