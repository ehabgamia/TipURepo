using System;
using System.Collections.Generic;
using VideoBrek.ViewModels.MRCATabbedPage.LibraryPages;
using Xamarin.Forms;

namespace VideoBrek.Views.MRCATabbedPage.LibraryPages
{
    public partial class Offline : ContentPage
    {
        public OfflineViewModel vm { get; set; }
        public Offline()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = vm = new OfflineViewModel(Navigation);
            vm = BindingContext as OfflineViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }


    }
}
