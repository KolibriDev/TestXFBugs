using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestXFBugs.Annotations;
using Xamarin.Forms;

namespace TestXFBugs
{
    public class PinPageViewModel : INotifyPropertyChanged
    {
        private const int PinLength = 2;

        private bool _validatingPin;
        private string _pinString;

        public PinPageViewModel()
        {
            this.ValidatingPin = false;
            this.PinString = string.Empty;
            this.AddCharCommand = new Command<string>(this.AddChar);
        }

        public Command<string> AddCharCommand { get; set; }

        public bool ValidatingPin
        {
            get
            {
                return this._validatingPin;
            }

            set
            {
                this._validatingPin = value;
                OnPropertyChanged();
            }
        }

        public string PinString
        {
            get
            {
                return this._pinString;
            }

            set
            {
                this._pinString = value;
                OnPropertyChanged();
            }
        }

        private void AddChar(string key)
        {
            if (key.Length != 1 || !char.IsDigit(key, 0))
            {
                throw new ArgumentException("PIN digit should be a number");
            }

            if (this.PinString.Length < PinLength)
            {
                this.PinString += key;
            }

            if (this.PinString.Length == PinLength)
            {
                this.ValidatingPin = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
