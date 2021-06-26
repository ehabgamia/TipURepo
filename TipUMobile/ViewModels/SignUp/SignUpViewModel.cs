using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoBrek.Base;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.Validator;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;

namespace VideoBrek.ViewModels.SignUp
{
    public class SignUpViewModel : ViewsModelBase, INotifyPropertyChanged
    {
        SharedPreference _objShared = new SharedPreference();
        private ValidatableObject<string> _fullName;
        private ValidatableObject<string> _email;
        private ValidatableObject<string> _PhoneNumber;
        private ValidatableObject<string> _password;
        private ValidatableObject<string> _confirmPassword;
        private bool _isValid;
        public SignUpViewModel(INavigation navigation)
        {
            Navigation = navigation;
            _fullName = new ValidatableObject<string>();
            _email = new ValidatableObject<string>();
            _PhoneNumber = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            _confirmPassword = new ValidatableObject<string>();
            AddValidations();
        }

        #region Fields
        public INavigation Navigation { get; set; }
        bool _IsLoading;

        #endregion

        #region Binding Properties
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
        public ICommand ValidateFullNameCommand => new Command(() => ValidateFullName());

        public ICommand ValidateEmailCommand => new Command(() => ValidateEmail());
        public ICommand ValidatePhoneNumberCommand => new Command(() => ValidatePhoneNumber());

        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());
        public ICommand ValidateConfirmPasswordCommand => new Command(() => ValidateConfirmPassword());

        ICommand _NextClicked;
        public ICommand NextClicked =>
        _NextClicked ?? (_NextClicked = new Command(async () => await registerUser()));

        ICommand _ClosedPresentPage;
        public ICommand ClosedPresentPage =>
        _ClosedPresentPage ?? (_ClosedPresentPage = new Command(async () => await gotoClosedPresentPage().ConfigureAwait(true)));
        #endregion


        #region Methods
        private async Task registerUser()
        {
            try
            {
                bool isValid = Validate();

                if (isValid)
                {
                    UserProfileModel registerModel = new UserProfileModel
                    {
                        UserId = 0,
                        name = FullName.Value,
                        userName = FullName.Value,
                        Surname = FullName.Value,
                        EmailAddress = Email.Value,
                        Email = Email.Value,
                        PhoneNumber = PhoneNumber.Value,
                        Password = Password.Value,
                        UserVerified = true,
                        IsActive = true,
                        Latitude = GlobalConstant.Latitude,
                        Longitude = GlobalConstant.Longitude,
                        UserTypeId = 0,
                       
                        UserProfileConfig = new UserProfileConfigModel()
                        {
                            UserId = 0,
                            AllowLocation = true,
                            HideContinueWatchingRow = true,
                            EnableLightTheme = true,
                            DownloadOnlyOverWiFi = true,
                            StreamQualityId = 7,
                            BeginPlaybackAutomatically = true,
                            AutoplayNextVideo = true,
                            BackgroundAudioPlayBack = true,
                            PrivacyPolicyId = 0
                        }
                    };
                    await Task.Run(() =>
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Navigation.PushModalAsync(new NavigationPage(new Views.TermsAndConditions.TermsAndConditions(registerModel)), true);
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                await  Application.Current.MainPage.DisplayAlert("Alert!", ex.Message, "OK");
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
                CrossToastPopUp.Current.ShowToastMessage(ex.Message, ToastLength.Short);
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
                bool isValid = Validate();

                if (isValid)
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
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage(ex.Message, ToastLength.Short);
                //Crashes.TrackError(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task gotoLogInPage()
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
                        await Navigation.PushAsync(new VideoBrek.Views.LogIn.LogIn());
                    });
                });
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage(ex.Message, ToastLength.Short);
                //Crashes.TrackError(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }
        #endregion

        #region Validate
        public ValidatableObject<string> FullName
        {
            get
            {  return _fullName; } set{ _fullName = value; RaisePropertyChanged(() => FullName);}
        }

        public ValidatableObject<string> Email
        {
            get
            { return _email;} set{_email = value; RaisePropertyChanged(() => Email);}
        }

        public ValidatableObject<string> PhoneNumber
        {
            get{ return _PhoneNumber;} set{ _PhoneNumber = value; RaisePropertyChanged(() => PhoneNumber);}
        }

        public ValidatableObject<string> Password
        {
            get { return _password; } set { _password = value; RaisePropertyChanged(() => Password);}
        }

        public ValidatableObject<string> ConfirmPassword
        {
            get{ return _confirmPassword; } set { _confirmPassword = value;RaisePropertyChanged(() => ConfirmPassword);}
        }

        public bool IsValid
        {
            get { return _isValid; } set { _isValid = value; RaisePropertyChanged(() => IsValid);}
        }

        public bool Validate()
        {
            bool isFullName = ValidateFullName();
            bool isEmail = ValidateEmail();
            bool isPhoneNumber = ValidatePhoneNumber();
            bool isPassword = ValidatePassword();
            bool isConfirmPassword = ValidateConfirmPassword();
            return isFullName && isEmail && isPhoneNumber && isPassword && isConfirmPassword;
        }

        private bool ValidateFullName() {return _fullName.Validate(); }

        private bool ValidateEmail() {return _email.Validate();}

        private bool ValidatePhoneNumber() { return _PhoneNumber.Validate();}

        private bool ValidatePassword() { return _password.Validate();}

        private bool ValidateConfirmPassword() { return _confirmPassword.Validate();}

        private void AddValidations()
        {
            _fullName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Full Name First" });
            _email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Email First" });
            _PhoneNumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Phone Number First" });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Password First" });
            _confirmPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Enter Confirm Password First" });
        }

        #endregion Validate
    }
}
