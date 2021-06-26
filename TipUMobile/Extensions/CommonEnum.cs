using System;
using Xamarin.Forms;

namespace VideoBrek.Extensions
{
    public enum GradientColorStackMode
    {
        ToRight,
        ToLeft,
        ToTop,
        ToBottom,
        ToTopLeft,
        ToTopRight,
        ToBottomLeft,
        ToBottomRight
    }

    public enum AccessoryType
    {
        None,
        DisclosureIndicator,
        DetailDisclosureButton,
        Checkmark,
        DetailButton
    }

    public static class CellExtensions
    {
        //public int StaticProp { get; set; }
        /// <summary>
        /// Determines the type of Cell Accessory to display. Default is None.
        /// </summary>
        public static BindableProperty AccessoryProperty =
        BindableProperty.CreateAttached("Accessory", typeof(AccessoryType), typeof(Cell), AccessoryType.DisclosureIndicator);
    }
}
