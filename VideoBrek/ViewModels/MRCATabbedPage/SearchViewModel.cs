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
using VideoBrek.Views.CustomPages;
using VideoBrek.Views.MRCATabbedPage.Explore;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;
using static VideoBrek.Models.MediaHandlerModel;

namespace VideoBrek.ViewModels.MRCATabbedPage
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        public SearchViewModel(INavigation navigation)
        {
            Navigation = navigation;
            MediaHandlerModel mediaHandlerModel = new MediaHandlerModel();
            this.MyDataSourceAll = MediaHandlerModel.MyDataSourceAll.SelectMany(a => a.Media).ToList();
        }

        #region Fields
        public INavigation Navigation { get; set; }
        #endregion

        #region Binding Properties

        bool _IsLoaderRunning = false;
        public bool IsLoaderRunning
        {
            get { return _IsLoaderRunning; }
            set { _IsLoaderRunning = value; OnPropertyChanged("IsLoaderRunning"); }
        }

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

        string _SearchString;
        public string SearchString
        {
            get { return _SearchString; }
            set
            {
                _SearchString = value;
                OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<AllMediaModel> MyDataSourceAll { get; set; }


        private List<AllMediaModel> _CollectionViewDataSource;
        public List<AllMediaModel> CollectionViewDataSource
        {
            get { return _CollectionViewDataSource; }
            set
            {
                _CollectionViewDataSource = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        ICommand _getAllSearch;
        public ICommand GetAllSearch =>
        _getAllSearch ?? (_getAllSearch = new Command(async () => await getAllSearch()));


        ICommand _OnPullDownRefresh;
        public ICommand OnPullDownRefresh =>
        _OnPullDownRefresh ?? (_OnPullDownRefresh = new Command(async () => await getAllSearch()));

        ICommand _ViewItemTap;
        public ICommand ViewItemTap =>
        _ViewItemTap ?? (_ViewItemTap = new Command<AllMediaModel>(async (m) => await gotoVideoDetails(m).ConfigureAwait(true)));


        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>(async (text) =>
                {
                    SearchString = text.Trim();
                    await getAllSearch();
                }));
            }
        }

        #endregion

        #region Methods
        public async Task getAllSearch()
        {
            if (string.IsNullOrEmpty(SearchString))
                return;
            if (IsLoading)
                return;
            IsLoading = true;
            try
            {
                ////CollectionViewDataSource = MyDataSourceAll.ToList().OrderBy(a => a.DisplayOrder).ToList().FirstOrDefault().Media;
                //MyDataSourceAll = new List<SearchMediaModel>();
                //CollectionViewDataSource = new List<SearchMediaModel>();
                //SearchModel searchModel = new SearchModel() { SearchString = SearchString };
                //var getAllSearchData = await Task.Run(() => new MediaHandlerService().searchMedia(searchModel, MediaHandlerUrl.searchmedia));
                //if (getAllSearchData.Status == 200)
                //{
                //    MyDataSourceAll = JsonConvert.DeserializeObject<List<SearchMediaModel>>(getAllSearchData.Response.ToString());
                //    if (MyDataSourceAll.Count > 0)
                //    {
                //        CollectionViewDataSource = MyDataSourceAll.OrderBy(a => a.MediaID).ToList();
                //    }

                //}
                //else
                //{
                //    CrossToastPopUp.Current.ShowToastMessage(getAllSearchData.Message, ToastLength.Short);
                //}

                CollectionViewDataSource = this.MyDataSourceAll.Where(a => a.Title.Contains(SearchString)).OrderBy(a => a.Id).ToList();
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


        #endregion
    }
}
