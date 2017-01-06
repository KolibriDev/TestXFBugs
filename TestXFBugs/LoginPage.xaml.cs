using System;
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

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        this.Navigation.PushAsync(new PinPage());
	    }
	}
}
