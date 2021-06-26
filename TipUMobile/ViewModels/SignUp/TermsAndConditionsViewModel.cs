using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.PCL.Service;
using VideoBrek.Views;
using VideoBrek.Views.CustomPages;
using VideoBrek.Views.Home;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;

namespace VideoBrek.ViewModels.SignUp
{
    public class TermsAndConditionsViewModel : INotifyPropertyChanged
    {
        SharedPreference _objShared = new SharedPreference();
        public TermsAndConditionsViewModel(INavigation navigation)
        {
            Navigation = navigation;
            getTermsAndConditions();
        }

        #region Fields
        public INavigation Navigation { get; set; }
        public UserProfileModel registerModel = new UserProfileModel();

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

        bool _IsOnSwitch;
        public bool IsOnSwitch
        {
            get { return _IsOnSwitch; }
            set
            {
                _IsOnSwitch = value;
                OnPropertyChanged();
            }
        }

        bool _IsVisibleContinueBtn = true;
        public bool IsVisibleContinueBtn
        {
            get { return _IsVisibleContinueBtn; }
            set
            {
                _IsVisibleContinueBtn = value;
                OnPropertyChanged();
            }
        }

        string _TermsAndConditionText;
        public string TermsAndConditionText
        {
            get { return _TermsAndConditionText; }
            set
            {
                _TermsAndConditionText = value;
                OnPropertyChanged();
            }
        }


        private TermsAndConditionsModel _TermsAndConditionsData;
        public TermsAndConditionsModel TermsAndConditionsData
        {
            get { return _TermsAndConditionsData; }
            set
            {
                _TermsAndConditionsData = value;
                OnPropertyChanged();
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
        ICommand _ContinueClicked;
        public ICommand ContinueClicked =>
        _ContinueClicked ?? (_ContinueClicked = new Command(async () => await gotoPostRegisterData().ConfigureAwait(true)));

        ICommand _SwitchViewTap;
        public ICommand SwitchViewTap =>
        _SwitchViewTap ?? (_SwitchViewTap = new Command(async () => await gotoSwitchTap().ConfigureAwait(true)));

        ICommand _ClosedPresentPage;
        public ICommand ClosedPresentPage =>
        _ClosedPresentPage ?? (_ClosedPresentPage = new Command(async () => await gotoClosedPresentPage().ConfigureAwait(true)));


        #endregion


        #region Methods

        private async Task gotoClosedPresentPage()
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
                        await Navigation.PopModalAsync();
                    });
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //Crashes.TrackError(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task gotoSwitchTap()
        {
            if (IsLoading)
                return;
            try
            {
                if (IsOnSwitch)
                {
                    IsOnSwitch = false;
                }
                else
                {
                    IsOnSwitch = true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //Crashes.TrackError(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }


        public async Task gotoPostRegisterData()
        {
            IsVisibleContinueBtn = false;
            if (IsLoading)
                return;
            if (!IsOnSwitch)
            {
                CrossToastPopUp.Current.ShowToastMessage("Please accept terms and conditions first.", ToastLength.Short);
                IsVisibleContinueBtn = true;
                return;
            }
            try
            {
                await Task.Run(async () =>
                {
                    IsLoading = true;
                    //registerModel.PrivacyPolicyId = TermsAndConditionsData.Id;
                    //registerModel.UserProfileConfig.PrivacyPolicyId = TermsAndConditionsData.Id;
                    var result = await new RegisterService().RegisterUser(registerModel, AppUsersUrl.Register);
                    if (result.Status == 200)
                    {
                        AppLoginModel authenticateModel = new AppLoginModel
                        {
                            userNameOrEmailAddress = registerModel.userName,
                            Password = registerModel.Password,
                            rememberClient = true
                        };
                        var authenticaterResult = await new AppUsersService().GetLoginDetail(authenticateModel, AppUsersUrl.Login);
                        if (authenticaterResult.Status == 200)
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                CrossToastPopUp.Current.ShowToastMessage(result.Message, ToastLength.Short);
                                var UserData = JsonConvert.DeserializeObject<UserProfileModel>(authenticaterResult.Response.ToString());
                            GlobalConstant.AccessToken = UserData.AccessToken;
                            GlobalConstant.UserProfileDetails = UserData;
                            await _objShared.SaveApplicationProperty("UserProfileDetails", authenticaterResult.Response.ToString());

                            //CrossToastPopUp.Current.ShowToastMessage(authenticaterResult.Message, ToastLength.Short);
                            Application.Current.MainPage = new NavigationPage(new Home());
                        });
                        }
                    }
                    else
                    {
                        CrossToastPopUp.Current.ShowToastMessage(result.Message, ToastLength.Short);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //Crashes.TrackError(ex);
                IsLoading = false;
                IsVisibleContinueBtn = true;
            }
            finally
            {
                IsLoading = false;
                //IsVisibleContinueBtn = true;
            }
        }

        public async Task getTermsAndConditions()
        {
            string html = "<!DOCTYPE html><html><head><h2 style='text-align: center;'><span style='color:#ff9900;'><strong> Terms & Conditions </strong></span></h2></head><body style='height: auto; padding: 5px; width: 90 %;/><p style = 'text-align: justify;'>";
            if (IsLoading)
                return;
            IsLoading = true;
            try
            {
                //var getPrivacyPolicy = await Task.Run(() => new MediaHandlerService().getData(MediaHandlerUrl.getTermsAgreement));
                var getMedia = await Task.Run(() => new MediaHandlerService().getData(MediaHandlerUrl.getTermsAgreement));
                if (getMedia.Status == 200)
                {
                    TermsAndConditionsData = JsonConvert.DeserializeObject<TermsAndConditionsModel>(getMedia.Response.ToString());

                    if (TermsAndConditionsData != null)
                    {
                        String[] spearator = { "\r\n" };
                        string[] strlist = TermsAndConditionsData.TermsText.Split(spearator,
                        StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;
                        foreach (String sitem in strlist)
                        {
                            html += (i != 0) ? sitem + "<br/>" : "";
                            i++;
                        }
                        html += "<br/><br/></p></body></html>";
                        TermsAndConditionText = html;
                    }
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastMessage(getMedia.Message, ToastLength.Short);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

            }
            finally
            {
                IsLoading = false;
            }
        }
        #endregion
    }
}