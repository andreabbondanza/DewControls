using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DewUserControls.DewListSelectorPresentation.Types;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DewUserControls
{
    /// <summary>
    /// DewListSelector class
    /// </summary>
    public sealed partial class DewListSelector : UserControl
    {
        #region events
        /// <summary>
        /// List selected item event
        /// </summary>
        public event TappedEventHandler OnChecked = null;
        #endregion
        #region prodp


        /// <summary>
        /// Text title
        /// </summary>
        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        /// <summary>
        /// Text title dp
        /// </summary>
        public static readonly DependencyProperty TitleTextProperty =
            DependencyProperty.Register("TitleText", typeof(string), typeof(DewListSelectorItem), new PropertyMetadata(""));



        /// <summary>
        /// The item list
        /// </summary>
        public ObservableCollection<DewListSelectorItem> Items
        {
            get { return (ObservableCollection<DewListSelectorItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        /// <summary>
        /// The item list dp
        /// </summary>
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<DewListSelectorItem>), typeof(DewListSelector), new PropertyMetadata(null));

        /// <summary>
        /// The line separator foreground
        /// </summary>
        public SolidColorBrush SeparatorForeground
        {
            get { return (SolidColorBrush)GetValue(SeparatorForegroundProperty); }
            set { SetValue(SeparatorForegroundProperty, value); }
        }

        /// <summary>
        /// The line separator foreground dependency
        /// </summary>
        public static readonly DependencyProperty SeparatorForegroundProperty =
            DependencyProperty.Register("SeparatorForeground", typeof(SolidColorBrush), typeof(DewListSelector), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// The text title foreground
        /// </summary>
        public SolidColorBrush TextTitleForeground
        {
            get { return (SolidColorBrush)GetValue(TextTitleForegroundProperty); }
            set { SetValue(TextTitleForegroundProperty, value); }
        }

        /// <summary>
        /// The text title foreground dependency
        /// </summary>
        public static readonly DependencyProperty TextTitleForegroundProperty =
            DependencyProperty.Register("TextTitleForeground", typeof(SolidColorBrush), typeof(DewListSelector), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// The text list separator foreground
        /// </summary>
        public SolidColorBrush TextListForeground
        {
            get { return (SolidColorBrush)GetValue(TextListForegroundProperty); }
            set { SetValue(TextListForegroundProperty, value); }
        }

        /// <summary>
        /// The text list foreground dependency
        /// </summary>
        public static readonly DependencyProperty TextListForegroundProperty =
            DependencyProperty.Register("TextListForeground", typeof(SolidColorBrush), typeof(DewListSelector), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// The checkbox border foreground
        /// </summary>
        public SolidColorBrush CheckBoxBorderForeground
        {
            get { return (SolidColorBrush)GetValue(CheckBoxBorderForegroundProperty); }
            set { SetValue(CheckBoxBorderForegroundProperty, value); }
        }

        /// <summary>
        /// The checkbox border foreground dependency
        /// </summary>
        public static readonly DependencyProperty CheckBoxBorderForegroundProperty =
            DependencyProperty.Register("CheckBoxBorderForeground", typeof(SolidColorBrush), typeof(DewListSelector), new PropertyMetadata(new SolidColorBrush(Colors.Black)));


        /// <summary>
        /// The container background
        /// </summary>
        public Brush ContainerBackground
        {
            get { return (Brush)GetValue(ContainerBackgroundProperty); }
            set { SetValue(ContainerBackgroundProperty, value); }
        }

        /// <summary>
        /// The container background dp
        /// </summary>
        public static readonly DependencyProperty ContainerBackgroundProperty =
            DependencyProperty.Register("ContainerBackground", typeof(Brush), typeof(DewListSelector), new PropertyMetadata(new SolidColorBrush(Colors.WhiteSmoke)));
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public DewListSelector()
        {
            this.InitializeComponent();
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid g = sender as Grid;
            string id = g.Tag as string;
            var item = this.Items.First(x => x.Id == id);
            item.IsChecked = !item.IsChecked;
            this.OnChecked?.Invoke(sender, e);
        }
    }
}
