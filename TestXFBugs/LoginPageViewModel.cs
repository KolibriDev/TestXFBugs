using Xamarin.Forms;

namespace TestXFBugs
{
    public class LoginPageViewModel
    {
        private bool _isKeyboardActive;

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
                this.SetScrollViewLayout(this._isKeyboardActive);
            }
        }

        public LayoutOptions ScrollViewLayoutOptions { get; set; }

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
    }
}
