using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class Toast : Page
    {
        public Toast()
        {
            this.InitializeComponent();
        }

        private async void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(ShowSlider.Value == 0)
            {
                await Popup.ShowPopupMessageAsync("Toast Example, tap on me to hide!", (int)ShowSlider.Value, (int)AnimSlider.Value);
            }
            else
            {
                await Popup.ShowPopupMessageAsync("Toast Example!", (int)ShowSlider.Value, (int)AnimSlider.Value);
            }
        }

        private async void Popup_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Popup.HidePopupMessageAsync((int)AnimSlider.Value);
        }
    }
}
