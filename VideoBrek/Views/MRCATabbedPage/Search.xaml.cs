using VideoBrek.ViewModels.MRCATabbedPage;
using Xamarin.Forms;

namespace VideoBrek.Views.MRCATabbedPage
{
    public partial class Search : ContentPage
    {
        public SearchViewModel vm { get; set; }
        public Search()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = vm = new SearchViewModel(Navigation);
            vm = BindingContext as SearchViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        void HandleSearchBarTextChanged(object sender, string searchBarText)
        {
            //Logic to handle updated search bar text
        }
    }
}
