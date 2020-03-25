using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoBrekWebApi.Models
{
    [Table("UserProfileConfig")]
    public class UserProfileConfigModel : BaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserVerified { get; set; }
        public int ApplowLocation { get; set; }
        public bool AllowLocation { get; set; }
        public bool HideContinueWatchingRow { get; set; }
        public bool EnableLightTheme { get; set; }
        public bool IsActive { get; set; }
        public bool DownloadOnlyOverWiFi { get; set; }
        public bool BeginPlaybackAutomatically { get; set; }
        public bool AutoplayNextVideo { get; set; }
        public bool BackgroundAudioPlayBack { get; set; }
        public string CreateDtTm { get; set; }

        public virtual StreamQualityModel StreamQuality { get; set; }
        public int? StreamQualityId { get; set; }

        public virtual UserProfileModel User { get; set; }
        public int UserId { get; set; }

    }
}