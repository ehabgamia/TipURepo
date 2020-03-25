using Android.Content;
using Android.Graphics.Drawables;
using VideoBrek.Droid.Renderer;
using VideoBrek.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomTableView), typeof(CustomTableViewRenderer))]
namespace VideoBrek.Droid.Renderer
{
    public class CustomTableViewRenderer : TableViewRenderer
    {
        public CustomTableViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;
            var zoControl = (CustomTableView)e.NewElement;
            var listView = Control as global::Android.Widget.ListView;
            if (zoControl.SeperatorVisible == SeparatorVisibility.None)
            {
                listView.Divider = new ColorDrawable(Android.Graphics.Color.Transparent);
                listView.DividerHeight = 0;
            }
            else
            {
             
                listView.Divider = new ColorDrawable(Android.Graphics.Color.Red);
                listView.DividerHeight = 2;
            }

        }
    }
}