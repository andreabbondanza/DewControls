using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using DewUserControls.DewLoaderPresentation.Types;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlsExample.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Loader : Page
    {
        public Loader()
        {
            this.InitializeComponent();
            
        }

        private async void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string message = LoaderToast.Message;
            if (Msg.Text != string.Empty)
                message = Msg.Text;
            RingPosition r = RingPosition.Bottom;
            if (Rpos.IsOn)
                r = RingPosition.Top;
            LoaderToast.RingPosition = r;
            await LoaderToast.ShowPopupLoaderAsync(message, (int)AnimSlider.Value);
        }

        private async void Button_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            await LoaderToast.HidePopupLoaderAsync((int)AnimSlider.Value);
        }
    }
}
