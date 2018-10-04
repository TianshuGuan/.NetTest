using ImageSharingWithCloudStorage.DAL;
using ImageSharingWithCloudStorage.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageSharingWithCloudStorage.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db { get; set; }

        protected UserManager<ApplicationUser> UserManager { get; set; }

        protected BaseController()
        {
            db = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Base
        public ActionResult Index()
        {
            return View();
        }

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

        protected void SaveCookie(bool ADA)
        {
            HttpCookie cookie = new HttpCookie("ImageSharing");
            cookie.Expires = DateTime.Now.AddMonths(3);
            cookie.HttpOnly = true;
            cookie["ADA"] = ADA?"true":"false";
            Response.Cookies.Add(cookie);
        }
        protected ApplicationUser getLoggedInUser()
        {
            return UserManager.FindById(User.Identity.GetUserId());
        }

        protected IEnumerable<ApplicationUser> ActiveUsers()
        {
            return UserManager.Users.Where(u => u.Active);
        }

        protected IEnumerable<ApplicationUser> inActiveUsers()
        {
            return UserManager.Users.Where(u => !u.Active);
        }

        protected IEnumerable<Image> ApprovedImage(IEnumerable<Image> images)
        {
            return images.Where(img => img.Approved);
        }

        protected IEnumerable<Image> unApprovedImage(IEnumerable<Image> images)
        {
            return images.Where(img => !img.Approved);
        }


    }
}