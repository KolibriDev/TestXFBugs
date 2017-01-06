using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestXFBugs
{
    public partial class PinPage : ContentPage
    {
        public PinPage()
        {
            this.BindingContext = new PinPageViewModel();
            this.InitializeComponent();
        }
    }
}
