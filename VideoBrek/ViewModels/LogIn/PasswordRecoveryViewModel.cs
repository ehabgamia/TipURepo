using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.PCL.Service;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;

namespace VideoBrek.ViewModels.LogIn
{
    public class PasswordRecoveryViewModel : INotifyPropertyChanged
    {
        public PasswordRecoveryViewModel(INavigation navigation)
        {
            Navigation = navigation;
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


        string _EmailID;
        public string EmailID
        {
            get { return _EmailID; }
            set
            {
                _EmailID = value;
                OnPropertyChanged();
            }
        }

        bool _IsVisibleSendBtn = true;
        public bool IsVisibleSendBtn
        {
            get { return _IsVisibleSendBtn; }
            set
            {
                _IsVisibleSendBtn = value;
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
        ICommand _SendClicked;
        public ICommand SendClicked =>
        _SendClicked ?? (_SendClicked = new Command(async () => await gotoSend()));

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
        public bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(EmailID))
            {
                CrossToastPopUp.Current.ShowToastMessage("Enter Email First", ToastLength.Short);
                return isValid = false;
            }
            else
            {
                if (!RegexUtilities.IsValidEmail(EmailID))
                {
                    CrossToastPopUp.Current.ShowToastMessage("Enter Valid Email ID First", ToastLength.Short);
                    return isValid = false;
                }
            }
            return isValid;
        }

        public async Task gotoSend()
        {
            
            if (IsLoading)
                return;
            IsLoading = true;
            IsVisibleSendBtn = false;

            if (!IsValid())
                return;

            try
            {
                PasswordResetModel passwordResetModel = new PasswordResetModel() { Email = EmailID };
                await Task.Run(async () =>
                {
                    var result = await new AppUsersService().passwordReset(passwordResetModel, AppUsersUrl.resetpassword);
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (result.Status == 200)
                        {
                            await Navigation.PopToRootAsync(true);
                            CrossToastPopUp.Current.ShowToastMessage(result.Message, ToastLength.Long);
                        }
                        else
                        {
                            await Navigation.PopToRootAsync(true);
                            CrossToastPopUp.Current.ShowToastMessage(result.Message, ToastLength.Long);
                        }
                    });
                });
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
                CrossToastPopUp.Current.ShowToastMessage(ex.Message, ToastLength.Short);
                IsLoading = false;
                IsVisibleSendBtn = true;
            }
            finally
            {
                IsLoading = false;
                //IsVisibleContinueBtn = true;
            }
        }


        #endregion
    }
}
