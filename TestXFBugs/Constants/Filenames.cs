using Xamarin.Forms;

namespace TestXFBugs.Constants
{
    public static class Filenames
    {
        private static readonly string ImageLocation =
            Device.OnPlatform(string.Empty, string.Empty, "Assets/Images/");

        public static readonly string IconArrow = $"{ImageLocation}IconArrow.png";
        public static readonly string GreenCheckMark = $"{ImageLocation}GreenCheckMark.png";

    }
}
