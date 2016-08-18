using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DewUserControls.DewFloatButtonPresentation.Types;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Uwp.UI.Animations;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DewUserControls
{
    /// <summary>
    /// Float button
    /// </summary>
    public sealed partial class DewFloatButton : UserControl
    {
        #region dependency
        /// <summary>
        /// Button tapped event
        /// </summary>
        public new event TappedEventHandler Tapped = null;


        /// <summary>
        /// The float button content
        /// </summary>
        public object FloatButtonContent
        {
            get { return (object)GetValue(FloatButtonContentProperty); }
            set { SetValue(FloatButtonContentProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for FloatButtonContent.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty FloatButtonContentProperty =
            DependencyProperty.Register("FloatButtonContent", typeof(object), typeof(DewFloatButton), new PropertyMetadata(null));

        /// <summary>
        /// The float button background
        /// </summary>
        public Brush FloatButtonBackground
        {
            get { return (Brush)GetValue(FloatButtonBackgroundProperty); }
            set { SetValue(FloatButtonBackgroundProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for FloatButtonBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty FloatButtonBackgroundProperty =
            DependencyProperty.Register("FloatButtonBackground", typeof(Brush), typeof(DewFloatButton), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));


        /// <summary>
        /// The flyout max height
        /// </summary>
        public double FlyoutMaxHeight
        {
            get { return (double)GetValue(FlyoutMaxHeightProperty); }
            set { SetValue(FlyoutMaxHeightProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for FlyoutMaxHeight.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty FlyoutMaxHeightProperty =
            DependencyProperty.Register("FlyoutMaxHeight", typeof(double), typeof(DewFloatButton), new PropertyMetadata(400.0));
        
        /// <summary>
        /// Item text font size
        /// </summary>
        public double ItemTextFontSize
        {
            get { return (double)GetValue(ItemTextFontSizeProperty); }
            set { SetValue(ItemTextFontSizeProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for ItemTextFontSize.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ItemTextFontSizeProperty =
            DependencyProperty.Register("ItemTextFontSize", typeof(double), typeof(DewFloatButton), new PropertyMetadata(16.0));


        /// <summary>
        /// The item text font family
        /// </summary>
        public FontFamily ItemTextFontFamily
        {
            get { return (FontFamily)GetValue(ItemTextFontFamilyProperty); }
            set { SetValue(ItemTextFontFamilyProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for ItemTextFontFamily.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ItemTextFontFamilyProperty =
            DependencyProperty.Register("ItemTextFontFamily", typeof(FontFamily), typeof(DewFloatButton), new PropertyMetadata(new FontFamily("Segoe UI")));


        /// <summary>
        /// Item text foreground
        /// </summary>        
        public Brush ItemTextForeground
        {
            get { return (Brush)GetValue(ItemTextForegroundProperty); }
            set { SetValue(ItemTextForegroundProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for ItemTextForeground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ItemTextForegroundProperty =
            DependencyProperty.Register("ItemTextForeground", typeof(Brush), typeof(DewFloatButton), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// Item text background (default transparent)
        /// </summary>
        public Brush ItemTextBackground
        {
            get { return (Brush)GetValue(ItemTextBackgroundProperty); }
            set { SetValue(ItemTextBackgroundProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for ItemTextBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ItemTextBackgroundProperty =
            DependencyProperty.Register("ItemTextBackground", typeof(Brush), typeof(DewFloatButton), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        /// <summary>
        /// The item text alignment
        /// </summary>
        public HorizontalAlignment ItemTextHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(ItemTextHorizontalAlignmentProperty); }
            set { SetValue(ItemTextHorizontalAlignmentProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for ItemTextHorizontalAlignment.  This enables animation, styling, binding, etc...
        /// </summary>

        public static readonly DependencyProperty ItemTextHorizontalAlignmentProperty =
            DependencyProperty.Register("ItemTextHorizontalAlignment", typeof(HorizontalAlignment), typeof(DewFloatButton), new PropertyMetadata(HorizontalAlignment.Right));

        /// <summary>
        /// The item background
        /// </summary>
        public Brush ItemBackground
        {
            get { return (Brush)GetValue(ItemBackgroundProperty); }
            set { SetValue(ItemBackgroundProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for ItemBackground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ItemBackgroundProperty =
            DependencyProperty.Register("ItemBackground", typeof(Brush), typeof(DewFloatButton), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));


        /// <summary>
        /// The flyout container width
        /// </summary>
        public double FlyoutWidth
        {
            get { return (double)GetValue(FlyoutWidthProperty); }
            set { SetValue(FlyoutWidthProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for FlyoutWidth.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty FlyoutWidthProperty =
            DependencyProperty.Register("FlyoutWidth", typeof(double), typeof(DewFloatButton), new PropertyMetadata(150.0));


        /// <summary>
        /// A row height in flayout
        /// </summary>
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for ItemHeight.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(DewFloatButton), new PropertyMetadata(50));


        /// <summary>
        /// The flyout itemsource
        /// </summary>
        public ObservableCollection<DewFloatButtonItem> FlyoutItemsSource
        {
            get { return (ObservableCollection<DewFloatButtonItem>)GetValue(FlyoutItemsSourceProperty); }
            set { SetValue(FlyoutItemsSourceProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for FlyoutItemsSource.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty FlyoutItemsSourceProperty =
            DependencyProperty.Register("FlyoutItemsSource", typeof(ObservableCollection<DewFloatButtonItem>), typeof(DewFloatButton), new PropertyMetadata(null));

        /// <summary>
        /// Float button style
        /// </summary>
        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }
        ///<summary>
        /// Using a DependencyProperty as the backing store for ButtonStyle.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(DewFloatButton), new PropertyMetadata(null));

        /// <summary>
        /// Float button style
        /// </summary>
        public Style FlyoutStyle
        {
            get { return (Style)GetValue(FlyoutStyleProperty); }
            set { SetValue(FlyoutStyleProperty, value); }
        }
        ///<summary>
        /// Using a DependencyProperty as the backing store for ButtonStyle.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty FlyoutStyleProperty =
            DependencyProperty.Register("FlyoutStyle", typeof(Style), typeof(DewFloatButton), new PropertyMetadata(null));

        /// <summary>
        /// Button content glyph
        /// </summary>
        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Glyph.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty GlyphProperty =
            DependencyProperty.Register("Glyph", typeof(string), typeof(DewFloatButton), new PropertyMetadata(string.Empty));


        #endregion
        private bool isAnimationActive = false;
        /// <summary>
        /// Animation active propery
        /// </summary>
        public bool IsAnimationActive
        {
            get { return isAnimationActive; }
            set { isAnimationActive = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DewFloatButton()
        {
            this.InitializeComponent();
            this.ButtonStyle = this.Resources["DefaultFloatStyle"] as Style;
            this.FlyoutStyle = this.Resources["DefaultFlyoutStyle"] as Style;
        }

        /// <summary>
        /// When button tapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Float_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Tapped?.Invoke(sender, e);
        }
        /// <summary>
        /// Flyout opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FloatList_Opened(object sender, object e)
        {
            var b = FloatButton;
            if (this.isAnimationActive)
                await b.Rotate(duration: 500, delay: 0,
                                value: 405.0f,
                                centerX: ((float)(b.ActualWidth / 2)),
                                centerY: ((float)(b.ActualHeight / 2))).StartAsync();
        }
        /// <summary>
        /// Flyout closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FloatList_Closed(object sender, object e)
        {
            var b = FloatButton;
            if (this.isAnimationActive)
                await b.Rotate(duration: 500, delay: 0,
                            value: 0.0f,
                            centerX: ((float)(b.ActualWidth / 2)),
                            centerY: ((float)(b.ActualHeight / 2))).StartAsync();
        }
        /// <summary>
        /// Something has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FloatListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView l = sender as ListView;
            if (l.SelectedItem != null)
            {
                DewFloatButtonItem d = l.SelectedItem as DewFloatButtonItem;
                d.Selected();
            }
            l.SelectedItem = null;
        }
    }
}
