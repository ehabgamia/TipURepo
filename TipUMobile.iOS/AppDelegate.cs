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
        UIWindow forWindow = new UIWindow();
        private bool _allowRotation;
        private UIInterfaceOrientationMask uIInterfaceOrientationMask = new UIInterfaceOrientationMask();
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            CachedImageRenderer.Init();
            Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();
            CachedImageRenderer.InitImageSourceHandler();
            FormsVideoPlayer.Init();

            //Setup additional stuff that you need

            //Calls from the view that should rotate
            MessagingCenter.Subscribe<VideoPlay>(this, "allowLandScape", sender =>
            {
                _allowRotation = true;
                GetSupportedInterfaceOrientations(app, this.forWindow);
            });

            //When the page is closed this is called
            MessagingCenter.Subscribe<VideoPlay>(this, "preventLandScape", sender =>
            {
                _allowRotation = false;
                GetSupportedInterfaceOrientations(app, this.forWindow);
            });


            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }


        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            this.forWindow = forWindow;
            if (_allowRotation)
                return UIInterfaceOrientationMask.Landscape;
            return UIInterfaceOrientationMask.Portrait;
        }
    }
}