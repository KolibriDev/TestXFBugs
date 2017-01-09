using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestXFBugs
{

    /// <summary>
    /// Code behind for TransferConfirmedPage.
    /// </summary>
    public partial class TransferConfirmedPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferConfirmedPage"/> class.
        /// </summary>
        public TransferConfirmedPage()
        {
            this.BindingContext = new TransferConfirmedPageViewModel();
            this.InitializeComponent();
        }

        private void SwitchLayerTapped(object sender, EventArgs e)
        {
            this.SwitchLayer(sender, e);
            
        }

        /// <summary>
        /// Switches between modal page and original page
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SwitchLayer(object sender, EventArgs e)
        {
            if (this.OtherEntry.IsFocused)
            {
                this.OtherEntry.Unfocus();
                return;
            }

            var vm = (TransferConfirmedPageViewModel)this.BindingContext;
            vm.SendReceipt = !vm.SendReceipt;
        }

        /// <summary>
        /// Sets that other is selected
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnOtherTapped(object sender, EventArgs e)
        {
            var vm = (TransferConfirmedPageViewModel)this.BindingContext;
            vm.IsOtherSelected = true;
        }
    }
}
