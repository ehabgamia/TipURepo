using System.ComponentModel;
using VideoBrek.Views.MRCATabbedPage;
using VideoBrek.Views.MRCATabbedPage.Explore;
using Xamarin.Forms;

namespace VideoBrek.Views.Home
{
    [DesignTimeVisible(true)]
    public partial class Home : TabbedPage
    {
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var explore = new NavigationPage(new Explore());
            explore.IconImageSource = "ic_Explore.png";
            explore.Title = "Home";
            Children.Add(explore);

            var searchPage = new NavigationPage(new Search());
            searchPage.IconImageSource = "ic_Search.png";
            searchPage.Title = "Search";
            Children.Add(searchPage);

            var library = new NavigationPage(new MyList());
            //var library = new NavigationPage(new LibraryTabbedPage());
            library.IconImageSource = "ic_Library.png";
            library.Title = "My List";
            Children.Add(library);

            var profile = new NavigationPage(new Profile());
            profile.IconImageSource = "ic_Profile.png";
            profile.Title = "Profile";
            Children.Add(profile);
        }
        protected override bool OnBackButtonPressed()
        {
             Navigation.PushAsync(new Home(),false);
             base.OnBackButtonPressed();
             return true;
        }
    }

}
