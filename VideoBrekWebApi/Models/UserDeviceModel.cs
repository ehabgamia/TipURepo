using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoBrekWebApi.Models
{
    [Table("UserDevice")]
    public class UserDeviceModel
    {
        public int Id { get; set; }
        public string CreateDtTm { get; set; }
        public string LastLoginDtTm { get; set; }
        public virtual UserProfileModel User { get; set; }
        public int UserId { get; set; }
    }
}