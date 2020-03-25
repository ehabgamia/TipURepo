using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.PCL.Service;
using VideoBrek.Views;
using VideoBrek.Views.CustomPages;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;

namespace VideoBrek.ViewModels.MRCATabbedPage
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public ProfileViewModel(INavigation navigation)
        {
            Navigation = navigation;
            UserProfileDetails = GlobalConstant.UserProfileDetails;
        }

        #region Fields
        public INavigation Navigation { get; set; }

        SharedPreference _objShared = new SharedPreference();
        //UserDetailsModel registerModel = new UserDetailsModel();
        #endregion

        #region Binding Properties
        bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set
            {
                _IsLoading = value;
                OnPropertyChanged();
            }
        }

        private UserProfileModel _UserProfileDetails;
        public UserProfileModel UserProfileDetails
        {
            get
            {
                return _UserProfileDetails;
            }
            set
            {
                _UserProfileDetails = value;
                OnPropertyChanged(nameof(UserProfileDetails));

            }
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        ICommand _Toggled;
        public ICommand Toggled =>
        _Toggled ?? (_Toggled = new Command(async () => await updateUserProfileDetails().ConfigureAwait(true)));

        ICommand _PrivacyPolicyViewTap;
        public ICommand PrivacyPolicyViewTap =>
        _PrivacyPolicyViewTap ?? (_PrivacyPolicyViewTap = new Command(async () => await gotoPrivacyPolicy().ConfigureAwait(true)));

        #endregion


        #region Methods


        private async Task updateUserProfileDetails()
        {

            if (IsLoading)
                return;
            IsLoading = true;
            try
            {
                UserProfileSettingsModel userProfileSettingsModel = new UserProfileSettingsModel();
                userProfileSettingsModel.ApplowLocation = (UserProfileDetails.UserProfileConfig.AllowLocation == true) ? 1 : 0;
                userProfileSettingsModel.HideContinueWatchingRow = (UserProfileDetails.UserProfileConfig.HideContinueWatchingRow == true) ? true :false;
                userProfileSettingsModel.EnableLightTheme = (UserProfileDetails.UserProfileConfig.EnableLightTheme == true) ? true : false;
                userProfileSettingsModel.DownloadOnlyOverWiFi = (UserProfileDetails.UserProfileConfig.DownloadOnlyOverWiFi == true) ? true : false;
                userProfileSettingsModel.BeginPlaybackAutomatically = (UserProfileDetails.UserProfileConfig.BeginPlaybackAutomatically == true) ? true : false;
                userProfileSettingsModel.AutoplayNextVideo = (UserProfileDetails.UserProfileConfig.AutoplayNextVideo == true) ? true : false;
                userProfileSettingsModel.BackgroundAudioPlayBack = (UserProfileDetails.UserProfileConfig.BackgroundAudioPlayBack == true) ? true : false;
                userProfileSettingsModel.UserVerified = UserProfileDetails.UserProfileConfig.UserVerified;
                userProfileSettingsModel.UserId = UserProfileDetails.UserProfileConfig.UserId;
                userProfileSettingsModel.PhoneNumber = UserProfileDetails.UserProfileConfig.PhoneNumber;
                userProfileSettingsModel.Email = UserProfileDetails.UserProfileConfig.Email;
                userProfileSettingsModel.StreamQualityId = UserProfileDetails.UserProfileConfig.StreamQualityId;

                var getupdateUserSettings = await Task.Run(() => new MediaHandlerService().updateUserSettings(userProfileSettingsModel, MediaHandlerUrl.UpdateSettings));
                if (getupdateUserSettings.Status == 200)
                {
                    string strUserProfileDetail = JsonConvert.SerializeObject(UserProfileDetails);
                    await _objShared.SaveApplicationProperty("UserProfileDetails", strUserProfileDetail);
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastMessage(getupdateUserSettings.Message, ToastLength.Short);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //CrossToastPopUp.Current.ShowToastMessage(ex.Message, ToastLength.Short);
                //Crashes.TrackError(ex);
            }
            finally
            {
                IsLoading = false;
            }

        }


        public async void GotoLogOut()
        {
            if (IsLoading)
                return;
            try
            {
                IsLoading = true;
                GlobalConstant.UserProfileDetails = null;
                GlobalConstant.AccessToken = "";
                await _objShared.SaveApplicationProperty("UserProfileDetails", "");
                await Task.Run(() =>
                {
                    IsLoading = true;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        Application.Current.MainPage = new NavigationPage(new Views.MainPage());
                    });
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //CrossToastPopUp.Current.ShowToastMessage(ex.Message, ToastLength.Short);
                //Crashes.TrackError(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task gotoPrivacyPolicy()
        {
            if (IsLoading)
                return;
            try
            {
                await Task.Run(() =>
                {
                    IsLoading = true;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PushModalAsync(new NavigationPage(new VideoBrek.Views.TermsAndConditions.TermsAndConditions()), true);
                    });
                });

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //CrossToastPopUp.Current.ShowToastMessage(ex.Message, ToastLength.Short);
                //Crashes.TrackError(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        #endregion
    }
}
