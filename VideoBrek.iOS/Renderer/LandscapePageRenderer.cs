using System;
using Foundation;
using VideoBrek.iOS.Renderer;
using VideoBrek.Views.MediaDetails;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(VideoPlay), typeof(LandscapePageRenderer))]
namespace VideoBrek.iOS.Renderer
{
    public class LandscapePageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.LandscapeLeft)), new NSString("orientation"));
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Portrait)), new NSString("orientation"));
        }

        //public override void ViewWillLayoutSubviews()
        //{
        //    base.ViewWillLayoutSubviews();
        //}
    }
}
