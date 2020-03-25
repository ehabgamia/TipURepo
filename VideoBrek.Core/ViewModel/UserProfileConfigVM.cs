using System;
using System.Collections.Generic;
using System.Text;

namespace VideoBrek.Core.ViewModel
{
    //[Table("UserProfileConfig")]
    public class UserProfileConfigVM
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

        public virtual StreamQualityVM StreamQuality { get; set; }
        public int? StreamQualityId { get; set; }

        public virtual UserProfileVM User { get; set; }
        public int UserId { get; set; }

    }
}