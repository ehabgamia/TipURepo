using System;
using Xamarin.Forms;
using static VideoBrek.Extensions.SearchPageExtension;

namespace VideoBrek.Extensions
{
    public class SearchPageExtension : ContentPage, ISearchPage
    {
      
        public SearchPageExtension()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            SearchBarTextChanged += HandleSearchBarTextChanged;
        }

        public event EventHandler<string> SearchBarTextChanged;

        public void OnSearchBarTextChanged(string text) => SearchBarTextChanged?.Invoke(this, text);

        void HandleSearchBarTextChanged(object sender, string searchBarText)
        {
            //Logic to handle updated search bar text
        }
    }
    public interface ISearchPage
        {
            void OnSearchBarTextChanged(string text);
            event EventHandler<string> SearchBarTextChanged;
        }
    }
