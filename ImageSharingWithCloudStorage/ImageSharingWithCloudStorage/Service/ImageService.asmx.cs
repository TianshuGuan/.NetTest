using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using
using ImageSharingWithCloudStorage.DAL;
using Microsoft.AspNet.Identity;
using ImageSharingWithCloudStorage.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ImageSharingWithCloudStorage.Service
{
    /// <summary>
    /// Summary description for ImageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ImageService : System.Web.Services.WebService
    {
        static protected ApplicationDbContext db = new ApplicationDbContext();
        static protected UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db)); 

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Upload(Image image)
        {
            db.Images.Add(image);
            db.SaveChanges();
            image = db.Images.Find(image.id);
            return image.id;
        }

        [WebMethod]
        public Image GetImage(int id)
        {
            return db.Images.Find(id);
        }

        [WebMethod]
        public ImageInfo Update(Image image)
        {
            db.Entry(image).State = EntityState.Modified;
            db.SaveChanges();
            ImageInfo imagedto = new ImageInfo(image);
            imagedto.TagName = db.Tags.Find(image.tagId).Name;
            return imagedto;
        }

        [WebMethod] 
        public void Delete(int id)
        {
            Image image = db.Images.Find(id);
            db.Entry(image).State = EntityState.Deleted;
            db.Images.Remove(image);
            db.SaveChanges();
        }

        [WebMethod]
        public IEnumerable<Image> ListAll()
        {
            IEnumerable<Image> images = db.Images.ToList();
            return images;
        }

        [WebMethod]
        public IEnumerable<Image> ListByUser(String id)
        {
            ApplicationUser tar = UserManager.FindById(id);
            return tar.Images.Where(img => img.Approved);
        }

        [WebMethod]
        public IEnumerable<Image> ListByTag(int id)
        {
            Tag tag = db.Tags.Find(id);
            return tag.Images.Where(img => img.Approved);
        }


    }
}
