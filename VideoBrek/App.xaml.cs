using System;
using System.Threading.Tasks;
using VideoBrek.Extensions;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.Views;
using VideoBrek.Views.Home;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VideoBrek
{
    public partial class App : Xamarin.Forms.Application
    {
        #region Declaration
        public INavigation Navigation { get; set; }
        public static object MyList { get; internal set; }
        public static object MasterNavigationPage { get; internal set; }
        public static object QuestionnaireOverviewPage { get; internal set; }

        SharedPreference _objShared = new SharedPreference();
        #endregion

        public App()
        {
            InitializeComponent();

            //Task.Run(async () =>
            //{
            //    await getCurrentLocation();
            //});

            //var dataIsExists = _objShared.LoadApplicationProperty<string>("UserProfileDetails");
            //if (!string.IsNullOrEmpty(dataIsExists))
            //{
            //    GlobalConstant.UserProfileDetails = JsonConvert.DeserializeObject<UserProfileModel>(dataIsExists);
            //    GlobalConstant.AccessToken = GlobalConstant.UserProfileDetails.AccessToken;

            //    //var navigationPage = new Xamarin.Forms.NavigationPage(new SearchBarExtension(new Home()));

            //    //navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

            //    //MainPage = navigationPage;
            //    MainPage = new Xamarin.Forms.NavigationPage(new Home());
            //}
            //else
            //{
            //    //var navigationPage = new Xamarin.Forms.NavigationPage(new SearchBarExtension(new MainPage()));

            //    //navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

            //    //MainPage = navigationPage;
            //    MainPage = new Xamarin.Forms.NavigationPage(new MainPage());
            //}
            //MainPage = new CustomNavigationPage(new VideoBrek.Views.MRCATabbedPage.Explore.VideoDetails());
            //MainPage = new CustomNavigationPage(new TermsAndConditions());

            //MainPage = new CustomNavigationPage(new MyList());


            //MainPage = new CustomNavigationPage(new TermsAndConditions(null));

            // Enable your flags here!
            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });
            MainPage = new Xamarin.Forms.NavigationPage(new Home());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async Task getCurrentLocation()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.High);
                    var location = await Geolocation.GetLocationAsync(request);

                    if (location != null)
                    {
                        GlobalConstant.Latitude = Convert.ToDouble(location.Latitude.ToString("0.00"));
                        GlobalConstant.Longitude = Convert.ToDouble(location.Longitude.ToString("0.00"));
                        GlobalConstant.Altitude = location.Altitude;
                        Console.WriteLine($"Latitude: {Convert.ToDouble(location.Latitude.ToString("0.00"))}, Longitude: {Convert.ToDouble(location.Longitude.ToString("0.00"))}, Altitude: {location.Altitude}");
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    // Handle not enabled on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to get location
                }

            });
        }

    }
}
