using Xamarin.Forms;

namespace TestXFBugs
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
		    this.BindingContext = new LoginPageViewModel();
			this.InitializeComponent();
		}
	}
}
