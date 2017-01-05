using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestXFBugs.Annotations;
using Xamarin.Forms;

namespace TestXFBugs
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private bool _isKeyboardActive;
        private LayoutOptions _scrollViewLayoutOptions;

        public LoginPageViewModel()
        {
            this.ScrollViewLayoutOptions = LayoutOptions.StartAndExpand;
        }

        public bool InfoVisible => !this.IsKeyboardActive;

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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
