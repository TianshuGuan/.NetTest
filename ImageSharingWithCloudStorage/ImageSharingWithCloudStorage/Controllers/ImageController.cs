using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ImageSharingWithCloudStorage.Models;
using ImageSharingWithCloudStorage.DAL;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace ImageSharingWithCloudStorage.Controllers
{
    public class ImageController : BaseController
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            CheckADA();
            ViewBag.Message = "";
            ViewBag.tags = new SelectList(db.Tags, "Id", "Name", 1);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(ImageInfo image, HttpPostedFileBase image_file)
        {
            CheckADA();
            if (ModelState.IsValid)
            {
                ApplicationUser user = getLoggedInUser();
            
                if (user != null)
                {
                    image.user_id = user.Id;
                    Image imageEntity = new Image(image);
                    imageEntity.SetUser(user);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //String jsonData = jss.Serialize(image);
                    //String fileName = Server.MapPath("~/APP_Data/Image_INFO/" + image.image_id + ".js");

                    if (image_file != null && image_file.ContentLength > 0){

                        db.Images.Add(imageEntity);
                        db.SaveChanges();
                        imageEntity = db.Images.Find(imageEntity.id);
                        
                        ImageStorage.saveFile(Server, image_file, imageEntity.id);

                        ViewBag.Title = "Upload Successful";
                        ImageInfo imagedto = new ImageInfo(imageEntity);
                        imagedto.TagName = db.Tags.Find(imageEntity.tagId).Name;
                        return View("Detail", imagedto);
                    }else{
                        ViewBag.Message = "no image!";
                        return View("Upload");
                    }
                  
                }
                else
                {
                    ViewBag.Message = "please register before upload";
                    return RedirectToAction("Register", "Account");
                }
            }
            else return View();
        }

        [HttpGet]
        public ActionResult Query()
        {
            CheckADA();
            ViewBag.Message = "";
            return View();
        }
        [HttpGet]
        public ActionResult DoQuery(int id)
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            if (user!=null)
            {
                Image image = db.Images.Find(id);
                ViewBag.Title = "Query Successful";
                if (image != null)
                {
                    ImageInfo imagedto = new ImageInfo(image);
                    imagedto.id = image.id;
                    imagedto.TagName = db.Tags.Find(image.tagId).Name;
                    imagedto.user_id = image.userId;
                    LogContext.addLogEntity(imagedto);
                    return View("Detail", imagedto);
                }
                else
                {
                    ViewBag.Message = "image not found";
                    ViewBag.id = id;
                    return View("Query");
                }
            }
            else
            {
                ViewBag.Message = "please Login before edit";
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            HttpCookie cookie = Request.Cookies.Get("ImageSharing");
                if (user != null)
                {
                    Image image = db.Images.Find(id);
                    if (image != null)
                    {
                        if (image.userId == user.Id)
                        {
                            ViewBag.Message = "";
                            ViewBag.tags = new SelectList(db.Tags, "Id", "Name", image.tagId);
                            ViewBag.image_id = image.id;
                            ImageInfo imagedto = new ImageInfo(image);
                            imagedto.TagName = db.Tags.Find(image.tagId).Name;
                            return View("Edit", imagedto);
                        }
                        else
                        {
                            ViewBag.Message = "you are not uploader of this image and cannot edit it! please login as another user!";
                            return RedirectToAction("Login", "Account");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "image not found";
                        ViewBag.id = id;
                        return View("Query");
                    }
                }
                else
                {
                    ViewBag.Message = "no such user registered!";
                    return RedirectToAction("Register", "Account");
                }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImageInfo info,int id)
        {
            CheckADA();

            if (ModelState.IsValid)
            {
                info.id = id;
                Image image = db.Images.Find(id);
                if (image != null)
                {
                    ApplicationUser user = getLoggedInUser();
                    HttpCookie cookie = Request.Cookies.Get("ImageSharing");
                    if (user!= null)
                    {
                        if (image.user.Id.Equals(user.Id))
                        {
                            image.tagId = info.TagId;
                            image.Caption = info.Caption;
                            image.Description = info.Description;
                            image.DateTaken = info.DateTaken;
                            db.Entry(image).State = EntityState.Modified;
                            db.SaveChanges();
                            ImageInfo imagedto = new ImageInfo(image);
                            imagedto.TagName = db.Tags.Find(image.tagId).Name;
                            return View("Detail", imagedto);
                        }
                        else
                        {
                            ViewBag.Message = "you are not uploader of this image and cannot edit it! please login as another user!";
                            return RedirectToAction("Login", "Account");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "please Login before edit";
                        return RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    ViewBag.Message = "image not found";
                    return View("Query");
                }

            }
            else
            {
                ViewBag.Message = "invalid input";
                return View("Edit",info);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
                if (user != null)
                {
                    Image image = db.Images.Find(id);
                    if (image != null)
                    {
                        if (image.userId == user.Id)
                        {
                            db.Entry(image).State = EntityState.Deleted;
                            db.Images.Remove(image);
                            db.SaveChanges();
                            ImageStorage.deleteFile(Server, id);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.Message = "you are not uploader of this image and cannot edit it! please login as another user!";
                            return RedirectToAction("Login", "Account");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "image not found";
                        ViewBag.id = id;
                        return View("Query");
                    }
                }
                else
                {
                    ViewBag.Message = "no such user registered!";
                    return RedirectToAction("Register", "Account");
                }
           

        }

        [HttpGet]
        public ActionResult ListAll()
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            if (user != null)
            {
                IEnumerable<Image> images = db.Images.ToList();
                ViewBag.Title = "List All Images";
                ViewBag.viewer_id = user.Id;
                return View("List",ApprovedImage(images));
            }
            else
            {
                ViewBag.Message = "please Login before query";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult ListByUser()
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            if (user != null)
            {
                
                SelectList users = new SelectList(ActiveUsers(), "Id", "UserName", 1);
                return View(users);
            }
            else
            {
                ViewBag.Message = "please Login before query";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult doListByUser(String id)
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
                if (user != null)
                {
                    ApplicationUser tar = UserManager.FindById(id);
                    ViewBag.Title = "List All Images Uploaded By " + user.Id;
                    ViewBag.viewer_id = user.Id;
                    return View("List", ApprovedImage(tar.Images));
                }
                else return RedirectToAction("ListByUser");
        }

        [HttpGet]
        public ActionResult ListByTag()
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            if (user != null)
            {
                SelectList tags = new SelectList(db.Tags, "Id", "Name", 1);
                return View(tags);
            }
            else
            {
                ViewBag.Message = "please Login before query";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult doListByTag(int id)
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            if (user != null)
            {
                Tag tag = db.Tags.Find(id);
                if (tag != null)
                {
                    ViewBag.Title = "List All Images With Tag " + tag.Name;
                    ViewBag.viewer_id = user.Id;
                    return View("List", ApprovedImage(tag.Images));
                }
                else return RedirectToAction("ListByTag");
            }
            else
            {
                ViewBag.Message = "please Login before query";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult Approve()
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            if (user != null)
            {
                if (UserManager.IsInRole(user.Id, "Approver"))
                {
                    ViewBag.Title = "Approve Images";
                    return View(unApprovedImage(db.Images.ToList()));
                }
                else return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.Message = "please Login before query";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult doApprove(int id)
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            if (user != null)
            {
                if (UserManager.IsInRole(user.Id, "Approver"))
                {
                    Image image = db.Images.Find(id);
                    image.Approved = true;
                    db.Entry(image).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Approve", "Image");
                }
                else return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.Message = "please Login before query";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult ListLog()
        {
            CheckADA();
            ApplicationUser user = getLoggedInUser();
            if (user != null)
            {
                IEnumerable<LogEntity> logs = LogContext.selectLog();
                ViewBag.Title = "List Logs";
                ViewBag.viewer_id = user.Id;
                return View("ListLog", logs);
            }
            else
            {
                ViewBag.Message = "please Login before query";
                return RedirectToAction("Login", "Account");
            }
        }
    }
}