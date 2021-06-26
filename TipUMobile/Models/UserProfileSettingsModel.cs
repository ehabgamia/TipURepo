using System;
namespace VideoBrek.Models
{
    public class UserProfileSettingsModel
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int UserVerified { get; set; }
        public int ApplowLocation { get; set; }
        //public bool AllowLocation { get; set; }
        public bool HideContinueWatchingRow { get; set; }
        public bool EnableLightTheme { get; set; }
        public bool DownloadOnlyOverWiFi { get; set; }
        public int? StreamQualityId { get; set; }
        public bool BeginPlaybackAutomatically { get; set; }
        public bool AutoplayNextVideo { get; set; }
        public bool BackgroundAudioPlayBack { get; set; }
    }
}