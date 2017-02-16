using System;
using System.Collections.Generic;
using System.Text;
using TestXFBugs;
using TestXFBugs.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PinButton), typeof(CustomPinButtonRenderer))]

namespace TestXFBugs.iOS.Renderers
{
    public class CustomPinButtonRenderer : ButtonRenderer
    {
        /// <summary>
        /// Called when element changes.
        /// </summary>
        /// <param name="e">The event that caused the change</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                return;
            }

            // lets get a reference to the native control
            var nativeButton = (UIButton)this.Control;
            nativeButton.Layer.CornerRadius = 0; // No rounded corners
            nativeButton.ClipsToBounds = true;

            nativeButton.SetTitleColor(((Color)Xamarin.Forms.Application.Current.Resources["PinButtonEnabledTextColor"]).ToUIColor(), UIControlState.Normal);
            nativeButton.SetTitleColor(((Color)Xamarin.Forms.Application.Current.Resources["PinButtonDisabledTextColor"]).ToUIColor(), UIControlState.Disabled);

            var originalColor = nativeButton.BackgroundColor;

            // ReSharper disable once ImplicitlyCapturedClosure
            nativeButton.TouchDown += (sender, args) =>
            {
                nativeButton.Alpha = .5f;
                nativeButton.BackgroundColor =
                    ((Color)Xamarin.Forms.Application.Current.Resources["PinButtonDisabledColor"]).ToUIColor();
            };
            nativeButton.TouchUpInside += (sender, ea) =>
            {
                nativeButton.Alpha = 1;
                nativeButton.BackgroundColor = originalColor;
            };
            nativeButton.TouchUpOutside += (sender, ea) =>
            {
                nativeButton.Alpha = 1;
                nativeButton.BackgroundColor = originalColor;
            };
            nativeButton.TouchCancel += (sender, ea) =>
            {
                nativeButton.Alpha = 1;
                nativeButton.BackgroundColor = originalColor;
            };
        }
    }
}
