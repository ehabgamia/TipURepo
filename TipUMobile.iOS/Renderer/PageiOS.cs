using System;
using CoreGraphics;
using MRCAVideoApp.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(ContentPage), typeof(PageiOS))]
namespace MRCAVideoApp.iOS.Renderer
{
    public class PageiOS : PageRenderer
    {
        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            nfloat tabSize = 44.0f;

            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

            if (UIInterfaceOrientation.LandscapeLeft == orientation || UIInterfaceOrientation.LandscapeRight == orientation)
            {
                tabSize = 32.0f;
            }

            CGRect rect = this.View.Frame;
            rect.Y = this.NavigationController != null ? tabSize : tabSize + 20;
            this.View.Frame = rect;

            if (TabBarController != null)
            {
                CGRect tabFrame = this.TabBarController.TabBar.Frame;
                tabFrame.Height = tabSize;
                tabFrame.Y = this.NavigationController != null ? 64 : 20;
                //tabFrame.Y = this.NavigationController != null ? 44 : 20;
                this.TabBarController.TabBar.Frame = tabFrame;
                this.TabBarController.TabBar.BarTintColor = UIColor.Red;
            }
        }
    }
}