using System;
using VideoBrek.Extensions;
using VideoBrek.iOS.Renderer;
using VideoBrek.Views.CustomPages;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]

namespace VideoBrek.iOS.Renderer
{
    public class CustomNavigationPageRenderer : NavigationRenderer
    {
        public CustomNavigationPageRenderer() : base()
        {
            NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
        }
    }
}