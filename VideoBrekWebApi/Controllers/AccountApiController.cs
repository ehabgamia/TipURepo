using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using VideoBrekWebApi.Models;
using VideoBrekWebApi.ViewModels;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace VideoBrekWebApi.Controllers
{
    public class AccountApiController : ApiController
    {

   private readonly DBContexVideoApp db = new DBContexVideoApp();

    [Route("api/AccountApi/Login")]
    [HttpPost]
    public async Task<VideoAppResult> Login(UserLoginViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var _userProfile = db.UserProfile.Where(a => (a.Email == model.Email) && a.Password == model.Password).FirstOrDefault();
                if (_userProfile != null)
                {
                    _userProfile.AccessToken = Guid.NewGuid().ToString();
                    db.SaveChanges();
                    var _UserProfileConfig = db.UserProfileConfig.Where(a => a.UserId == _userProfile.Id).FirstOrDefault();
                    var userProfileViewModel = new UserProfileViewModel
                    {
                        UserId = _userProfile.Id,
                        FullName = _userProfile.FullName,
                        Email = _userProfile.Email,
                        Password = _userProfile.Password,
                        PhoneNumber = _userProfile.PhoneNumber,
                        Latitude = _userProfile.Latitude,
                        Longitude = _userProfile.Longitude,
                        AccessToken = _userProfile.AccessToken,
                        IsActive = _userProfile.IsActive,
                        UserVerified = _userProfile.UserVerified,
                        //UserMyList = _userProfile.UserMyList,
                        UserProfileConfig = _UserProfileConfig,
                    };
                    return new VideoAppResult { Message = "Login Successfully.", Status = 200, Response = userProfileViewModel };
                }
                ModelState.AddModelError("", "Invalid username or password.");
                return new VideoAppResult { Message = "Invalid username or password.", Status = 0, Response = null };

            }
            return new VideoAppResult { Message = "No Record Found.", Status = 0, Response = null };
        }
        catch (Exception ex)
        {
            return new VideoAppResult { Message = ex.ToString(), Status = 0, Response = null };
        }
    }

    [Route("api/AccountApi/Register")]
    [HttpPost]
    public async Task<VideoAppResult> Register(UserProfileViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var _user = db.UserProfile.Where(a => (a.Email == model.Email || a.PhoneNumber == model.PhoneNumber) && a.Password == model.Password).FirstOrDefault();
                if (_user == null)
                {
                    UserProfileModel _userProfileModel = new UserProfileModel();
                    _userProfileModel.FullName = model.FullName;
                    _userProfileModel.Email = model.Email;
                    _userProfileModel.Password = model.Password;
                    _userProfileModel.PhoneNumber = model.PhoneNumber;
                    _userProfileModel.Latitude = model.Latitude;
                    _userProfileModel.Longitude = model.Longitude;
                    _userProfileModel.IsActive = model.IsActive;
                    _userProfileModel.UserVerified = model.UserVerified;
                    _userProfileModel.AccessToken = Guid.NewGuid().ToString();
                    //_userProfileModel.UserMyList = model.UserMyList;
                    _userProfileModel.CreateDtTm = DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt");
                    _userProfileModel.VerifyDtTm = DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt");
                    db.UserProfile.Add(_userProfileModel);
                    db.SaveChanges();

                    UserProfileConfigModel _userProfileConfigModel = new UserProfileConfigModel();
                    _userProfileConfigModel.UserId = _userProfileModel.Id;
                    _userProfileConfigModel.Email = model.Email;
                    _userProfileConfigModel.PhoneNumber = model.PhoneNumber;
                    _userProfileConfigModel.UserVerified = model.UserProfileConfig.UserVerified;
                    _userProfileConfigModel.ApplowLocation = model.UserProfileConfig.ApplowLocation;
                    _userProfileConfigModel.AllowLocation = model.UserProfileConfig.AllowLocation;
                    _userProfileConfigModel.HideContinueWatchingRow = model.UserProfileConfig.HideContinueWatchingRow;
                    _userProfileConfigModel.EnableLightTheme = model.UserProfileConfig.EnableLightTheme;
                    _userProfileConfigModel.IsActive = model.UserProfileConfig.IsActive;
                    _userProfileConfigModel.DownloadOnlyOverWiFi = model.UserProfileConfig.DownloadOnlyOverWiFi;
                    _userProfileConfigModel.BeginPlaybackAutomatically = model.UserProfileConfig.BeginPlaybackAutomatically;
                    _userProfileConfigModel.AutoplayNextVideo = model.UserProfileConfig.AutoplayNextVideo;
                    _userProfileConfigModel.BackgroundAudioPlayBack = model.UserProfileConfig.BackgroundAudioPlayBack;
                    _userProfileConfigModel.StreamQualityId = model.UserProfileConfig.StreamQualityId;
                    _userProfileConfigModel.CreateDtTm = DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt");
                    _userProfileConfigModel.StreamQuality = model.UserProfileConfig.StreamQuality;
                    db.UserProfileConfig.Add(_userProfileConfigModel);
                    db.SaveChanges();

                    model.UserId = _userProfileModel.Id;
                    model.AccessToken = _userProfileModel.AccessToken;
                    model.UserProfileConfig.Id = _userProfileConfigModel.Id;
                    return new VideoAppResult { Message = "Success", Status = 200, Response = model };
                }
                else
                {
                    return new VideoAppResult { Message = "User already exists.", Status = 0, Response = null };
                }

            }
            return new VideoAppResult { Message = "Invalid parameters.", Status = 0, Response = null };

        }
        catch (Exception ex)
        {
            return new VideoAppResult { Message = ex.Message.ToString(), Status = 0, Response = null };
        }
    }

}
}
