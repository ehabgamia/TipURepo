using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static VideoBrek.Models.MediaHandlerModel;

namespace VideoBrek.ViewModels.MRCATabbedPage.MediaDetails
{
    public class VideoPlayViewModel : INotifyPropertyChanged
    {
        public VideoPlayViewModel(INavigation navigation)
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

        //public AllMedia SelectedAllMedia { get; set; }
        private AllMediaModel _SelectedAllMedia;
        public AllMediaModel SelectedAllMedia
        {
            get
            {
                return _SelectedAllMedia;
            }
            set
            {
                _SelectedAllMedia = value;
                OnPropertyChanged();
            }

        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands

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
                        await Navigation.PopAsync(true);
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
    }
}
