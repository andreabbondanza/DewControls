using DewCommonControlsLibrary;
using DewUserControls.DewLoaderPresentation.Types;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using AppStudio.Uwp.Controls;
using AppStudio.Uwp;
using System.Threading.Tasks;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DewUserControls
{
    /// <summary>
    /// A loader controller
    /// </summary>
    public sealed partial class DewLoader : UserControl
    {
       
        #region dependency
        /// <summary>
        /// The message font family
        /// </summary>
        public FontFamily MessageFontFamily
        {
            get { return (FontFamily)GetValue(MessageFontFamilyProperty); }
            set { SetValue(MessageFontFamilyProperty, value);  }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MessageFontFamilyProperty =
            DependencyProperty.Register("MessageFontFamily", typeof(FontFamily), typeof(DewLoader), new PropertyMetadata(new FontFamily("Segoe UI")));
        /// <summary>
        /// The message font size
        /// </summary>
        public double MessageFontSize
        {
            get { return (double)GetValue(MessageFontSizeProperty); }
            set { SetValue(MessageFontSizeProperty, value);  }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MessageFontSizeProperty =
            DependencyProperty.Register("MessageFontSize", typeof(double), typeof(DewLoader), new PropertyMetadata(11.0));
        /// <summary>
        /// Container corner radius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value);  }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(DewLoader), new PropertyMetadata(null));
        /// <summary>
        /// Message foreground
        /// </summary>
        public Brush MessageForeground
        {
            get { return (Brush)GetValue(MessageForegroundProperty); }
            set { SetValue(MessageForegroundProperty, value);  }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MessageForegroundProperty =
            DependencyProperty.Register("MessageForeground", typeof(Brush), typeof(DewLoader), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));
        /// <summary>
        /// The message
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(DewLoader), new PropertyMetadata(string.Empty));
        /// <summary>
        /// The ring position
        /// </summary>
        public RingPosition RingPosition
        {
            get { return (RingPosition)GetValue(RingPositionProperty); }
            set { SetValue(RingPositionProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty RingPositionProperty =
            DependencyProperty.Register("RingPosition", typeof(RingPosition), typeof(DewLoader), new PropertyMetadata(RingPosition.Top));

        /// <summary>
        /// True if ring is enabled
        /// </summary>
        public bool IsRingEnabled
        {
            get { return (bool)GetValue(IsRingEnabledProperty); }
            set { SetValue(IsRingEnabledProperty, value);  }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsRingEnabledProperty =
            DependencyProperty.Register("IsRingEnabled", typeof(bool), typeof(DewLoader), new PropertyMetadata(false));


        /// <summary>
        /// True if ring is active
        /// </summary>
        public bool IsRingActive
        {
            get { return (bool)GetValue(IsRingActiveProperty); }
            set { SetValue(IsRingActiveProperty, value);}
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsRingActiveProperty =
            DependencyProperty.Register("IsRingActive", typeof(bool), typeof(DewLoader), new PropertyMetadata(false));

        /// <summary>
        /// Get the state of control's visibility
        /// </summary>
        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("IsVisible", typeof(bool), typeof(DewLoader), new PropertyMetadata(false));

        #endregion
        #region methods
        /// <summary>
        /// Show a popup with fadein animation
        /// </summary>
        /// <param name="animationDuration">the translate time</param>
        public async Task ShowPopupLoaderAsync(int animationDuration = 500)
        {
            if (!this.IsVisible)
            {
                this.Opacity = 0;
                this.IsVisible = true;                
                await this.AnimateDoublePropertyAsync("Opacity", 0, 1, animationDuration);
            }
        }
        /// <summary>
        /// Show a popup with fadein animation
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="animationDuration">the translate time</param>
        public async Task ShowPopupLoaderAsync(string message, int animationDuration = 500)
        {
            if (!this.IsVisible)
            {
                this.Opacity = 0;
                this.IsVisible = true;
                this.Message = message;
                await this.AnimateDoublePropertyAsync("Opacity", 0, 1, animationDuration);
            }

        }
        /// <summary>
        /// Hide popup message with fadeout animation
        /// <param name="animationDuration">the translate time</param>
        /// </summary>
        public async Task HidePopupLoaderAsync(int animationDuration = 500)
        {
            await this.AnimateDoublePropertyAsync("Opacity", 1, 0, animationDuration);
            this.IsVisible = false;

        }
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public DewLoader()
        {
            this.InitializeComponent();
        }
    }
}
