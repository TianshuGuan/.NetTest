using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageSharingWithCloudStorage.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int id { get; set; }
        [MaxLength(20)]
        public virtual String user_id { get; set; }
        public virtual bool ADA { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public User() { }

        public User(String uid,bool a)
        {
            this.user_id = uid;
            this.ADA = a;
            this.Images = new List<Image>();
        }
    }
}