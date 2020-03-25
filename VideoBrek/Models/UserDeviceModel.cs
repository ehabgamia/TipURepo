using System;
namespace VideoBrek.Models
{
    public class UserDeviceModel
    {
        public int UserId { get; set; }
        public string CreateDtTm { get; set; }
        public string LastLoginDtTm { get; set; }
        public UserProfileModel User { get; set; }
    }
}