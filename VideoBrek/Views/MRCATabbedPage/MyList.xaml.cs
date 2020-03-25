using VideoBrek.ViewModels.MRCATabbedPage;
using Xamarin.Forms;

namespace VideoBrek.Views.MRCATabbedPage
{
    public partial class MyList : ContentPage
    {
        public MyListViewModel vm { get; set; }
        public MyList()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = vm = new MyListViewModel(Navigation);
            vm = BindingContext as MyListViewModel;
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
