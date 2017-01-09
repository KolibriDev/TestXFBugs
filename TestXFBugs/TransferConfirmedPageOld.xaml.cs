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
            this.SetUpEntry();
        }

        /// <summary>
        /// Switch between modal and non modal layers on iOS and uwp
        /// Doesn't switch on droid because parent tapgestures behave differently
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SwitchLayerTapped(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Windows)
            {
                this.SwitchLayer(sender, e);
            }
        }

        private void SwitchLayerAndroidAndIosTapped(object sender, EventArgs e)
        {
            if (Device.OS != TargetPlatform.Windows)
            {
                this.SwitchLayer(sender, e);
            }
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
        /// Sets that phone is selected
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnPhoneTapped(object sender, EventArgs e)
        {
            var vm = (TransferConfirmedPageViewModel)this.BindingContext;
            vm.IsPhoneSelected = true;
            vm.IsEmailSelected = false;
            vm.IsOtherSelected = false;
        }

        /// <summary>
        /// Sets that email is selected
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnEmailTapped(object sender, EventArgs e)
        {
            var vm = (TransferConfirmedPageViewModel)this.BindingContext;
            vm.IsPhoneSelected = false;
            vm.IsEmailSelected = true;
            vm.IsOtherSelected = false;
        }

        /// <summary>
        /// Sets that other is selected
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnOtherTapped(object sender, EventArgs e)
        {
            var vm = (TransferConfirmedPageViewModel)this.BindingContext;
            vm.IsPhoneSelected = false;
            vm.IsEmailSelected = false;
            vm.IsOtherSelected = true;
        }

        private void SetUpEntry()
        {
            this.OtherEntry.Focused += async (sender, args) =>
            {
                await Task.Delay(95);
                if (Device.OS == TargetPlatform.Windows)
                {
                    this.EntryGrid.Margin = new Thickness(0, 0, 0, 50);
                }

                await this.ModalScrollView.ScrollToAsync(this.ModalContentView, ScrollToPosition.End, false);
            };

            this.OtherEntry.Unfocused += (sender, args) =>
            {
                if (Device.OS == TargetPlatform.Windows)
                {
                    this.EntryGrid.Margin = new Thickness(0, 0, 0, 0);
                }
            };
        }
    }
}
