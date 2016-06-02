using System;
using DewUserControls.DewLoaderPresentation.Types;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace DewUserControls.DewLoaderPresentation
{
    namespace Types
    {    /// <summary>
         /// Ring position
         /// </summary>
        public enum RingPosition
        {
            /// <summary>
            /// Top
            /// </summary>
            Top,
            /// <summary>
            /// Bar
            /// </summary>
            Bottom
        }
    }

    namespace Converters
    {
        /// <summary>
        /// Convert ring position to visibility
        /// </summary>
        public class RingPositionToVisibilityConverter : IValueConverter
            {/// <summary>
             /// Convert from source to UI
             /// </summary>
             /// <param name="value"></param>
             /// <param name="targetType"></param>
             /// <param name="parameter"></param>
             /// <param name="language"></param>
             /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                string s = parameter as string;
                RingPosition r = (RingPosition)value;
                Visibility result = Visibility.Collapsed;
                if (r == RingPosition.Top && s == "Top")
                    result = Visibility.Visible;
                else
                    if (r == RingPosition.Bottom && s == "Bottom")
                    result = Visibility.Visible;
                return result;
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
        /// Convert ring padding via position
        /// </summary>
        public class RingPositionToPaddingConverter : IValueConverter
        {/// <summary>
         /// Convert from source to UI
         /// </summary>
         /// <param name="value"></param>
         /// <param name="targetType"></param>
         /// <param name="parameter"></param>
         /// <param name="language"></param>
         /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                RingPosition r = (RingPosition)value;
                Thickness t;
                if (r == RingPosition.Top)
                    t = new Thickness(5, 10, 5, 5);
                else
                    t = new Thickness(5, 5, 5, 10);
                return t;
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
    }
}
