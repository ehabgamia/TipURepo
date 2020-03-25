using System;
using System.Collections.Generic;

namespace VideoBrek.Models
{
    public class StreamQualityModel
    {
        public int StreamQualityId { get; set; }
        public string StreatQualityName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedDtTm { get; set; }
        public int CreatedBy { get; set; }
        public List<UserProfileConfigModel> UserProfileConfig { get; set; }
    }
}