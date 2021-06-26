using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.PCL.Service;
using VideoBrek.ViewModels.LogIn;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoBrek.Views.LogIn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        #region  declaration
        SharedPreference _objShared = new SharedPreference();
        public LogInViewModel vm { get; set; }

        #endregion


        public LogIn()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = vm = new LogInViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

   
    }
}
