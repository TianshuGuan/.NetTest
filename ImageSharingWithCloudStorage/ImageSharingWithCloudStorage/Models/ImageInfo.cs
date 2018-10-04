using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ImageSharingWithCloudStorage.DAL;
namespace ImageSharingWithCloudStorage.Models
{
    public class ImageInfo
    {
        [Required]
        [StringLength(40)]
        public String Caption { get; set; }
        [Required]
        public int TagId { get; set; }
        [Required]
        [StringLength(200)]
        public String Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}",ApplyFormatInEditMode = true)]
        public DateTime DateTaken { get; set; }

        [ScaffoldColumn(false)]
        public int id;
        [ScaffoldColumn(false)]
        public String TagName { get; set; }
        [ScaffoldColumn(false)]
        public String user_id { get; set; }
        [ScaffoldColumn(false)]
        public String URL;
        public ImageInfo()
        {

        }
        public ImageInfo(Image i)
        {
            id = i.id;
            Caption = i.Caption;
            TagId = i.tagId;
            //TagName = i.tag.Name;
            user_id = i.user.Id;
            Description = i.Description;
            DateTaken = i.DateTaken;
            URL = ImageStorage.ImageURl(new System.Web.Mvc.UrlHelper(), id);
        }
    }
}