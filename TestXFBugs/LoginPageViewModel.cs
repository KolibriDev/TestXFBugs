using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestXFBugs.Annotations;
using Xamarin.Forms;

namespace TestXFBugs
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private bool _isKeyboardActive;
        private string _userName;
        private string _password;
        private string _otp;

        private INavigation _navigation;
        private LayoutOptions _scrollViewLayoutOptions;

        public LoginPageViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            this.LoginCommand = new Command(this.Login);
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.OTP = string.Empty;

            this.ScrollViewLayoutOptions = LayoutOptions.StartAndExpand;
        }

        public Command LoginCommand { get; set; }

        public bool InfoVisible => !this.IsKeyboardActive;

        public string Username {
            get { return this._userName; }

            set
            {
                this._userName = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }

        public string Password {
            get { return this._password; }

            set
            {
                this._password = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }

        public string OTP {
            get { return this._otp; }

            set
            {
                this._otp = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }

        public bool IsLoginEnabled
            => this.Username.Length > 0 && 
            this.Password.Length > 0 && 
            this.OTP.Length > 0;


        public bool IsKeyboardActive
        {
            get { return this._isKeyboardActive; }

            set
            {
                this._isKeyboardActive = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(InfoVisible));
                this.SetScrollViewLayout(this._isKeyboardActive);
            }
        }

        public LayoutOptions ScrollViewLayoutOptions
        {
            get { return this._scrollViewLayoutOptions; }
            set
            {
                this._scrollViewLayoutOptions = value;
                this.OnPropertyChanged();
            }
        }

        private void SetScrollViewLayout(bool keyboardActive)
        {
            if (keyboardActive && Device.OS == TargetPlatform.iOS)
            {
                this.ScrollViewLayoutOptions = LayoutOptions.Start;
            }
            else
            {
                this.ScrollViewLayoutOptions = LayoutOptions.StartAndExpand;
            }
        }

        private void Login()
        {
            this._navigation.PushAsync(new PinPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
