# TestXFBugs

## Droid bugs

### Layout not moved up

    Xamarin.Forms 2.3.3.175: When the user clicks on an entry on LoginPage, the soft keyboard is displayed, but the layout is not moved up.
    Xamarin.Forms 2.3.2.127: When the user clicks on an entry on LoginPage, the soft keyboard is displayed AND the layout is moved up.

### Problem changing style when button is disabled 

    Xamarin.Forms 2.3.3.175: When a button's style is changed and the button is disabled (IsEnabled=false) the styling does not work. This can be seen by navigating to the PinPage (by clicking the Login button on the LoginPage) and clicking twice on any button. Then all buttons should become disabled and the style WhiteButtonDisabled should be applied which changes the TextColor of the buttons. Instead, the text for the buttons disappears. Note that if the buttons are not disabled when changing the style, the styling works.
    Xamarin.Forms 2.3.2.127: We have an app in which the above styling works in 2.3.2.127, but not in 2.3.3.175. However, in this TestXFBugs project, the same problem exists in 2.3.2.127.

### Setting Opacity causes crash
    
    Xamarin.Forms 2.3.3.175: Navigate to the PinPage (by clicking to Login button on the LoginPage) and click the Confirmation button. On the next page (TransferConfirmedPage), click the Send notification button.  The following exception will occur: "Java.Lang.IllegalStateException: Unable to create layer for Platform_DefaultRenderer”. The TransferConfirmedPage uses the ModalShader class.  In the constructor of the ModalShader, comment out the statement 'this.Opacity = 0.6'. By doing so, the app does not crash.
    Xamarin.Forms 2.3.2.127: The above exception does not occur.
