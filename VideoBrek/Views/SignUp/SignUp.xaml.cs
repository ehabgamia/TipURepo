using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.ViewModels.SignUp;
using Newtonsoft.Json;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoBrek.Views.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        #region  declaration
        SharedPreference _objShared = new SharedPreference();
        public SignUpViewModel vm { get; set; }
        #endregion

        public SignUp()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = vm = new SignUpViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}