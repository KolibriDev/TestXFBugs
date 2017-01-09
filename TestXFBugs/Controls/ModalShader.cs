namespace TestXFBugs.Controls
{
    using Xamarin.Forms;

    public class ModalShader : Grid
    {
        public ModalShader()
        {
            this.BackgroundColor = (Color)Application.Current.Resources["BackMainDark"];
            this.Opacity = 0.6;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                var vm = this.BindingContext as IModalPage;
                if (vm != null)
                {
                    vm.IsActive = !vm.IsActive;
                }
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}
