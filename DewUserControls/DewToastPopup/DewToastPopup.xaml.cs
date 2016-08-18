using System.Threading.Tasks;
using DewCommonControlsLibrary;
using DewUserControls.DewToastPopupPresentation.Types;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Microsoft.Toolkit.Uwp.UI.Animations;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DewUserControls
{
    /// <summary>
    /// Toast controller
    /// </summary>
    public sealed partial class DewToastPopup : UserControl
    {
        #region dependency
        /// <summary>
        /// The message font family
        /// </summary>
        public FontFamily MessageFontFamily
        {
            get { return (FontFamily)GetValue(MessageFontFamilyProperty); }
            set { SetValue(MessageFontFamilyProperty, value);}
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MessageFontFamilyProperty =
            DependencyProperty.Register("MessageFontFamily", typeof(FontFamily), typeof(DewToastPopup), new PropertyMetadata(new FontFamily("Segoe UI")));



        /// <summary>
        /// The message font size
        /// </summary>
        public double MessageFontSize
        {
            get { return (double)GetValue(MessageFontSizeProperty); }
            set { SetValue(MessageFontSizeProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MessageFontSizeProperty =
            DependencyProperty.Register("MessageFontSize", typeof(double), typeof(DewToastPopup), new PropertyMetadata(11.0));


        /// <summary>
        /// The popup corner radius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(DewToastPopup), new PropertyMetadata(null));

        /// <summary>
        /// The popup background
        /// </summary>
        new public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly new DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(DewToastPopup), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));
        /// <summary>
        /// The message foreground
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
            DependencyProperty.Register("MessageForeground", typeof(Brush), typeof(DewToastPopup), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));
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
            DependencyProperty.Register("Message", typeof(string), typeof(DewToastPopup), new PropertyMetadata(string.Empty));
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
            DependencyProperty.Register("IsVisible", typeof(bool), typeof(DewToastPopup), new PropertyMetadata(false));




        #endregion
        #region attr
        private byte PopupCount = 0;
        private byte OldCount = 0;
        #endregion


       
        /// <summary>
        /// Show a popup with fadein animation
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="time">If set, the popup will be closed after a time delay</param>
        /// <param name="animationDuration">the translate time</param>
        public async Task ShowPopupMessageAsync(string message = null, int time = 0, int animationDuration = 500)
        {
            if (PopupCount < 254)
                PopupCount++;
            var popupCount = PopupCount;
            this.Opacity = 0;
            this.IsVisible = true;
            if(message != null)
                this.Message = message;
            await this.Fade(1, animationDuration, 0).StartAsync();
            //await this.AnimateDoublePropertyAsync("Opacity", 0, 1, animationDuration);
            if (time > 0)
            {
                await Task.Delay(time);
                if (PopupCount == popupCount)
                {
                    OldCount = popupCount;
                    await this.HidePopupMessageAsync(animationDuration);
                }
            }
            
           
        }
        /// <summary>
        /// Hide popup message with fadeout animatino
        /// <param name="animationDuration">the translate time</param>
        /// </summary>
        public async Task HidePopupMessageAsync(int animationDuration = 500)
        {
            await this.Fade(0, animationDuration, 0).StartAsync();
            //await this.AnimateDoublePropertyAsync("Opacity", 1, 0, animationDuration);
            if (PopupCount == OldCount)
            {
                this.IsVisible = false;
                this.Message = string.Empty;
            }
            if (PopupCount >= 254)
            {
                PopupCount = 0;
                OldCount = 0;
            }

        }
        /// <summary>
        /// constructor
        /// </summary>
        public DewToastPopup()
        {
            this.InitializeComponent();
        }
    }
}
