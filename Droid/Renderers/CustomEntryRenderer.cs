using TestXFBugs.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace TestXFBugs.Droid.Renderers
{
    using System.ComponentModel;
    
    public class CustomEntryRenderer : EntryRenderer
    {
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                return;
            }

            // perform initial setup
            // lets get a reference to the native control
            var nativeEditText = (global::Android.Widget.EditText)this.Control;

            nativeEditText.SetBackgroundResource(Resource.Drawable.Box);
        }
    }
}