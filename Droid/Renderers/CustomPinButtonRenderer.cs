using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestXFBugs;
using TestXFBugs.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PinButton), typeof(CustomPinButtonRenderer))]

namespace TestXFBugs.Droid.Renderers
{
    public class CustomPinButtonRenderer : CustomButtonRenderer
    {
        /// <inheritdoc />
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                return;
            }

            var btn = this.Control;

            btn.SetTextColor(Resources.GetColorStateList (Resource.Drawable.PinButtonTextColors));
            
            this.SetButtonResource(Droid.Resource.Drawable.PinButton, Droid.Resource.Drawable.PinButtonDown);
            this.SetFont(e.NewElement.FontFamily);

            //var enabledColor = ((Color)Xamarin.Forms.Application.Current.Resources["PinButtonEnabledColor"]).ToAndroid();
            //var pressedColor = ((Color)Xamarin.Forms.Application.Current.Resources["PinButtonPressedColor"]).ToAndroid();

            //this.SetButtonColors(enabledColor, enabledColor, enabledColor, pressedColor);

            /*var enabledColor = ((Color)Xamarin.Forms.Application.Current.Resources["PinButtonEnabledTextColor"]).ToAndroid();
            var disabledColor = ((Color)Xamarin.Forms.Application.Current.Resources["PinButtonDisabledTextColor"]).ToAndroid();
            
            this.SetButtonTextColors(enabledColor, disabledColor, enabledColor, enabledColor);*/
        }
    }
}