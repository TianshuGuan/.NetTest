using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Security;

using System.Data.Entity;
using ImageSharingWithCloudStorage.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace ImageSharingWithCloudStorage.DAL
{
    public class ImageSharingDBInitializer: DropCreateDatabaseAlways<ApplicationDbContext>
    {

        
        protected override void Seed(ApplicationDbContext context)
        {

            RoleStore<IdentityRole> rs = new RoleStore<IdentityRole>(context);
            UserStore<ApplicationUser> us = new UserStore<ApplicationUser>(context);

            RoleManager<IdentityRole> rm = new RoleManager<IdentityRole>(rs);
            UserManager<ApplicationUser> um = new UserManager<ApplicationUser>(us);

            IdentityResult ir;

            ApplicationUser u1 = createUser("tguan1@example.org", false);
            ApplicationUser u2 = createUser("tguan2@example.org", true);
            ApplicationUser u3 = createUser("tguan3@example.org", false);


            ir = um.Create(u1, "tguan111");
            //u1 = um.FindByName(u1.UserName);
            ir = um.Create(u2, "tguan222");
            //u2 = um.FindByName(u2.UserName);
            ir = um.Create(u3, "tguan333");
            //u3 = um.FindByName(u3.UserName);

            rm.Create(new IdentityRole("User"));
            if (!um.IsInRole(u1.Id, "User")) um.AddToRole(u1.Id, "User");
            if (!um.IsInRole(u2.Id, "User")) um.AddToRole(u2.Id, "User");
            if (!um.IsInRole(u3.Id, "User")) um.AddToRole(u3.Id, "User");

            rm.Create(new IdentityRole("Admin"));
            if (!um.IsInRole(u1.Id, "Admin")) um.AddToRole(u1.Id, "Admin");

            rm.Create(new IdentityRole("Approver"));
            if (!um.IsInRole(u3.Id, "Approver")) um.AddToRole(u3.Id, "Approver");

            context.Tags.Add(new Tag { Name = "dog" });
            context.Tags.Add(new Tag { Name = "cat" });
            context.Tags.Add(new Tag { Name = "fish" });
            context.SaveChanges();
            base.Seed(context);
        }
        


            /*
        public void InitializeDatabase(ApplicationDbContext context)
        {
            if (context.Database.Exists())
            {
                context.Database.Delete();
            }
            context.Database.Create();
            RoleStore<IdentityRole> rs = new RoleStore<IdentityRole>(context);
            UserStore<ApplicationUser> us = new UserStore<ApplicationUser>(context);

            RoleManager<IdentityRole> rm = new RoleManager<IdentityRole>(rs);
            UserManager<ApplicationUser> um = new UserManager<ApplicationUser>(us);

            IdentityResult ir;

            ApplicationUser u1 = createUser("tguan1@example.org", false);
            ApplicationUser u2 = createUser("tguan2@example.org", true);
            ApplicationUser u3 = createUser("tguan3@example.org", false);


            ir = um.Create(u1, "tguan111");
            //u1 = um.FindByName(u1.UserName);
            ir = um.Create(u2, "tguan222");
            //u2 = um.FindByName(u2.UserName);
            ir = um.Create(u3, "tguan333");
            //u3 = um.FindByName(u3.UserName);

            rm.Create(new IdentityRole("User"));
            if (!um.IsInRole(u1.Id, "User")) um.AddToRole(u1.Id, "User");
            if (!um.IsInRole(u2.Id, "User")) um.AddToRole(u2.Id, "User");
            if (!um.IsInRole(u3.Id, "User")) um.AddToRole(u3.Id, "User");

            rm.Create(new IdentityRole("Admin"));
            if (!um.IsInRole(u1.Id, "Admin")) um.AddToRole(u1.Id, "Admin");

            rm.Create(new IdentityRole("Approver"));
            if (!um.IsInRole(u3.Id, "Approver")) um.AddToRole(u3.Id, "Approver");

            context.Tags.Add(new Tag { Name = "dog" });
            context.Tags.Add(new Tag { Name = "cat" });
            context.Tags.Add(new Tag { Name = "fish" });
            context.SaveChanges();
            //base.Seed(context);
            WebSecurity.InitializeDatabaseConnection("DefaultConnection","AspNetUsers","Id","UserName",true);
        }*/

        private ApplicationUser createUser(String Name,bool A)
        {
            ApplicationUser u = new ApplicationUser(Name,A);
            u.Email = Name;
            return u;
        }
    }
}