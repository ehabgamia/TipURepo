using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoBrek.PCL.Common;
using VideoBrek.Views.CustomPages;
using VideoBrek.Views.MRCATabbedPage.Explore;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;
using static VideoBrek.Models.MediaHandlerModel;

namespace VideoBrek.ViewModels.MRCATabbedPage.LibraryPages
{
    public class OfflineViewModel : INotifyPropertyChanged
    {
        public OfflineViewModel(INavigation navigation)
        {
            Navigation = navigation;


            List<AllMediaModel> Media1 = new List<AllMediaModel>()
            {
                new AllMediaModel() {
                Id = 2,
                Description = "Gud Morning Friends, Sat Shri Akal, Namaste, Bado ko pairi pona or Choto ko heloooooo .. Hey friends, Prabhjot Singh this side & thank alot for watching my videos.Please the video if you enjoyed watching or also  if you want to Suggest something or Appreciate. ✉ Business Inquiries, Sponsors &Collaboration email: Prabhjot24by7 @gmail.com",
                CloudUrl = "watch?v=A8wkg8xij2s",
                Title = "Bach gya mai aj to 😴 - iphone aa gya free mai 😳",
                ThumbURL = "https://newevolutiondesigns.com/images/freebies/cool-wallpaper-3.jpg"
            },
                    new AllMediaModel() {
                Id = 3,
                Description = "Gud Morning Friends, Sat Shri Akal, Namaste, Bado ko pairi pona or Choto ko heloooooo .. Hey friends, Prabhjot Singh this side & thank alot for watching my videos.Please the video if you enjoyed watching or also  if you want to Suggest something or Appreciate. ✉ Business Inquiries, Sponsors &Collaboration email: Prabhjot24by7 @gmail.com",
                CloudUrl = "watch?v=A8wkg8xij2s",
                Title = "After Riding my SuperBike - He was Crying 😳",
                ThumbURL = "http://getwallpapers.com/wallpaper/full/4/8/9/51090.jpg"
                },

                    new AllMediaModel() {
                Id = 4,
                Description = "Yaaron Ki Baraat is a #Hindi Tv show hosted by #Famous #Bollywood #Celebrities Riteish Deshmukh and Sajid Khan. This Tv Show is light-hearted #comedy Tv show, Bollywood celebrities who share a strong bond Off Screen, are invited for a candid chat. The celebrities make some funny revelations and confession about their life and friendship ( Dosti ).this Tv Show host Riteish and Sajid with their quirky one-liners and impeccable comic timing add lot of Fun watch Riteish and Sajid add their own touch of fun, frolic, spice and quirky humour to the show Subscribe to your favourite Channel ?? https://www.youtube.com/user/zeetv?su... Get notified about our Latest update by Clicking the Bell Icon ?? ZEE5 Now available in 190 + countries.Click Here http://bit.ly/WatchNowOnZEE5 The feel of your language is in your entertainment too! Watch your favourite TV shows, movies, original shows, in 12 languages, because every language has a super feel! Now enjoy ZEE5 Globally.Available in over 190 countries* To Feel #ZEE5 in Your Language, DOWNLOAD the app now - Playstore: ",
                CloudUrl = "watch?v=CQrboUNqtQM",
                Title = "Yaaron Ki Baraat - Jackie Shroff , Suniel Shetty - Hindi Zee Tv Serial Talk Show Episode 8",
                ThumbURL = "https://wallpaperaccess.com/full/30100.jpg"
            },
                    new AllMediaModel() {
                Id = 5,
                Description = "Yaaron Ki Baraat is a #Hindi Tv show hosted by #Famous #Bollywood #Celebrities Riteish Deshmukh and Sajid Khan. This Tv Show is light-hearted #comedy Tv show, Bollywood celebrities who share a strong bond Off Screen, are invited for a candid chat. The celebrities make some funny revelations and confession about their life and friendship ( Dosti ).this Tv Show host Riteish and Sajid with their quirky one-liners and impeccable comic timing add lot of Fun watch Riteish and Sajid add their own touch of fun, frolic, spice and quirky humour to the show Subscribe to your favourite Channel ?? https://www.youtube.com/user/zeetv?su... Get notified about our Latest update by Clicking the Bell Icon ?? ZEE5 Now available in 190 + countries.Click Here http://bit.ly/WatchNowOnZEE5 The feel of your language is in your entertainment too! Watch your favourite TV shows, movies, original shows, in 12 languages, because every language has a super feel! Now enjoy ZEE5 Globally.Available in over 190 countries* To Feel #ZEE5 in Your Language, DOWNLOAD the app now - Playstore: ",
                CloudUrl = "watch?v=51s43UQ5YDA&t=15047s",
                Title = "Yaaron Ki Baraat - Shah Rukh Khan , Anushka Sharma - Hindi Zee Tv Serial Talk Show Episode 13",
                ThumbURL = "https://c4.wallpaperflare.com/wallpaper/764/505/66/baby-groot-4k-hd-superheroes-wallpaper-preview.jpg"
                }
            };


            MyDataSourceAll = new List<GetMediasModel>() { new GetMediasModel() { DisplayOrder = 1, CategoryName="Carousel", Media= Media1 },
                                                         new GetMediasModel() { DisplayOrder = 2, CategoryName="First Saturday", Media= Media1 },
                                                               new GetMediasModel() { DisplayOrder = 3, CategoryName="Washington Convention", Media= Media1 },
                                                         new GetMediasModel() { DisplayOrder = 4, CategoryName="40 Hours of Adoration", Media= Media1 } };

            GetOffline.Execute(null);
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

        public List<GetMediasModel> MyDataSourceAll { get; set; }


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
        ICommand _getOffline;
        public ICommand GetOffline =>
        _getOffline ?? (_getOffline = new Command(async () => await getOffline()));


        ICommand _OnPullDownRefresh;
        public ICommand OnPullDownRefresh =>
        _OnPullDownRefresh ?? (_OnPullDownRefresh = new Command(async () => await getOffline().ConfigureAwait(true)));

        ICommand _ViewItemTap;
        public ICommand ViewItemTap =>
        _ViewItemTap ?? (_ViewItemTap = new Command<AllMediaModel>(async (m) => await gotoVideoDetails(m).ConfigureAwait(true)));

        #endregion

        #region Methods
        public async Task getOffline()
        {
            if (IsLoading)
                return;
            IsLoading = true;
            try
            {
                CollectionViewDataSource = MyDataSourceAll.ToList().OrderBy(a => a.DisplayOrder).ToList().FirstOrDefault().Media;

                //var getOfflineData = await Task.Run(() => new MediaHandlerService().getMedias(MediaHandlerUrl.getMedias));
                //if (getOfflineData.Status == 200)
                //{
                //    MyDataSourceAll = JsonConvert.DeserializeObject<List<GetMediasModel>>(getOfflineData.Response.ToString());
                //    if (MyDataSourceAll.Count > 0)
                //    {
                //        CollectionViewDataSource = MyDataSourceAll.ToList().OrderBy(a => a.DisplayOrder).ToList().FirstOrDefault().Media;
                //    }

                //}
                //else if (getOfflineData.Status == 204)
                //{
                //    await Application.Current.MainPage.DisplayAlert("", "No Result", "Ok");
                //}
                //else
                //{
                //    await Application.Current.MainPage.DisplayAlert("", "Not Found", "Ok");
                //}

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

        private async Task gotoVideoDetails(AllMediaModel allMedia = null)
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
                        //await Navigation.PushModalAsync(new CustomNavigationPage(new Views.MediaDetails.MediaDetails(allMediaModel)), true);
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
