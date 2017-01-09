using Xamarin.Forms;

namespace TestXFBugs
{
    public partial class PinPage : ContentPage
    {
        public PinPage()
        {
            this.BindingContext = new PinPageViewModel(this.Navigation);
            this.InitializeComponent();
        }
    }
}
