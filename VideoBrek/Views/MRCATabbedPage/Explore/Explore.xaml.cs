using System;
using System.Collections.Generic;
using VideoBrek.Models;
using VideoBrek.ViewModels.Explore;
using Xamarin.Forms;

namespace VideoBrek.Views.MRCATabbedPage.Explore
{
    public partial class Explore : ContentPage
    {
        public ExploreViewModel vm { get; set; }
        public Explore()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = vm = new ExploreViewModel(Navigation);
            //BindingContext = Vm = new ExploreViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var res = await this.DisplayAlert("Do you really want to exit the application?", "", "Yes", "No").ConfigureAwait(false);

                if (res) System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            });
            return true;
        }
    }
}
