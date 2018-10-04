using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ImageSharingWithCloudStorage.DAL;

namespace ImageSharingWithCloudStorage.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int id { get; set; }
        [MaxLength(40)]
        public virtual String Caption { get; set; }
        [MaxLength(200)]
        public virtual String Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public virtual DateTime DateTaken { get; set; }
        public virtual bool Approved { get; set; }
        //public virtual String user_id { get; set; }
        [ForeignKey("user")]
        
        public virtual String userId { get; set; }
        public virtual ApplicationUser user { get; set; }
        [ForeignKey("tag")]
        public virtual int tagId { get; set; }
        public virtual Tag tag { get; set; }

        //protected ImageSharingDB db = new ImageSharingDB();

        public Image() { }
        public Image(ImageInfo info)
        {
            Caption = info.Caption;
            Description = info.Description;
            DateTaken = info.DateTaken;
            tagId = info.TagId;
            Approved = false;
            //tag = db.Tags.Find(tagId);
            //user = db.Users.SingleOrDefault(u => u.user_id.Equals(info.user_id));
            //userId = user.id;
        }

        public void SetUser(ApplicationUser u)
        {
            this.user = u;
            //this.userId = u.id;
        }
    }
}