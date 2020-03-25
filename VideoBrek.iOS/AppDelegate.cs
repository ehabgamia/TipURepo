using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using Foundation;
using VideoBrek.iOS.Renderer;
using VideoBrek.Views.MediaDetails;
using Octane.Xamarin.Forms.VideoPlayer.iOS;
using UIKit;
using Xamarin.Forms;

namespace VideoBrek.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private bool _allowRotation;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            CachedImageRenderer.Init();
            Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();
            CachedImageRenderer.InitImageSourceHandler();
            FormsVideoPlayer.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}