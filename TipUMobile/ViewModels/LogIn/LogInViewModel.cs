using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoBrek.Base;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.PCL.Service;
using VideoBrek.Validator;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;

namespace VideoBrek.ViewModels.LogIn
{
    public class LogInViewModel : ViewsModelBase, INotifyPropertyChanged
    {
        SharedPreference _objShared = new SharedPreference();
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;
        private ValidatableObject<string> _Result;
        private bool _isValid;
        public LogInViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            _Result = new ValidatableObject<string>();
            AddValidations();
        }

        #region Fields
        public INavigation Navigation { get; set; }
        bool _IsLoading;

        #endregion

        #region Binding Properties
        bool _IsButtonVisible = true;
        public bool IsButtonVisible
        {
            get { return _IsButtonVisible; }
            set { _IsButtonVisible = value;  OnPropertyChanged();}
        }

        public bool IsLoading
        {
            get { return _IsLoading; }
            set
            {
                _IsLoading = value;
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
        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());
        ICommand _LogInClicked;
        public ICommand LogInClicked =>
        _LogInClicked ?? (_LogInClicked = new Command(async () => await GetUserLoginAsync()));

        ICommand _PasswordResetClicked;
        public ICommand PasswordResetClicked =>
        _PasswordResetClicked ?? (_PasswordResetClicked = new Command(async () => await gotoPasswordReset()));

        ICommand _ClosedPresentPage;
        public ICommand ClosedPresentPage =>
        _ClosedPresentPage ?? (_ClosedPresentPage = new Command(async () => await gotoClosedPresentPage().ConfigureAwait(true)));
        #endregion
        #region Methods
        private async Task GetUserLoginAsync()
        {
            try
            {
               IsValid = true;
                bool isValid = Validate();
            
                if (isValid)
                {
                    AppLoginModel authenticateModel = new AppLoginModel
                    {
                        userNameOrEmailAddress = UserName.Value,
                        Password = Password.Value,
                        rememberClient = true
                    };

                    IsButtonVisible = false;
                    var    result = await new AppUsersService().GetLoginDetail(authenticateModel, AppUsersUrl.Login);

                    if (result.Status == 200)
                    {
                        var UserData = JsonConvert.DeserializeObject<UserProfileModel>(result.Response.ToString());
                        var UserDataProfile = JsonConvert.DeserializeObject<UserProfileConfigModel>(result.Response.ToString());

                        UserData.UserProfileConfig = UserDataProfile;

                        GlobalConstant.AccessToken = result.accessToken; // UserData.AccessToken;
                        GlobalConstant.UserProfileDetails = UserData;

                        //await _objShared.SaveApplicationProperty("UserProfileDetails", result.Response.ToString());

                        await gotoHomePage();
                        CrossToastPopUp.Current.ShowToastMessage(result.Message, ToastLength.Short);
                    }
                    else
                    {
                        IsButtonVisible = true;
                        CrossToastPopUp.Current.ShowToastMessage(result.Message, ToastLength.Short);
                    }

                }
                else
                {
                    IsButtonVisible = true;
                    IsValid = false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }



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
                        await Navigation.PopAsync();
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

        public async Task gotoHomePage()
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
                        await Navigation.PushAsync(new Views.Home.Home());
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

        public async Task gotoPasswordReset()
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
                        await Navigation.PushAsync(new Views.LogIn.PasswordRecovery());
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

        #endregion


        #region Validate
        public ValidatableObject<string> UserName
        {
            get { return _userName;} set { _userName = value; RaisePropertyChanged(() => UserName);}
        }

        public ValidatableObject<string> Password
        {
            get {return _password;} set {_password = value; RaisePropertyChanged(() => Password);}
        }

     
        public bool IsValid
        {
            get { return _isValid;} set{ _isValid = value; RaisePropertyChanged(() => IsValid);}
        }

        public bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();
            return isValidUser && isValidPassword;
        }

        private bool ValidateUserName() { return _userName.Validate();}

        private bool ValidatePassword() { return _password.Validate();}

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Email ID First" });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Password First" });
        }

        #endregion Validate

    }
}
