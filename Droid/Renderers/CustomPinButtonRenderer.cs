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

            this.SetBackgroundResource(Resource.Drawable.PinButton);
            this.SetFont(e.NewElement.FontFamily);


            var enabledColor = ((Xamarin.Forms.Color) App.Current.Resources["TextFaded"]).ToAndroid();
            var disabledColor = ((Xamarin.Forms.Color) App.Current.Resources["GreyLight"]).ToAndroid();
            
            this.SetButtonTextColors(enabledColor, disabledColor, enabledColor, enabledColor);
        }
    }
}