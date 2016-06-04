using System;
using DewUserControls.DewHamburgerMenuPresentation.Types;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DewUserControls
{
    /// <summary>
    /// Hamburger menu
    /// </summary>
    public sealed partial class DewHamburgerMenu : UserControl
    {
        #region events
        /// <summary>
        /// Hamburger tapped event
        /// </summary>
        public event TappedEventHandler HamburgerTapped = null;
        /// <summary>
        /// PaneClosed event
        /// </summary>
        public event TypedEventHandler<SplitView, Object> PaneClosed = null;
        /// <summary>
        /// PanelClosing event
        /// </summary>
        public event TypedEventHandler<SplitView, Object> PaneClosing = null;
        #endregion
        #region prop

        #endregion
        #region propdp
        /// <summary>
        /// Set and Get the PanelOpened property
        /// </summary>
        public bool IsPaneOpened
        {
            get { return (bool)GetValue(IsPaneOpenedProperty); }
            set { SetValue(IsPaneOpenedProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsPaneOpenedProperty =
            DependencyProperty.Register("IsPaneOpened", typeof(bool), typeof(DewHamburgerMenu), new PropertyMetadata(false));


        /// <summary>
        /// Get\Set swipe opening
        /// </summary>
        public bool IsSwipeOpenEnabled
        {
            get { return (bool)GetValue(IsSwipeOpenEnabledProperty); }
            set { SetValue(IsSwipeOpenEnabledProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsSwipeOpenEnabledProperty =
            DependencyProperty.Register("IsSwipeOpenEnabled", typeof(bool), typeof(DewHamburgerMenu), new PropertyMetadata(true));



        #region bar
        /// <summary>
        /// Set\get the Hamburger Arrow animation
        /// </summary>
        public HamburgerButtonAnimation IsHamburgerButtonAnimationEnabled
        {
            get { return (HamburgerButtonAnimation)GetValue(IsHamburgerButtonEnabledProperty); }
            set { SetValue(IsHamburgerButtonEnabledProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsHamburgerButtonEnabledProperty =
            DependencyProperty.Register("IsArrowAnimationEnabled", typeof(HamburgerButtonAnimation), typeof(DewHamburgerMenu), new PropertyMetadata(HamburgerButtonAnimation.ToArrow));

        /// <summary>
        /// Top bar background color
        /// </summary>
        public Brush BarBackgroundColor
        {
            get { return (Brush)GetValue(BarBackgroundColorProperty); }
            set { SetValue(BarBackgroundColorProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty BarBackgroundColorProperty =
            DependencyProperty.Register("BarBackgroundColor", typeof(Brush), typeof(DewHamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        /// <summary>
        /// The Top bar content
        /// </summary>
        public UIElement BarContent
        {
            get { return (UIElement)GetValue(BarContentProperty); }
            set { SetValue(BarContentProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty BarContentProperty =
            DependencyProperty.Register("BarContent", typeof(UIElement), typeof(DewHamburgerMenu), new PropertyMetadata(null));

        /// <summary>
        /// Hamburger foreground color
        /// </summary>
        public Brush HamburgerForeground
        {
            get { return (Brush)GetValue(HamburgerForegroundProperty); }
            set { SetValue(HamburgerForegroundProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HamburgerForegroundProperty =
            DependencyProperty.Register("HamburgerForeground", typeof(Brush), typeof(DewHamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));


        /// <summary>
        /// Hamburger button background
        /// </summary>
        public Color HamburgerBackground
        {
            get { return (Color)GetValue(HamburgerBackgroundProperty); }
            set { SetValue(HamburgerBackgroundProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HamburgerBackgroundProperty =
            DependencyProperty.Register("HamburgerBackground", typeof(Color), typeof(DewHamburgerMenu), new PropertyMetadata(Colors.Transparent));

        /// <summary>
        /// Pressed background
        /// </summary>
        public Color HamburgerBackgroundPressed
        {
            get { return (Color)GetValue(HamburgerBackgroundPressedProperty); }
            set { SetValue(HamburgerBackgroundPressedProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HamburgerBackgroundPressedProperty =
            DependencyProperty.Register("HamburgerBackgroundPressed", typeof(Color), typeof(DewHamburgerMenu), new PropertyMetadata(Colors.Transparent));

        #endregion

        #region panel

        /// <summary>
        /// Get\set the Hamburger type 
        /// </summary>
        public HamburgerType HamburgerType
        {
            get { return (HamburgerType)GetValue(HamburgerTypeProperty); }
            set { SetValue(HamburgerTypeProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HamburgerTypeProperty =
            DependencyProperty.Register("HamburgerType", typeof(HamburgerType), typeof(DewHamburgerMenu), new PropertyMetadata(HamburgerType.LeftSide));
        /// <summary>
        /// The pane background
        /// </summary>
        public Brush PaneBackground
        {
            get { return (Brush)GetValue(PaneBackgroundProperty); }
            set { SetValue(PaneBackgroundProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty PaneBackgroundProperty =
            DependencyProperty.Register("PaneBackground", typeof(Brush), typeof(DewHamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));


        /// <summary>
        /// Get\set the panel content
        /// </summary>
        public UIElement PaneContent
        {
            get { return (UIElement)GetValue(PaneContentProperty); }
            set { SetValue(PaneContentProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty PaneContentProperty =
            DependencyProperty.Register("PaneContent", typeof(UIElement), typeof(DewHamburgerMenu), new PropertyMetadata(null));

        /// <summary>
        /// Main Content background color
        /// </summary>
        public Brush ContentBackground
        {
            get { return (Brush)GetValue(ContentBackgroundProperty); }
            set { SetValue(ContentBackgroundProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ContentBackgroundProperty =
            DependencyProperty.Register("ContentBackground", typeof(Brush), typeof(DewHamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));

        /// <summary>
        /// Get\set the Opened panel length
        /// </summary>
        public double OpenedPaneLength
        {
            get { return (double)GetValue(OpenedPaneLengthProperty); }
            set { SetValue(OpenedPaneLengthProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for MessageFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty OpenedPaneLengthProperty =
            DependencyProperty.Register("OpenedPaneLength", typeof(double), typeof(DewHamburgerMenu), new PropertyMetadata(200.0));



        #endregion

        #region content
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

        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public DewHamburgerMenu()
        {
            this.InitializeComponent();
        }




        /// <summary>
        /// Hamburger tapped event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HamburgerButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HamburgerAnimationOpening();
            HamburgerTapped?.Invoke(sender, e);
            IsPaneOpened = !IsPaneOpened;
            
        }

        /// <summary>
        /// Animate hamburger background 
        /// </summary>
        private void HamburgerAnimationOpening()
        {
            HamburgerBackgroundColor = new SolidColorBrush(this.HamburgerBackgroundPressed);
            AnimateHamburgerToTarget();
        }

        /// <summary>
        /// Animate target to hamburger
        /// </summary>
        private void AnimateTargetToHamburger()
        {
            switch (IsHamburgerButtonAnimationEnabled)
            {
                case HamburgerButtonAnimation.ToArrow:
                    {
                        Storyboard s = Resources["ToHamburgerFromArrow"] as Storyboard;
                        s.Begin();
                        break;
                    }
                case HamburgerButtonAnimation.ToVertical:
                    {
                        Storyboard s = Resources["ToHamburgerFromVertical"] as Storyboard;
                        s.Begin();
                        break;
                    }
                case HamburgerButtonAnimation.No:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Animate hamburger to arrow
        /// </summary>
        private void AnimateHamburgerToTarget()
        {
            switch (IsHamburgerButtonAnimationEnabled)
            {
                case HamburgerButtonAnimation.ToArrow:
                    {
                        Storyboard s1 = Resources["ToArrow"] as Storyboard;
                        s1.Begin();
                        break;
                    }
                case HamburgerButtonAnimation.ToVertical:
                    {
                        Storyboard s = Resources["ToVertical"] as Storyboard;
                        s.Begin();
                        break;
                    }
                case HamburgerButtonAnimation.No:
                    break;
                default:
                    break;
            }
            
        }

        /// <summary>
        /// Animate hamburger for closing
        /// </summary>
        private void HamburgerAnimationClosing()
        {
            HamburgerBackgroundColor = new SolidColorBrush(this.HamburgerBackground);
        }

        /// <summary>
        /// Animation hamburger completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HamburgerButtonCompleted(object sender, object e)
        {
            HamburgerAnimationClosing();
        }

        /// <summary>
        /// Panel closed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SplitView_PaneClosed(SplitView sender, object args)
        {
            AnimateTargetToHamburger();
            PaneClosed?.Invoke(sender, args);
        }
        /// <summary>
        /// Panel closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SplitView_PaneClosing(SplitView sender, SplitViewPaneClosingEventArgs args)
        {
            PaneClosing?.Invoke(sender, args);
        }

        /// <summary>
        /// Open panel with swipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplitViewOpener_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (!IsPaneOpened)
            {
                HamburgerAnimationOpening();
                switch (this.HamburgerType)
                {
                    case HamburgerType.LeftSide:
                    case HamburgerType.LeftSideCompact:
                    case HamburgerType.LeftSideInLine:
                    case HamburgerType.LeftSideCompactInLine:
                        {
                            if (e.Cumulative.Translation.X > 50)
                            {
                                IsPaneOpened = true;
                            }
                            break;
                        }
                    case HamburgerType.RightSideCompact:
                    case HamburgerType.RightSideInLine:
                    case HamburgerType.RightSide:
                    case HamburgerType.RightSideCompactInLine:
                        {
                            if (e.Cumulative.Translation.X < 50)
                            {
                                IsPaneOpened = true;
                            }
                            break;
                        }
                    default:
                        break;
                }             
            }
        }

    }
}
