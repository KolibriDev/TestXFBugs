namespace TestXFBugs.Controls
{
	using System;
	using System.Threading.Tasks;
	using Xamarin.Forms;

	/// <summary>
	/// AuthenticationControl
	/// </summary>
	public partial class AuthenticationControl : ContentView
	{
#pragma warning disable SA1401 // Fields must be private
		/// <summary>
		/// The username property
		/// </summary>
		public static BindableProperty UsernameProperty =
			BindableProperty.Create(
				"Username",
				typeof(string),
				typeof(AuthenticationControl),
				string.Empty,
				BindingMode.TwoWay,
				propertyChanging: (bindable, oldValue, newValue) =>
				{
					var ctrl = (AuthenticationControl)bindable;
					ctrl.Username = (string)newValue;
				});

		/// <summary>
		/// The password property
		/// </summary>
		public static BindableProperty PasswordProperty =
			BindableProperty.Create(
				"Password",
				typeof(string),
				typeof(AuthenticationControl),
				string.Empty,
				BindingMode.TwoWay,
				propertyChanging: (bindable, oldValue, newValue) =>
				{
					var ctrl = (AuthenticationControl)bindable;
					ctrl.Password = (string)newValue;
				});

		/// <summary>
		/// The OTP property
		/// </summary>
		public static BindableProperty OTPProperty =
			BindableProperty.Create(
				"OTP",
				typeof(string),
				typeof(AuthenticationControl),
				string.Empty,
				BindingMode.TwoWay,
				propertyChanging: (bindable, oldValue, newValue) =>
				{
					var ctrl = (AuthenticationControl)bindable;
					ctrl.OTP = (string)newValue;
				});

		/// <summary>
		/// The Is Keyboard Active property
		/// </summary>
		public static BindableProperty IsKeyboardActiveProperty =
			BindableProperty.Create(
				"IsKeyboardActive",
				typeof(bool),
				typeof(AuthenticationControl),
				false,
				BindingMode.TwoWay,
				propertyChanging: (bindable, oldValue, newValue) =>
				{
					var ctrl = (AuthenticationControl)bindable;
					ctrl.IsKeyboardActive = (bool)newValue;
				});

		/// <summary>
		/// The OTP property
		/// </summary>
		public static BindableProperty SmsBackupCommandProperty =
			BindableProperty.Create(
				"SmsBackupCommand",
				typeof(Command),
				typeof(AuthenticationControl),
				null,
				BindingMode.TwoWay,
				propertyChanging: (bindable, oldValue, newValue) =>
				{
					var ctrl = (AuthenticationControl)bindable;
					ctrl.SmsBackupCommand = (Command)newValue;
				});
#pragma warning restore SA1401 // Fields must be private

		/// <summary>
		/// Initializes a new instance of the <see cref="AuthenticationControl"/> class.
		/// </summary>
		public AuthenticationControl()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>
		/// The username.
		/// </value>
		public string Username
		{
			get
			{
				return (string)this.GetValue(UsernameProperty);
			}

			set
			{
				this.SetValue(UsernameProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		public string Password
		{
			get
			{
				return (string)this.GetValue(PasswordProperty);
			}

			set
			{
				this.SetValue(PasswordProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets OTP.
		/// </summary>
		/// <value>
		/// The OTP.
		/// </value>
		public string OTP
		{
			get
			{
				return (string)this.GetValue(OTPProperty);
			}

			set
			{
				this.SetValue(OTPProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the keyboard is active.
		/// </summary>
		/// <value>
		/// Keyboard status.
		/// </value>
		public bool IsKeyboardActive
		{
			get
			{
				return (bool)this.GetValue(IsKeyboardActiveProperty);
			}

			set
			{
				this.SetValue(IsKeyboardActiveProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the SmsBackupCommand.
		/// </summary>
		/// <value>
		/// The SmsBackupCommand.
		/// </value>
		public Command SmsBackupCommand
		{
			get
			{
				return (Command)this.GetValue(SmsBackupCommandProperty);
			}

			set
			{
				this.SetValue(SmsBackupCommandProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the username entry is focused.
		/// </summary>
		private bool IsUsernameFocused { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the password entry is focused.
		/// </summary>
		private bool IsPasswordFocused { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the OTP entry is focused.
		/// </summary>
		private bool IsOtpFocused { get; set; }

		/// <summary>
		/// Event that fires when name entry is focused.
		/// </summary>
		/// <param name="sender">entry</param>
		/// <param name="e">event</param>
		private void OnEntryNameFocused(object sender, EventArgs e)
		{
			this.IsKeyboardActive = true;
			this.IsUsernameFocused = true;
		}

		/// <summary>
		/// Event that fires when name entry is unfocused.
		/// </summary>
		/// <param name="sender">entry</param>
		/// <param name="e">event</param>
		private async void OnEntryNameUnfocused(object sender, EventArgs e)
		{
			await Task.Delay(200);
			if (!this.IsPasswordFocused && !this.IsOtpFocused)
			{
				this.IsKeyboardActive = false;
			}

			this.IsUsernameFocused = false;
		}

		/// <summary>
		/// Event that fires when password entry is focused.
		/// </summary>
		/// <param name="sender">entry</param>
		/// <param name="e">event</param>
		private void OnEntryPassFocused(object sender, EventArgs e)
		{
			this.IsKeyboardActive = true;
			this.IsPasswordFocused = true;
		}

		/// <summary>
		/// Event that fires when password entry is unfocused.
		/// </summary>
		/// <param name="sender">entry</param>
		/// <param name="e">event</param>
		private async void OnEntryPassUnfocused(object sender, EventArgs e)
		{
			await Task.Delay(200);
			if (!this.IsUsernameFocused && !this.IsOtpFocused)
			{
				this.IsKeyboardActive = false;
			}

			this.IsPasswordFocused = false;
		}

		/// <summary>
		/// Event that fires when OTP entry is focused.
		/// </summary>
		/// <param name="sender">entry</param>
		/// <param name="e">event</param>
		private void OnEntryOtpFocused(object sender, EventArgs e)
		{
			this.IsKeyboardActive = true;
			this.IsOtpFocused = true;
		}

		/// <summary>
		/// Event that fires when OTP entry is unfocused.
		/// </summary>
		/// <param name="sender">entry</param>
		/// <param name="e">event</param>
		private async void OnEntryOtpUnfocused(object sender, EventArgs e)
		{
			await Task.Delay(200);
			if (!this.IsUsernameFocused && !this.IsPasswordFocused)
			{
				this.IsKeyboardActive = false;
			}

			this.IsOtpFocused = false;
		}
	}
}
