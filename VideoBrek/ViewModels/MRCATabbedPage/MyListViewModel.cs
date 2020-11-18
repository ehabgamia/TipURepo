using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.PCL.Service;
using VideoBrek.ViewModels.Explore;
using VideoBrek.Views;
using VideoBrek.Views.CustomPages;
using VideoBrek.Views.MRCATabbedPage.Explore;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;
using static VideoBrek.Models.MediaHandlerModel;

namespace VideoBrek.ViewModels.MRCATabbedPage
{
    public class MyListViewModel : INotifyPropertyChanged
    {
        public MyListViewModel(INavigation navigation)
        {
            Navigation = navigation;

            GetAllMyList.Execute(null);

            MessagingCenter.Subscribe<List<GetMediasModel>>(this, "reloadMyList", sender =>
            {
                MyDataSourceAll = sender;
                refreshDataSource();
            });
        }

        #region Fields
        public INavigation Navigation { get; set; }
        bool _IsLoading;
        SharedPreference _objShared = new SharedPreference();
        #endregion

        #region Binding Properties

        bool _IsLoaderRunning = false;
        public bool IsLoaderRunning
        {
            get { return _IsLoaderRunning; }
            set { _IsLoaderRunning = value; OnPropertyChanged("IsLoaderRunning"); }
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

        //public List<AllMediaModel> MyDataSourceAll { get; set; }


        public List<AllMediaModel> _CollectionViewDataSource;
        public List<AllMediaModel> CollectionViewDataSource
        {
            get { return _CollectionViewDataSource; }
            set
            {
                _CollectionViewDataSource = value;
                OnPropertyChanged();
            }
        }


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
                OnPropertyChanged(nameof(SelectedAllMedia));

            }
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        ICommand _getAllMyList;
        public ICommand GetAllMyList =>
        _getAllMyList ?? (_getAllMyList = new Command(async () => await getAllMyList()));


        ICommand _OnPullDownRefresh;
        public ICommand OnPullDownRefresh =>
        _OnPullDownRefresh ?? (_OnPullDownRefresh = new Command(async () => await getAllMyList().ConfigureAwait(true)));

        ICommand _ViewItemTap;
        public ICommand ViewItemTap =>
        _ViewItemTap ?? (_ViewItemTap = new Command<AllMediaModel>(async (m) => await gotoVideoDetails(m).ConfigureAwait(true)));

        #endregion

        #region Methods
        public async Task getAllMyList()
        {
            if (IsLoading)
                return;
            IsLoading = true;
            try
            {
                ////CollectionViewDataSource = MyDataSourceAll.ToList().OrderBy(a => a.DisplayOrder).ToList().FirstOrDefault().Media;
                //AddMyListModel addMyListModel = new AddMyListModel() { UserID = GlobalConstant.UserProfileDetails.UserId.ToString(), MediaID = "" };
                //var getAllMyListData = await Task.Run(() => new MediaHandlerService().getAddMyList(addMyListModel, MediaHandlerUrl.addtomylist));
                //if (getAllMyListData.Status == 200)
                //{
                //    MyDataSourceAll = JsonConvert.DeserializeObject<List<UserMyListModel>>(getAllMyListData.Response.ToString());
                //    Device.BeginInvokeOnMainThread(async () =>
                //    {
                //        if (MyDataSourceAll.Count > 0)
                //    {
                //        refreshDataSource();
                //    }
                //    });

                //}
                //else
                //{
                //    CrossToastPopUp.Current.ShowToastMessage(getAllMyListData.Message, ToastLength.Short);
                //}

                refreshDataSource();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                IsLoading = false;
                //CrossToastPopUp.Current.ShowToastMessage(ex.Message, ToastLength.Short);
                //Crashes.TrackError(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task gotoVideoDetails(AllMediaModel allMediaModel = null)
        {
            if (IsLoaderRunning)
                return;
            try
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    IsLoaderRunning = true;
                    var GetVideo = await Task.Run(() => GetVideoAsync(allMediaModel.CloudUrl));
                    if (GetVideo != null)
                    {
                        allMediaModel.Title = GetVideo.Title;
                        allMediaModel.Description = GetVideo.Description;

                        var VideoMediaStreamInfos = await Task.Run(() => GetVideoMediaStreamInfosAsync(allMediaModel.CloudUrl));
                        if (VideoMediaStreamInfos != null)
                        {
                            if (VideoMediaStreamInfos.Url != null)
                            {
                                allMediaModel.AliasCloudUrl = VideoMediaStreamInfos.Url;
                                await Navigation.PushModalAsync(new NavigationPage(new Views.MediaDetails.MediaDetails(allMediaModel)));
                                IsLoaderRunning = false;
                            }
                        }
                    }
                    else
                    {
                        IsLoaderRunning = false;
                        CrossToastPopUp.Current.ShowToastMessage("Video Details not getting...!", ToastLength.Short);
                    }

                });
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                IsLoaderRunning = false;
            }
            finally
            {
                IsLoaderRunning = false;
            }
        }

        private void refreshDataSource()
        {
            if (MyDataSourceAll.Count > 0)
            {
                CollectionViewDataSource = MyDataSourceAll.SelectMany(a => a.Media).Where(p => p.IsAddedToMyList == true).ToList();
                //GlobalConstant.MyListIds = CollectionViewDataSource.Select(a => a.MediaId).ToList();
            }
        }

        #endregion
    }
}
