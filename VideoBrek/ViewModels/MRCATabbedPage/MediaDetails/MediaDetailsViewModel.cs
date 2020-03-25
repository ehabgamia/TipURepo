using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoBrek.Extensions;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.PCL.Service;
using VideoBrek.ViewModels.MRCATabbedPage;
using VideoBrek.Views.CustomPages;
using VideoBrek.Views.MediaDetails;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;
using YoutubeExplode;
using YoutubeExplode.Models;
using YoutubeExplode.Models.MediaStreams;
using static VideoBrek.Models.MediaHandlerModel;

namespace VideoBrek.ViewModels.Explore
{
    public class MediaDetailsViewModel : INotifyPropertyChanged
    {
        public MediaDetailsViewModel(INavigation navigation)
        {
            Navigation = navigation;

          
        }

        #region Fields
        public INavigation Navigation { get; set; }
        public EventHandler reloadMyList;
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


        string _AddToMyListIconSource;
        public string AddToMyListIconSource
        {
            get { return _AddToMyListIconSource; }
            set
            {
                _AddToMyListIconSource = value;
                OnPropertyChanged();
            }
        }

        string _AddToMyListIconText;
        public string AddToMyListIconText
        {
            get { return _AddToMyListIconText; }
            set
            {
                _AddToMyListIconText = value;
                OnPropertyChanged();
            }
        }

        string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }

        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged();
            }
        }


        //public List<UserMyListModel> MyDataSourceAll { get; set; }

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

        ICommand _AddToMyListViewTap;
        public ICommand AddToMyListViewTap =>
        _AddToMyListViewTap ?? (_AddToMyListViewTap = new Command(async () => await addToMyList().ConfigureAwait(true)));

        ICommand _ClosedPresentPage;
        public ICommand ClosedPresentPage =>
        _ClosedPresentPage ?? (_ClosedPresentPage = new Command(async () => await gotoClosedPresentPage().ConfigureAwait(true)));

        ICommand _ShareViewTap;
        public ICommand ShareViewTap =>
        _ShareViewTap ?? (_ShareViewTap = new Command(async () => await gotoShareData().ConfigureAwait(true)));


        #endregion


        #region Methods
        private async Task gotoShareData()
        {
            await ShareData.ShareUri("https://www.youtube.com/watch?v="+ SelectedAllMedia.CloudUrl);
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
                        await Navigation.PopModalAsync(true);
                    });
                });
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


        public async Task addToMyList()
        {
            if (IsLoading)
                return;
            IsLoading = true;
            try
            {
                ////CollectionViewDataSource = MyDataSourceAll.ToList().OrderBy(a => a.DisplayOrder).ToList().FirstOrDefault().Media;
                //AddMyListModel addMyListModel = new AddMyListModel() { UserID = GlobalConstant.UserProfileDetails.UserId.ToString(), MediaID = SelectedAllMedia.Id.ToString() };
                //var getAllMyListData = await Task.Run(() => new MediaHandlerService().getAddMyList(addMyListModel, MediaHandlerUrl.addtomylist));
                //if (getAllMyListData.Status == 200)
                //{
                //    MyDataSourceAll = JsonConvert.DeserializeObject<List<UserMyListModel>>(getAllMyListData.Response.ToString());
                //    if (MyDataSourceAll.Count > 0)
                //    {
                //        MessagingCenter.Send(MyDataSourceAll, "reloadMyList");
                //        AddToMyListIconSource = (!GlobalConstant.MyListIds.Contains(SelectedAllMedia.Id)) ? "ic_AddToMyList.png" : "ic_AddedToMyList.png";
                //        AddToMyListIconText = (!GlobalConstant.MyListIds.Contains(SelectedAllMedia.Id)) ? "Save" : "Saved";
                //    }
                //}
                //CrossToastPopUp.Current.ShowToastMessage(getAllMyListData.Message, ToastLength.Short);

                if (MediaHandlerModel.MyDataSourceAll.SelectMany(a => a.Media).ToList().Where(p => p.Id == SelectedAllMedia.Id).FirstOrDefault().IsAddedToMyList)
                {
                    MediaHandlerModel.MyDataSourceAll.SelectMany(a => a.Media).ToList().Where(p => p.Id == SelectedAllMedia.Id).FirstOrDefault().IsAddedToMyList = false;
                    CrossToastPopUp.Current.ShowToastMessage("Remove From List", ToastLength.Long);
                }
                else
                {
                    MediaHandlerModel.MyDataSourceAll.SelectMany(a => a.Media).ToList().Where(p => p.Id == SelectedAllMedia.Id).FirstOrDefault().IsAddedToMyList = true;
                    CrossToastPopUp.Current.ShowToastMessage("Added To List", ToastLength.Long);
                }

                AddToMyListIconSource = (!MediaHandlerModel.MyDataSourceAll.SelectMany(a => a.Media).ToList().Where(p => p.Id == SelectedAllMedia.Id).FirstOrDefault().IsAddedToMyList) ? "ic_AddToMyList.png" : "ic_AddedToMyList.png";
                AddToMyListIconText = (!MediaHandlerModel.MyDataSourceAll.SelectMany(a => a.Media).ToList().Where(p => p.Id == SelectedAllMedia.Id).FirstOrDefault().IsAddedToMyList) ? "Save" : "Saved";
                MessagingCenter.Send(MyDataSourceAll, "reloadMyList");
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


        private async Task gotoVideoPlayView(AllMediaModel allMediaModel = null)
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
                        await Navigation.PushAsync(new NavigationPage(new VideoPlay(allMediaModel)), true);
                    });
                });
            }
            catch (Exception ex)
            {
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
