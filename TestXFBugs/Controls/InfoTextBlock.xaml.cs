namespace TestXFBugs.Controls
{
	using Xamarin.Forms;

	/// <summary>
	/// The info block.
	/// </summary>
	public partial class InfoTextBlock
	{
#pragma warning disable SA1401 // Fields must be private

		/// <summary>
		/// The control height property
		/// </summary>
		public static BindableProperty ControlHeightProperty = BindableProperty.Create(
			"ControlHeightProperty",
			typeof(GridLength),
			typeof(InfoTextBlock),
			new GridLength(120d),
			BindingMode.TwoWay,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (InfoTextBlock)bindable;
				ctrl.ControlHeight = (GridLength)newValue;
			});

		/// <summary>
		/// The title property
		/// </summary>
		public static BindableProperty TextProperty = BindableProperty.Create(
			"Text",
			typeof(string),
			typeof(InfoTextBlock),
			string.Empty,
			BindingMode.TwoWay,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (InfoTextBlock)bindable;
				ctrl.Text = (string)newValue;
			});

		/// <summary>
		/// The icon property
		/// </summary>
		public static BindableProperty FormattedTextProperty = BindableProperty.Create(
			"FormattedTextProperty",
			typeof(FormattedString),
			typeof(InfoTextBlock),
			new FormattedString(),
			BindingMode.TwoWay,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (InfoTextBlock)bindable;
				ctrl.FormattedText = (FormattedString)newValue;
			});

		/// <summary>
		/// The text margin property
		/// </summary>
		public static BindableProperty TextMarginProperty = BindableProperty.Create(
			"TextMarginProperty",
			typeof(Thickness),
			typeof(InfoTextBlock),
			new Thickness(20,38),
			BindingMode.TwoWay,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (InfoTextBlock)bindable;
				ctrl.TextMargin = (Thickness)newValue;
			});

        /// <summary>
        /// The icon column width property
        /// </summary>
        public static BindableProperty IsBottomLineProperty = BindableProperty.Create(
            "IsBottomLine",
            typeof(bool),
            typeof(InfoTextBlock),
            true,
            BindingMode.TwoWay,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (InfoTextBlock)bindable;
                ctrl.IsBottomLine = (bool)newValue;
            });

#pragma warning restore SA1401 // Fields must be private

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoTextBlock"/> class.
        /// </summary>
        public InfoTextBlock()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the height of the control
		/// </summary>
		/// <value>
		/// The control height .
		/// </value>
		public GridLength ControlHeight
		{
			get
			{
				return (GridLength)this.GetValue(ControlHeightProperty);
			}

			set
			{
				if (this.ControlHeight.Value < value.Value + 0.5 && this.ControlHeight.Value > value.Value - 0.5)
				{
					return;
				}

				this.SetValue(ControlHeightProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the title text.
		/// </summary>
		/// <value>
		/// The title text.
		/// </value>
		public string Text
		{
			get
			{
				return (string)this.GetValue(TextProperty);
			}

			set
			{
				this.SetValue(TextProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the formatted text
		/// </summary>
		public FormattedString FormattedText
		{
			get
			{
				return (FormattedString)this.GetValue(FormattedTextProperty);
			}

			set
			{
				this.SetValue(FormattedTextProperty, value);

				// Necessary to set the FormattedText here specifically, else the Text property will be used
				this.TextLabel.FormattedText = value;
			}
		}

		/// <summary>
		/// Gets or sets the text margin.
		/// </summary>
		/// <value>
		/// The text margin .
		/// </value>
		public Thickness TextMargin
		{
			get
			{
				return (Thickness)this.GetValue(TextMarginProperty);
			}

			set
			{
				this.SetValue(TextMarginProperty, value);
			}
		}




		/// <summary>
		/// Gets or sets a value indicating whether there is bottom line.
		/// </summary>
		/// <value>
		/// The bottom line property.
		/// </value>
		public bool IsBottomLine
		{
			get
			{
				return (bool)this.GetValue(IsBottomLineProperty);
			}

			set
			{
				this.SetValue(IsBottomLineProperty, value);
			}
		}

		/// <summary>
		/// Gets the button line height.
		/// </summary>
		public double BottomLineHeight => this.IsBottomLine ? 0.5 : 0;
	}
}