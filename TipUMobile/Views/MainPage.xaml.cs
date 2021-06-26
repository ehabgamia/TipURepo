using System;
using System.ComponentModel;
using VideoBrek.ViewModels.MainPage;
using VideoBrek.Views.MRCATabbedPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoBrek.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel vm { get; set; }
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = vm = new MainPageViewModel(Navigation);
            //BindingContext = vm = new MainPageViewModel(Navigation);
            //vm = BindingContext as MainPageViewModel;
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        async void LogInButton_Clicked(object sender, System.EventArgs e)
        {
            await vm.gotoLogInPage();
        }

        async void RegisterHereButton_Clicked(object sender, System.EventArgs e)
        {
            await vm.gotoSignUpPage();
        }
    }  
    
}
