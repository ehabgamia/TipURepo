using System;
using VideoBrek.Extensions;
using VideoBrek.Views.MRCATabbedPage;
using VideoBrek.Views.MRCATabbedPage.LibraryPages;
using Xamarin.Forms;

namespace VideoBrek.Views.MRCATabbedPage
{
    public partial class LibraryTabbedPage : TabbedPageAtTop
    {
        public LibraryTabbedPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var myList = new NavigationPage(new MyList());
            myList.Title = "My List";
            Children.Add(myList);

            var offline = new NavigationPage(new Offline());
            offline.Title = "Offline";
            Children.Add(offline);


            Children.Add(myList);
            Children.Add(offline);
            this.BarBackgroundColor = Color.FromHex("#2196F3");
            this.BarTextColor = Color.White;
        }
    }
}
