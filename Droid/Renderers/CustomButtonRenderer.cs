
namespace TestXFBugs.Droid.Renderers
{
    using System;
    using Android.Content.Res;
    using Android.Graphics;
    using Android.Views;
    using Android.Widget;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using Color = Android.Graphics.Color;

    /// <summary>
    /// Custom button renderer.
    /// </summary>
    public class CustomButtonRenderer : ButtonRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Button}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            this.Element.BorderRadius = 0;
        }

        /// <summary>
        /// Sets button colors.
        /// </summary>
        /// <param name="enabledColor">The enabled color.</param>
        /// <param name="disabledColor">The disabled color.</param>
        /// <param name="checkedColor">The checked color.</param>
        /// <param name="pressedColor">The pressed color.</param>
        protected void SetButtonColors(Color enabledColor, Color disabledColor, Color checkedColor, Color pressedColor)
        {
            int[][] states =
            {
                    new int[] { Android.Resource.Attribute.StateEnabled }, // enabled
                    new int[] { -Android.Resource.Attribute.StateEnabled }, // disabled
                    new int[] { Android.Resource.Attribute.StateChecked }, // checked
                    new int[] { Android.Resource.Attribute.StatePressed } // pressed
                };

            // Using ColorStateList to change the background color of the button
            int[] colors =
            {
                    enabledColor,
                    disabledColor,
                    enabledColor,
                    pressedColor
                };

            var btn = this.Control;
            btn.BackgroundTintList = new ColorStateList(states, colors);
        }

        /// <summary>
        /// Sets button colors.
        /// </summary>
        /// <param name="enabledColor">The enabled color.</param>
        /// <param name="disabledColor">The disabled color.</param>
        /// <param name="checkedColor">The checked color.</param>
        /// <param name="pressedColor">The pressed color.</param>
        protected void SetButtonTextColors(Color enabledColor, Color disabledColor, Color checkedColor, Color pressedColor)
        {
            int[][] states =
            {
                    new int[] { Android.Resource.Attribute.StateEnabled }, // enabled
                    new int[] { -Android.Resource.Attribute.StateEnabled }, // disabled
                    new int[] { Android.Resource.Attribute.StateChecked }, // checked
                    new int[] { Android.Resource.Attribute.StatePressed } // pressed
                };

            // Using ColorStateList to change the background color of the button
            int[] colors =
            {
                    enabledColor,
                    disabledColor,
                    enabledColor,
                    pressedColor
                };

            var btn = this.Control;
            btn.SetTextColor(new ColorStateList(states, colors));
        }

        /// <summary>
        /// Sets button resources.
        /// </summary>
        /// <param name="upResId">Up resource id.</param>
        /// <param name="downResId">Down resource id.</param>
        protected void SetButtonResource(int upResId, int downResId)
        {
            var btn = this.Control;
            btn.SetBackgroundResource(upResId);

            btn.Touch += (s, me) =>
            {
                if (me.Event.Action == MotionEventActions.Down)
                {
                    btn.SetBackgroundResource(downResId);
                }
                else if (me.Event.Action == MotionEventActions.Up)
                {
                    btn.SetBackgroundResource(upResId);
                }

                me.Handled = false; // Because we still want the on click even to fire
            };
        }

        /// <summary>
        /// Sets font.
        /// </summary>
        /// <param name="fontFamily">The font family.</param>
        protected void SetFont(string fontFamily)
        {
            var button = (TextView)this.Control; // for example

            if (fontFamily != null)
            {
                try
                {
                    Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, fontFamily);
                    button.Typeface = font;
                }
                catch (Exception)
                {
                    // ReSharper disable once LocalizableElement
                    Console.WriteLine("Unable to create font from asset: " + fontFamily);
                }
            }
        }
    }
}