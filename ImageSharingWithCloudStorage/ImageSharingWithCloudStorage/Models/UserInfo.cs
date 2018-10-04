using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace ImageSharingWithCloudStorage.Models
{
    public class UserInfo
    {
        [Required]
        [RegularExpression(@"[a-zA-Z0-9_]+")]
        public String user_id { get; set; }
        [Required]
        public bool ADA { get; set; }
    }
}