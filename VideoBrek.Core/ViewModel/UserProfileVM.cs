using System;
using System.Collections.Generic;
using System.Text;

namespace VideoBrek.Core.ViewModel
{
    //[Table("UserProfile")]
    public class UserProfileVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public bool UserVerified { get; set; }
        public bool IsActive { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string CreateDtTm { get; set; }
        public string VerifyDtTm { get; set; }

        //public virtual UserProfileConfigModel UserProfileConfig { get; set; }

        public virtual List<UserDeviceVM> UserDevice { get; set; }
        public virtual List<UserMyListVM> UserMyList { get; set; }

    }
}