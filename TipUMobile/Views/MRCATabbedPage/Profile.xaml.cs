using System;
using System.Collections.Generic;
using VideoBrek.Extensions;
using VideoBrek.ViewModels.MRCATabbedPage;
using Xamarin.Forms;

namespace VideoBrek.Views.MRCATabbedPage
{
    public partial class Profile : ContentPage
    {
        public ProfileViewModel vm { get; set; }
        public static bool CanGoBack { get; internal set; }

        public Profile()
        {
            InitializeComponent();
            Title = "Settings";
            base.BindingContext = vm = new ProfileViewModel(Navigation);
            //BackgroundColor = Color.White;
            //NavigationPage.SetHasNavigationBar(this, false);

            //var fdff = new CellExtensions();
            //fdff.AccessoryProperty = 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //CellExtensions.AccessoryProperty = "DisclosureIndicator";
            //var masterPage = this.Parent as TabbedPage;
            //masterPage.CurrentPage = masterPage.Children[1];
        }

        internal static void GoBack()
        {
            throw new NotImplementedException();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected void OnlogOutViewCellTapped(object sender, EventArgs e)
        {
            vm.GotoLogOut();
        }

        async protected void privacyPolicyViewCellTapped(object sender, EventArgs e)
        {
            await vm.gotoPrivacyPolicy();
        }

        

    }
}
