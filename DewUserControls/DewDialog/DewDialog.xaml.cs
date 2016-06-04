using DewCommonControlsLibrary;
using DewUserControls.DewDialogPresentation.Types;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using AppStudio.Uwp;
using System.Threading.Tasks;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DewUserControls
{
    /// <summary>
    /// A dialog
    /// </summary>
    public sealed partial class DewDialog : UserControl
    {
        #region events
        /// <summary>
        /// Left Button tapped event
        /// </summary>
        public event TappedEventHandler LeftButtonTapped = null;
        /// <summary>
        /// Right button tapped event
        /// </summary>
        public event TappedEventHandler RightButtonTapped = null;
        /// <summary>
        /// Close button tapped event (append to close event)
        /// </summary>
        public event TappedEventHandler CloseButtonTapped = null;
        #endregion
        #region propdp


        #region topbar

        public string DialogTitle
        {
            get { return (string)GetValue(DialogTitleProperty); }
            set { SetValue(DialogTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DialogTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogTitleProperty =
            DependencyProperty.Register("DialogTitle", typeof(string), typeof(DewDialog), new PropertyMetadata(string.Empty));



        /// <summary>
        /// Close button X Foreground
        /// </summary>
        public SolidColorBrush CloseGlyphForeground
        {
            get { return (SolidColorBrush)GetValue(CloseGlyphForegroundProperty); }
            set { SetValue(CloseGlyphForegroundProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for CloseGlyphForeground.  This enables animation, styling, binding, etc...
        /// </summary>        
        public static readonly DependencyProperty CloseGlyphForegroundProperty =
            DependencyProperty.Register("CloseGlyphForeground", typeof(SolidColorBrush), typeof(DewDialog), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// Top bar Background
        /// </summary>
        public Brush TopBarBackground
        {
            get { return (Brush)GetValue(TopBarBackgroundProperty); }
            set { SetValue(TopBarBackgroundProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for TopBarBackground.  This enables animation, styling, binding, etc... 
        /// </summary>
        public static readonly DependencyProperty TopBarBackgroundProperty =
            DependencyProperty.Register("TopBarBackground", typeof(Brush), typeof(DewDialog), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));


        /// <summary>
        /// Top Bar foreground
        /// </summary>
        public SolidColorBrush TopBarForeground
        {
            get { return (SolidColorBrush)GetValue(TopBarForegroundProperty); }
            set { SetValue(TopBarForegroundProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for TopBarForeground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty TopBarForegroundProperty =
            DependencyProperty.Register("TopBarForeground", typeof(SolidColorBrush), typeof(DewDialog), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
        #endregion

        #region content


        /// <summary>
        /// Content Background
        /// </summary>
        public Brush ContentBackground
        {
            get { return (Brush)GetValue(ContentBackgroundProperty); }
            set { SetValue(ContentBackgroundProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ContentBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ContentBackgroundProperty =
            DependencyProperty.Register("ContentBackground", typeof(Brush), typeof(DewDialog), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));

        /// <summary>
        /// The main content
        /// </summary>
        public new UIElement Content
        {
            get { return (UIElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public new static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("ContentProperty", typeof(UIElement), typeof(DewHamburgerMenu), new PropertyMetadata(null));
        #endregion

        #region button area
        /// <summary>
        /// Button bar background
        /// </summary>
        public Brush ButtonAreaBackground
        {
            get { return (Brush)GetValue(ButtonAreaBackgroundProperty); }
            set { SetValue(ButtonAreaBackgroundProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ContentBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ButtonAreaBackgroundProperty =
            DependencyProperty.Register("ButtonAreaBackground", typeof(Brush), typeof(DewDialog), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));

        /// <summary>
        /// Left button style
        /// </summary>
        public Style LeftButtonStyle
        {
            get { return (Style)GetValue(LeftButtonStyleProperty); }
            set { SetValue(LeftButtonStyleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ContentBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty LeftButtonStyleProperty =
            DependencyProperty.Register("LeftButtonStyle", typeof(Style), typeof(DewDialog), new PropertyMetadata(null));


        /// <summary>
        /// Right button style
        /// </summary>
        public Style RightButtonStyle
        {
            get { return (Style)GetValue(RightButtonStyleProperty); }
            set { SetValue(RightButtonStyleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ContentBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty RightButtonStyleProperty =
            DependencyProperty.Register("RightButtonStyle", typeof(Style), typeof(DewDialog), new PropertyMetadata(null));
        #endregion
        /// <summary>
        /// Dialog type 
        /// </summary>
        public DewDialogDisplayType DialogType
        {
            get { return (DewDialogDisplayType)GetValue(DialogTypeProperty); }
            set
            {
                SetValue(DialogTypeProperty, value);
                switch (value)
                {
                    case DewDialogDisplayType.OnlyTopBar:
                        {
                            IsTopBarVisible = true;
                            IsButtonAreaVisible = false;
                            IsButtonLeftVisible = false;
                            break;
                        }
                    case DewDialogDisplayType.TopBarWithButtons:
                        {
                            IsTopBarVisible = true;
                            IsButtonAreaVisible = true;
                            IsButtonLeftVisible = true;
                            break;
                        }
                    case DewDialogDisplayType.Nothing:
                        {
                            IsTopBarVisible = false;
                            IsButtonAreaVisible = false;
                            IsButtonLeftVisible = false;
                            break;
                        }
                    case DewDialogDisplayType.TopBarAcceptButton:
                        {
                            IsTopBarVisible = true;
                            IsButtonAreaVisible = true;
                            IsButtonLeftVisible = false;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ContentBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty DialogTypeProperty =
            DependencyProperty.Register("DialogType", typeof(DewDialogDisplayType), typeof(DewDialog), new PropertyMetadata(DewDialogDisplayType.OnlyTopBar));

        /// <summary>
        /// Control visibility
        /// </summary>
        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ContentBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("IsVisible", typeof(bool), typeof(DewDialog), new PropertyMetadata(true));

        /// <summary>
        /// Top bar visibility
        /// </summary>
        public bool IsTopBarVisible
        {
            get { return (bool)GetValue(IsTopBarVisibleProperty); }
            set { SetValue(IsTopBarVisibleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ContentBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsTopBarVisibleProperty =
            DependencyProperty.Register("IsTopBarVisible", typeof(bool), typeof(DewDialog), new PropertyMetadata(true));
        /// <summary>
        /// Bottom bar visibility
        /// </summary>
        public bool IsButtonAreaVisible
        {
            get { return (bool)GetValue(IsButtonAreaVisibleProperty); }
            set { SetValue(IsButtonAreaVisibleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ContentBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsButtonAreaVisibleProperty =
            DependencyProperty.Register("IsButtonAreaVisible", typeof(bool), typeof(DewDialog), new PropertyMetadata(true));

        /// <summary>
        /// Bottom bar visibility
        /// </summary>
        public bool IsButtonLeftVisible
        {
            get { return (bool)GetValue(IsButtonLeftVisibleProperty); }
            set { SetValue(IsButtonLeftVisibleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ContentBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsButtonLeftVisibleProperty =
            DependencyProperty.Register("IsButtonLeftVisible", typeof(bool), typeof(DewDialog), new PropertyMetadata(true));
        #endregion
        #region attr

        #endregion
        #region prop




        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public DewDialog()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Left button tapped method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LeftButtonTapped?.Invoke(this, e);
        }
        /// <summary>
        /// Right button tapped method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RightButtonTapped?.Invoke(this, e);
        }
        /// <summary>
        /// Close button tapped method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Close_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid g = sender as Grid;
            Storyboard s = g.Resources["CloseButtonStoryboard"] as Storyboard;
            s.Begin();
            CloseButtonTapped?.Invoke(sender, e);
            await HideDialogAsync(300);
        }

        /// <summary>
        /// Show a dialog with fadein animation
        /// </summary>
        /// <param name="animationDuration">the translate time</param>
        public async Task ShowDialogAsync(int animationDuration = 500)
        {
            if (!IsVisible)
            {
                this.Opacity = 0;
                IsVisible = true;
                await this.AnimateDoublePropertyAsync("Opacity", 0, 1, animationDuration);
            }
        }
        /// <summary>
        /// Hide dialog with fadeout animation
        /// <param name="animationDuration">the translate time</param>
        /// </summary>
        public async Task HideDialogAsync(int animationDuration = 500)
        {
            await this.AnimateDoublePropertyAsync("Opacity", 1, 0, animationDuration);
            IsVisible = false;
        }
    }
}
