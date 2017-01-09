using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestXFBugs
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// The transfer confirmed page view model
    /// </summary>
    public class TransferConfirmedPageViewModel : INotifyPropertyChanged
    {
        private bool _sendReceipt;
       
        public event PropertyChangedEventHandler PropertyChanged;

        public TransferConfirmedPageViewModel()
        {
            this.SendReceiptCommand = new Command(this.SendReceiptToRecipient);
            this.TransferAmount = 500;
            this.IsOtherSelected = true;
            this.DatePerformedString = $"{DateTime.Today:dd.MM.yyyy}    kl. {DateTime.Now:HH:mm}";
            this.SetMargins();
        }

        /// <summary>
        /// Gets RecipientInfoTextMargin
        /// </summary>
        public Thickness RecipientInfoTextMargin { get; private set; }

        /// <summary>
        /// Gets WithdrawalAccountNameMargin
        /// </summary>
        public Thickness WithdrawalAccountNameMargin { get; private set; }

        /// <summary>
        /// Gets WithdrawalAccountMargin
        /// </summary>
        public Thickness WithdrawalAccountMargin { get; private set; }

        /// <summary>
        /// Gets RecipientNameMargin
        /// </summary>
        public Thickness RecipientNameMargin { get; private set; }

        /// <summary>
        /// Gets RecipientAccountMargin
        /// </summary>
        public Thickness RecipientAccountMargin { get; private set; }

        /// <summary>
        /// Gets or sets the date the transaction was performed.
        /// </summary>
        public string DatePerformedString { get; set; }

        /// <summary>
        /// Gets or sets send recipt command which is used to send the receipt to correct destination
        /// </summary>
        public Command SendReceiptCommand { get; set; }

        /// <summary>
        /// Gets or sets the transfer amount
        /// </summary>
        public int TransferAmount { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether SendReceipt is set to decide what layer is showed to user
        /// </summary>
        public bool SendReceipt { get
            { return this._sendReceipt; }
            set
            {
                this._sendReceipt = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether modalpage IsActive, used in IModalPage interface
        /// </summary>
        public bool IsActive
        {
            get { return this.SendReceipt; }

            set { this.SendReceipt = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether other is selected on modalpage
        /// </summary>
        public bool IsOtherSelected { get; set; }

        /// <summary>
        /// Gets or sets otherinfo, which is text in the entry on modalpage
        /// </summary>
        public string OtherInfo { get; set; }

        private void SendReceiptToRecipient()
        {
            if (!string.IsNullOrWhiteSpace(this.OtherInfo))
            {
                this.SendReceiptToNewRecipient();
            }
            
            this.SendReceipt = false;
        }

        private void SendReceiptToNewRecipient()
        {
        }

        private void SetMargins()
        {
            
            this.RecipientInfoTextMargin = new Thickness(33, 0, 16, 11);

            this.WithdrawalAccountNameMargin = new Thickness(33, 15, 16, 0);

            this.RecipientNameMargin = new Thickness(16, 15, 33, 0);

            this.WithdrawalAccountMargin = new Thickness(33, 0, 16, 18);

            this.RecipientAccountMargin = new Thickness(16, 0, 33, 18);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}