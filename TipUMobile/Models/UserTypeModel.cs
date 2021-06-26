using System;
using System.Collections.Generic;

namespace VideoBrek.Models
{
    public class UserTypeModel
    {
        public int UserTypeId { get; set; }
        public string UserTypeCode { get; set; }
        public string UserTypeDesc { get; set; }
        public string CreateDtTm { get; set; }
        public bool IsActive { get; set; }
        public List<UserProfileModel> UserProfile { get; set; }
    }
}