using System;
using System.Collections.Generic;
using VideoBrek.Extensions;
using VideoBrek.Views.MRCATabbedPage.LibraryPages;
using Xamarin.Forms;

namespace VideoBrek.Views.MRCATabbedPage
{
    public partial class LibraryTabbedPage : TabbedPageAtTop
    {
        public LibraryTabbedPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var myList = new NavigationPage(new MyList());
            //myList.IconImageSource = "ic_Explore.png";
            myList.Title = "MY LIST";

            var offline = new NavigationPage(new Offline());
            //offline.IconImageSource = "ic_Search.png";
            offline.Title = "OFFLINE";
            Children.Add(offline);

            Children.Add(myList);
            Children.Add(offline);
        }
    }
}
