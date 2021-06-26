using System;
using System.Collections.Generic;

namespace VideoBrek.Models
{
    public class UserProfileModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public bool UserVerified { get; set; }
        public bool IsActive { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int UserTypeId { get; set; }
        //public int PrivacyPolicyId { get; set; }
        
        public string CreateDtTm { get; set; }
        public string VerifyDtTm { get; set; }
        //public PrivacyPolicyModel PrivacyPolicy { get; set; }
        //public UserTypeModel UserType { get; set; }
        public UserProfileConfigModel UserProfileConfig { get; set; }
        public List<UserDeviceModel> UserDevice { get; set; }
        public List<UserMyListModel> UserMyList { get; set; }

        public string userName { get; set; }
        public string name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string[] RoleNames { get; set; }
    }
}
