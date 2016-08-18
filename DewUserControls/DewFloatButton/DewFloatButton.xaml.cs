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
        /// Glyph foreground
        /// </summary>
        public Brush GlyphForeground
        {
            get { return (Brush)GetValue(GlyphForegroundProperty); }
            set { SetValue(GlyphForegroundProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for GlyphForeground.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty GlyphForegroundProperty =
            DependencyProperty.Register("GlyphForeground", typeof(Brush), typeof(DewFloatButton), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));



        /// <summary>
        /// Button glyph font size
        /// </summary>
        public double GlyphFontSize
        {
            get { return (double)GetValue(GlyphFontSizeProperty); }
            set { SetValue(GlyphFontSizeProperty, value); }
        }
        /// <summary>
        /// Using a DependencyProperty as the backing store for GlyphFontSize.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty GlyphFontSizeProperty =
            DependencyProperty.Register("GlyphFontSize", typeof(double), typeof(DewFloatButton), new PropertyMetadata(14.0));



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
        /// <summary>
        /// Constructor
        /// </summary>
        public DewFloatButton()
        {
            this.InitializeComponent();
            this.ButtonStyle = this.Resources["DefaultFloatStyle"] as Style;
        }
    }
}
