using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TipUMobile.ViewModels
{
    public class TestPageViewModel : INotifyPropertyChanged
    {
        private INavigation navigation;

        public TestPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
