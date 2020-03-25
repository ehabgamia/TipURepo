using System;
using CoreGraphics;
using VideoBrek.Extensions;
using VideoBrek.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPageAtTop), typeof(TabbedPageCustomRenderer))]
namespace VideoBrek.iOS.Renderer
{
    public  class TabbedPageCustomRenderer : TabbedRenderer
    {
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            this.TabBar.InvalidateIntrinsicContentSize();

            nfloat tabSize = 64.0f;

            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

            if (UIInterfaceOrientation.LandscapeLeft == orientation || UIInterfaceOrientation.LandscapeRight == orientation)
            {
                tabSize = 32.0f;
            }
            //this.NavigationController.NavigationBarHidden = true;
            CGRect tabFrame = this.TabBar.Frame;

            tabFrame.Height = tabSize;

            tabFrame.Y = this.View.Frame.Y;

            this.TabBar.Frame = tabFrame;
            this.TabBar.ContentMode = UIViewContentMode.ScaleToFill;

            this.TabBar.Translucent = true;
            this.TabBar.Translucent = true;

            //this.TabBar.BackgroundColor = Color.FromHex("#348aed").ToUIColor();
            //this.TabBar.BarTintColor = Color.FromHex("#348aed").ToUIColor();
            //this.TabBar.SetNeedsUpdateConstraints();

            if (this.NavigationController != null)
            {
                CGRect rect = this.NavigationController.View.Frame;
                rect.Y = tabFrame.Y + tabFrame.Height;
                this.NavigationController.View.Frame = rect;
                //this.NavigationController.View.SetNeedsUpdateConstraints();
            }
            else
            {
                CGRect rect = this.View.Frame;
                rect.Y = tabFrame.Y + tabFrame.Height;
                this.View.Frame = rect;
                //this.View.SetNeedsUpdateConstraints();
            }



            //TabBar.AddSubview()
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();



        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            //TabBar.BarTintColor = Color.FromHex("#1e80f0").ToUIColor();

            //var appearance = UITabBarItem.Appearance;
            //var font = UIFont.FromName("Helvetica-Bold", 10f);
            //var attributes = appearance.GetTitleTextAttributes(UIControlState.Normal);
            //attributes.Font = font;
            //attributes.Font = UIFont.FromName("Helvetica-Bold", 20f);
            //attributes.TextColor = UIKit.UIColor.White;
            //appearance.TitlePositionAdjustment = new UIOffset(-8.0f, -10.0f);
            //appearance.SetTitleTextAttributes(attributes, UIControlState.Normal);
        }
    }
}