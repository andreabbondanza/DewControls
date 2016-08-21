using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace DewCommonLibrary
{
    namespace AppSettingsHelper
    {
        /// <summary>
        /// Helper for AppSettings
        /// </summary>
        public class AppSettings
        {
            /// <summary>
            /// Set the local setting with the containskey control.
            /// </summary>
            /// <param name="name">The key name</param>
            /// <param name="val">the value casted in object</param>
            /// <param name="create">true = if not exists new key is create, else throw an exception</param>
            /// <exception cref="InvalidOperationException"></exception>
            public static void SetAppSettingsLocal(string name, object val, bool create = false)
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(name))
                    ApplicationData.Current.LocalSettings.Values[name] = val;
                else
                {
                    if (create)
                    {
                        AppSettings.DefineAppSettingsLocal(name, val);
                    }
                    else
                        throw new InvalidOperationException("Access without key definition");

                }

            }
            /// <summary>
            /// Get a local setting with containskey control.
            /// </summary>
            /// <param name="name">The key name</param>
            /// <returns>Object of setting, null if not exist</returns>
            public static object GetAppSettingsLocal(string name)
            {
                object Result = null;
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(name))
                    Result = ApplicationData.Current.LocalSettings.Values[name];
                return Result;
            }
            /// <summary>
            /// Create a new local setting
            /// </summary>
            /// <param name="name">The key name</param>
            /// <param name="val">The value in object</param>
            public static void DefineAppSettingsLocal(string name, object val)
            {
                ApplicationData.Current.LocalSettings.Values.Add(name, val);
            }
            /// <summary>
            /// Check if a key exists
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static bool AppSettingsLocalExists(string name)
            {
                return ApplicationData.Current.LocalSettings.Values.ContainsKey(name);
            }
            /// <summary>
            /// Remove a local setting
            /// </summary>
            /// <param name="name">key</param>
            public static void AppSettingsRemove(string name)
            {
                ApplicationData.Current.LocalSettings.Values.Remove(name);
            }

            /// <summary>
            /// Set the local setting with the containskey control.
            /// </summary>
            /// <param name="name">The key name</param>
            /// <param name="val">the value casted in object</param>
            /// <param name="create">true = if not exists new key is create, else throw an exception</param>
            /// <exception cref="InvalidOperationException"></exception>
            public static void SetAppSettingsRoam(string name, object val, bool create = false)
            {
                if (ApplicationData.Current.RoamingSettings.Values.ContainsKey(name))
                    ApplicationData.Current.RoamingSettings.Values[name] = val;
                else
                {
                    if (create)
                    {
                        AppSettings.DefineAppSettingsRoam(name, val);
                    }
                    else
                        throw new InvalidOperationException("Access without key definition");

                }

            }
            /// <summary>
            /// Get a local setting with containskey control.
            /// </summary>
            /// <param name="name">The key name</param>
            /// <returns>Object of setting, null if not exist</returns>
            public static object GetAppSettingsRoam(string name)
            {
                object Result = null;
                if (ApplicationData.Current.RoamingSettings.Values.ContainsKey(name))
                    Result = ApplicationData.Current.RoamingSettings.Values[name];
                return Result;
            }
            /// <summary>
            /// Create a new local setting
            /// </summary>
            /// <param name="name">The key name</param>
            /// <param name="val">The value in object</param>
            public static void DefineAppSettingsRoam(string name, object val)
            {
                ApplicationData.Current.RoamingSettings.Values.Add(name, val);
            }
            /// <summary>
            /// Check if a key exists
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static bool AppSettingsRoamExists(string name)
            {
                return ApplicationData.Current.LocalSettings.Values.ContainsKey(name);
            }
            /// <summary>
            /// Remove a local setting
            /// </summary>
            /// <param name="name">key</param>
            public static void AppSettingsRemoveRoam(string name)
            {
                ApplicationData.Current.RoamingSettings.Values.Remove(name);
            }
        }
    }
    namespace Converters
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