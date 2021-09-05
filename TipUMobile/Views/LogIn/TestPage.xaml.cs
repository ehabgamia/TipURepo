using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipUMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipUMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = new TestPageViewModel(Navigation);
        }
    }
}