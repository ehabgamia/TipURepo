using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;

namespace VideoBrek.ViewModels.MainPage
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel(INavigation navigation)
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

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Commands
        ICommand _SignUpClicked;
        public ICommand SignUpClicked =>
        _SignUpClicked ?? (_SignUpClicked = new Command(async () => await gotoSignUpPage()));

        ICommand _LogInClicked;
        public ICommand LogInClicked =>
        _LogInClicked ?? (_LogInClicked = new Command(async () => await gotoLogInPage()));
        #endregion


        #region Methods
        public async Task gotoSignUpPage()
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
                        //await Navigation.PushAsync(new VideoBrek.Views.TermsAndConditions.TermsAndConditions(null),true);
                        await Navigation.PushAsync(new TipUMobile.Views.SignUp.SignUp());
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
    }
}
