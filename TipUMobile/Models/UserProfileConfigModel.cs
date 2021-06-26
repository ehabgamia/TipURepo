using System;
namespace VideoBrek.Models
{
    public class UserProfileConfigModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserVerified { get; set; }
        public int ApplowLocation { get; set; }
        public bool AllowLocation { get; set; }
        public bool HideContinueWatchingRow { get; set; }
        public bool EnableLightTheme { get; set; }
        public bool IsActive { get; set; }
        public bool DownloadOnlyOverWiFi { get; set; }
        public int? StreamQualityId { get; set; }
        public bool BeginPlaybackAutomatically { get; set; }
        public bool AutoplayNextVideo { get; set; }
        public bool BackgroundAudioPlayBack { get; set; }
        public int PrivacyPolicyId { get; set; }
        public string CreateDtTm { get; set; }
        public StreamQualityModel StreamQuality { get; set; }
        public UserProfileModel User { get; set; }
    }

   
}