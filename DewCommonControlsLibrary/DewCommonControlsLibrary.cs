using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace DewCommonControlsLibrary
{

    namespace DewCommonControlsLibraryConverters
    {
        /// <summary>
        /// Convert a bool to a Visibile object on Convert, reverse in ConvertBack
        /// </summary>
        public class BoolToVisibilityConverter : IValueConverter
        {
            /// <summary>
            /// Convert from source to UI
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, string language) => (bool)value == true ? Visibility.Visible : Visibility.Collapsed;
            /// <summary>
            /// Convert from UI to source
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object ConvertBack(object value, Type targetType, object parameter, string language) => (Visibility)value == Visibility.Visible ? true : false;
        }
        /// <summary>
        /// Convert a Visibility object to a bool on Convert, reverse in ConvertBack
        /// </summary>
        public class VisibilityToBoolConverter : IValueConverter
        {
            /// <summary>
            /// Convert from source to UI
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, string language) => (Visibility)value == Visibility.Visible ? true : false;
            /// <summary>
            /// Convert from UI to source
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object ConvertBack(object value, Type targetType, object parameter, string language) => (bool)value == true ? Visibility.Visible : Visibility.Collapsed;
        }
        /// <summary>
        /// Good way to debug binding
        /// </summary>
        public class DebugConverter : IValueConverter
        {
            /// <summary>
            /// Convert from source to UI, show the value in output console
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                System.Diagnostics.Debug.WriteLine("DEBUG :" + value);
                return value;
            }

            /// <summary>
            /// Convert from UI to source, show the value in output console
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                System.Diagnostics.Debug.WriteLine("DEBUG :"+value);
                return value;
            }
        }
        /// <summary>
        /// Convert a color to nullable color
        /// </summary>
        public class ColorToNullableColor : IValueConverter
        {
            /// <summary>
            /// Convert from source to UI
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                Color c = (Color)value;
                return c;
            }
            /// <summary>
            /// Convert from UI to source
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Convert null value to visibilty
        /// </summary>
        public class NullToVisibilityConverter : IValueConverter
        {
            /// <summary>
            /// Convert from source to UI, if parameter is "inv" it will use equivalence for null = Visible, default is null = collapsed
            /// </summary>
            /// <param name="value">The nullable value</param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, string language) => value == null ? (parameter as string == "inv" ? Visibility.Visible : Visibility.Collapsed) : (parameter as string == "inv" ? Visibility.Collapsed: Visibility.Visible);
            
            /// <summary>
            /// Convert from UI to source
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                return value;
            }
        }
    }
}