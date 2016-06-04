using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ControlsExample.Pages;
using ControlsExample.VM;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ControlsExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel = new MainViewModel();
        public MainPage()
        {
            this.InitializeComponent();
        }



        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView l = sender as ListView;
            if(l.SelectedIndex != -1)
            {
                switch (l.SelectedIndex)
                {
                    case 0:
                        {
                            TheFrame.Navigate(typeof(Hamburger));
                            break;
                        }
                    case 1:
                        {
                            TheFrame.Navigate(typeof(Toast));
                            break;
                        }
                    case 2:
                        {
                            TheFrame.Navigate(typeof(Loader));
                            break;
                        }
                    case 3:
                        {
                            TheFrame.Navigate(typeof(DialogPage));
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.SelectedIndex = 0;
        }
    }
}
