using ImageSharingWithCloudStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageSharingWithCloudStorage.Controllers
{
    public class HomeController : BaseController
    {
        protected void CheckADA()
        {
            HttpCookie cookie = Request.Cookies.Get("ImageSharing");
            if (cookie != null)
            {
                if ("true".Equals(cookie["ADA"])) ViewBag.isADA = true;
                else ViewBag.isADA = false;
            }
            else ViewBag.isADA = false;
        }
        [HttpGet]
        public ActionResult Index(String id = "Stranger")
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            if (user != null) id = user.UserName;
            ViewBag.Title = "Welcome!";
            ViewBag.id = id;
            return View();
        }


        public ActionResult About()
        {
            CheckADA();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            CheckADA();
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}