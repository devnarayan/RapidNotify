using RapidNotify.CustomControl;
using RapidNotify.UWP.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RapidNotify.CustomControl.MyEntry), typeof(MyEntryRenderer))]
namespace RapidNotify.UWP.Renderer
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new SolidColorBrush(Colors.Cyan);
                Control.BackgroundFocusBrush = new SolidColorBrush(Colors.Cyan);
                Border b = new Border();

                b.CornerRadius = new CornerRadius(10);
            }
        }
    }
}
