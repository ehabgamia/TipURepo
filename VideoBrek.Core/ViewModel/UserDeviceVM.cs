using System;
using System.Collections.Generic;
using System.Text;

namespace VideoBrek.Core.ViewModel
{
    //[Table("UserDevice")]
    public class UserDeviceVM
    {
        public int Id { get; set; }
        public string CreateDtTm { get; set; }
        public string LastLoginDtTm { get; set; }
        public virtual UserProfileVM User { get; set; }
        public int UserId { get; set; }
    }
}
