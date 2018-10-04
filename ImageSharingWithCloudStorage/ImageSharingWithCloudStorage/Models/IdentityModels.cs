using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace ImageSharingWithCloudStorage.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }

        public virtual bool ADA { get; set; }
        public virtual bool Active { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public ApplicationUser(String u, bool a)
        {

            this.ADA = a;
            this.Active = true;
            this.UserName = u;
            this.Images = new List<Image>();
        }

        public ApplicationUser()
        {
            Active = true;
            this.Images = new List<Image>();
        }
    }
}