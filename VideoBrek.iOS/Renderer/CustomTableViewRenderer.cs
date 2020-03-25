using System;
using VideoBrek.Extensions;
using VideoBrek.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTableView), typeof(CustomTableViewRenderer))]
namespace VideoBrek.iOS.Renderer
{
    public class CustomTableViewRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;
            var zoControl = (CustomTableView)e.NewElement;
            if (zoControl.SeperatorVisible == SeparatorVisibility.None)
            {
                var tableView = Control as UITableView;
                tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            }
        }
    }
}
