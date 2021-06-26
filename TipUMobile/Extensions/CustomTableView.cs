using System;
using Xamarin.Forms;

namespace VideoBrek.Extensions
{
    public class CustomTableView : TableView
    {
        public static readonly BindableProperty SeperatorVisibleProperty = BindableProperty.Create("SeperatorVisible", typeof(SeparatorVisibility), typeof(CustomTableView), SeparatorVisibility.Default);
        public SeparatorVisibility SeperatorVisible
        {
            get { return (SeparatorVisibility)GetValue(SeperatorVisibleProperty); }
            set { SetValue(SeperatorVisibleProperty, value); }
        }
    }
}
