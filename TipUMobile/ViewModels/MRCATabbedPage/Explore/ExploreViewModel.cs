using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoBrek.Models;
using VideoBrek.Views.CustomPages;
using VideoBrek.Views.MediaDetails;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;
using static VideoBrek.Models.MediaHandlerModel;
using VideoBrek.PCL.Service;
using VideoBrek.PCL.Common;

namespace VideoBrek.ViewModels.Explore
{
    public class ExploreViewModel : INotifyPropertyChanged
    {
        public ExploreViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetMedias.Execute(null);
        }

        #region Fields
        public INavigation Navigation { get; set; }
        bool _IsLoading;

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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public List<GetMediasModel> MyDataSourceAll { get; set; }

        private int _position;
        public int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        private List<GetMediasModel> _CollectionViewDataSource;
        public List<GetMediasModel> CollectionViewDataSource
        {
            get { return _CollectionViewDataSource; }
            set
            {
                _CollectionViewDataSource = value;
                OnPropertyChanged();
            }
        }

        private List<AllMediaModel> _CarouselViewDataSource;
        public List<AllMediaModel> CarouselViewDataSource
        {
            get { return _CarouselViewDataSource; }
            set
            {
                _CarouselViewDataSource = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        ICommand _GetMedias;
        public ICommand GetMedias =>
        _GetMedias ?? (_GetMedias = new Command(() => getAllMedias()));


        ICommand _OnPullDownRefresh;
        public ICommand OnPullDownRefresh =>
        _OnPullDownRefresh ?? (_OnPullDownRefresh = new Command(() => getAllMedias()));

        ICommand _ViewItemTap;
        public ICommand ViewItemTap =>
        _ViewItemTap ?? (_ViewItemTap = new Command<AllMediaModel>((m) => gotoMediaDetails(m)));

        ICommand _PlayNowButtonClicked;
        public ICommand PlayNowButtonClicked =>
        _PlayNowButtonClicked ?? (_PlayNowButtonClicked = new Command<AllMediaModel>((m) => gotoMediaDetails(m)));
        #endregion


        #region Methods
        public async Task getAllMedias()
        {
            if (IsLoading)
                return;
            IsLoading = true;
            try
            {
                
                var getMedia = await new MediaHandlerService().getData(MediaHandlerUrl.getMedias + GlobalConstant.UserProfileDetails.UserId);

                //var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ExploreViewModel)).Assembly;
                //Stream stream = assembly.GetManifestResourceStream("VideoBrek.Resources.MediaData.json");
                //string jsonString = "";

                //using (var reader = new StreamReader(stream))
                //{
                //    jsonString = reader.ReadToEnd();
                //}


                //CarouselViewDataSource = MyDataSourceAll.ToList().OrderBy(a => a.DisplayOrder).ToList().FirstOrDefault().Media;
                //CollectionViewDataSource = MyDataSourceAll.Skip(1).ToList();

                //var getAllMediasData = JsonConvert.DeserializeObject<ResultModel>(jsonString.ToString());
                //var getAllMediasData = await Task.Run(() => new MediaHandlerService().getData(MediaHandlerUrl.getMedias));
                if (getMedia.Status == 200)
                {
                    MyDataSourceAll = JsonConvert.DeserializeObject<List<GetMediasModel>>(getMedia.Response.ToString());
                    if (MyDataSourceAll.Count > 0)
                    {
                        CarouselViewDataSource = MyDataSourceAll.ToList().OrderBy(a => a.DisplayOrder).ToList().FirstOrDefault().Media;
                        CollectionViewDataSource = MyDataSourceAll.Skip(1).OrderBy(a => a.DisplayOrder).ToList();

                        Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
                        {
                            //Position = (Position + 1) % MyDataSourceAll.ToList().OrderBy(a => a.DisplayOrder).ToList().FirstOrDefault().Media.Count;

                            return true;
                        }));

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

        private void gotoMediaDetails(AllMediaModel allMediaModel)
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
                                await Navigation.PushModalAsync(new NavigationPage(new MediaDetails(allMediaModel)));
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
