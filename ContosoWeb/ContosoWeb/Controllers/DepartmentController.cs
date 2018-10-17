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
    public class DepartmentController : Controller
    {
        protected IDepartmentService _service;
        protected DepartmentController()
        {
            _service = new DepartmentService(new DepartmentRepository(new ContosoDBContext()));
        }
        // GET: Department
        public ActionResult Index()
        {
            var departments = _service.GetAllDepartments();
            return View(departments);
        }

        public ActionResult Detail(Department department)
        {
            
            return View(department);
        }

        public ActionResult ToInstructor(Department department)
        {

            return RedirectToAction("List", "Instructor", department);
        }

        public ActionResult ToCourse(Department department)
        {

            return RedirectToAction("List", "Course", department);
        }
    }
}