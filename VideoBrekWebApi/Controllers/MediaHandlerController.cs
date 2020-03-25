using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using VideoBrekWebApi.Models;
using VideoBrekWebApi.ViewModels;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace VideoBrekWebApi.Controllers
{
    public class MediaHandlerController : ApiController
    {
        private readonly DBContexVideoApp db = new DBContexVideoApp();

        [Route("api/MediaHandler/UpdateSettings")]
        [HttpPost]
        public async Task<VideoAppResult> UpdateSettings(UserProfileSettingsModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _userProfile = db.UserProfile.Where(a => a.Id == model.UserId).FirstOrDefault();
                    if (_userProfile != null)
                    {
                        var _userProfileConfig = db.UserProfileConfig.Where(a => a.UserId == _userProfile.Id).FirstOrDefault();
                        _userProfileConfig.Email = _userProfileConfig.Email;
                        _userProfileConfig.PhoneNumber = _userProfileConfig.PhoneNumber;
                        _userProfileConfig.UserVerified = model.UserVerified;
                        _userProfileConfig.ApplowLocation = model.ApplowLocation;
                        _userProfileConfig.HideContinueWatchingRow = model.HideContinueWatchingRow;
                        _userProfileConfig.EnableLightTheme = model.EnableLightTheme;
                        _userProfileConfig.DownloadOnlyOverWiFi = model.DownloadOnlyOverWiFi;
                        _userProfileConfig.BeginPlaybackAutomatically = model.BeginPlaybackAutomatically;
                        _userProfileConfig.AutoplayNextVideo = model.AutoplayNextVideo;
                        _userProfileConfig.BackgroundAudioPlayBack = model.BackgroundAudioPlayBack;
                        _userProfileConfig.StreamQualityId = model.StreamQualityId;
                        db.SaveChanges();
                        return new VideoAppResult { Message = "Success", Status = 200, Response = model };
                    }


                }
                return new VideoAppResult { Message = "", Status = 0, Response = null };

            }
            catch (Exception ex)
            {
                return new VideoAppResult { Message = ex.Message.ToString(), Status = 0, Response = null };
            }
        }

    }
}
