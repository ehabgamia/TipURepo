using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace MRCAVideoApp.Base
{
    public abstract class BaseContentPage : ContentPage 
    {
        protected BaseContentPage()
        {
            SetDynamicResource(NavigationPage.BarBackgroundColorProperty, nameof(BaseTheme.NavigationBarBackgroundColor));
            //BindingContext = ViewModel = viewModel;
            //Title = title;
        }

        //protected T ViewModel { get; }

        protected Task OpenBrowser(Uri uri) => OpenBrowser(uri.ToString());

        protected Task OpenBrowser(string url)
        {
            return Device.InvokeOnMainThreadAsync(() =>
            {
                var browserOptions = new BrowserLaunchOptions
                {
                    PreferredToolbarColor = (Color)Application.Current.Resources[nameof(BaseTheme.NavigationBarBackgroundColor)],
                    PreferredControlColor = (Color)Application.Current.Resources[nameof(BaseTheme.NavigationBarTextColor)],
                };

                return Browser.OpenAsync(url, browserOptions);
            });
        }
    }
}
