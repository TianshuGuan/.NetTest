using ContosoData.Repositories;
using ContosoDATA.DAL;
using ContosoModels.Models;
using ContosoService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoWeb.Controllers
{
    public class InstructorController : Controller
    {
        protected IInstructorService _service;
        public InstructorController()
        {
            _service = new InstructorService(new InstructorRepository(new ContosoDBContext()));
        }

        // GET: Instructor
        public ActionResult Index()
        {
            var courses = _service.GetAllInstructors();
            ViewBag.Title = "List All Instructors";
            return View("List",courses);
        }

        public ActionResult List(BaseModel include)
        {
            ViewBag.Title = "List Instructors";
            if(include == null)
            {
                ViewBag.Title = "List All Instructors";
                var courses = _service.GetAllInstructors();
                return View(courses);
            }
            if(include.GetType() == typeof(Department))
            {
                var courses = _service.GetInstructorByDepartment(include.Id);
                return View(courses);
            }
            if(include.GetType() == typeof(Department))
            {
                var courses = _service.GetInstructorByCourse(include.Id);
            }

            ViewBag.Title = "Empty Result";
            return View();
        }
    }
}