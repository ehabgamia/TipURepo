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
