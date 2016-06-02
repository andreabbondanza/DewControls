using System;
using DewUserControls.DewHamburgerMenuPresentation.Types;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace DewUserControls.DewHamburgerMenuPresentation
{
    namespace Types
    {
        /// <summary>
        /// Hamburger type
        /// </summary>
        public enum HamburgerType
        {
            /// <summary>
            /// left side
            /// </summary>
            LeftSide,
            /// <summary>
            /// right side
            /// </summary>
            RightSide,
            /// <summary>
            /// left side compact
            /// </summary>
            LeftSideCompact,
            /// <summary>
            /// right side compact
            /// </summary>
            RightSideCompact,
            /// <summary>
            /// left side inline
            /// </summary>
            LeftSideInLine,
            /// <summary>
            /// right side inline
            /// </summary>
            RightSideInLine,
            /// <summary>
            /// left side compact inline
            /// </summary>
            LeftSideCompactInLine,
            /// <summary>
            /// right side compact inline
            /// </summary>
            RightSideCompactInLine
        }
        /// <summary>
        /// Arrow animation
        /// </summary>
        public enum HamburgerButtonAnimation
        {
            /// <summary>
            /// arrow animation
            /// </summary>
            ToArrow,
            /// <summary>
            /// rotate animation
            /// </summary>
            ToVertical,
            /// <summary>
            /// no animation
            /// </summary>
            No
        }
    }
    namespace Converters
    {
        class HamburgerTypeToPanePlace : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                HamburgerType ht = (HamburgerType)value;
                SplitViewPanePlacement spp = SplitViewPanePlacement.Left;
                switch (ht)
                {
                    case HamburgerType.LeftSide:
                        break;
                    case HamburgerType.RightSide:
                        {
                            spp = SplitViewPanePlacement.Right;
                            break;
                        }
                    case HamburgerType.LeftSideCompact:
                        break;
                    case HamburgerType.RightSideCompact:
                        {
                            spp = SplitViewPanePlacement.Right;
                            break;
                        }
                    case HamburgerType.LeftSideInLine:
                        break;
                    case HamburgerType.RightSideInLine:
                        {
                            spp = SplitViewPanePlacement.Right;
                            break;
                        }
                    case HamburgerType.LeftSideCompactInLine:
                        break;
                    case HamburgerType.RightSideCompactInLine:
                        {
                            spp = SplitViewPanePlacement.Right;
                            break;
                        }
                    default:
                        break;
                }
                return spp;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }

        class HamburgerTypeToDisplayMode : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                HamburgerType ht = (HamburgerType)value;
                SplitViewDisplayMode sdm = SplitViewDisplayMode.Overlay;
                switch (ht)
                {
                    case HamburgerType.LeftSide:
                        break;
                    case HamburgerType.RightSide:
                        break;
                    case HamburgerType.LeftSideCompact:
                        {
                            sdm = SplitViewDisplayMode.CompactOverlay;
                            break;
                        }
                    case HamburgerType.RightSideCompact:
                        {
                            sdm = SplitViewDisplayMode.CompactOverlay;
                            break;
                        }
                    case HamburgerType.LeftSideInLine:
                        {
                            sdm = SplitViewDisplayMode.Inline;
                            break;
                        }
                    case HamburgerType.RightSideInLine:
                        {
                            sdm = SplitViewDisplayMode.Inline;
                            break;
                        }
                    case HamburgerType.LeftSideCompactInLine:
                        {
                            sdm = SplitViewDisplayMode.CompactInline;
                            break;
                        }
                    case HamburgerType.RightSideCompactInLine:
                        {
                            sdm = SplitViewDisplayMode.CompactInline;
                            break;
                        }
                    default:
                        break;
                }
                return sdm;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }

        class HamburgerTypeToHorizontalAlighment : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                HamburgerType ht = (HamburgerType)value;
                HorizontalAlignment ha = HorizontalAlignment.Left;
                switch (ht)
                {
                    case HamburgerType.LeftSide:
                    case HamburgerType.LeftSideCompact:
                    case HamburgerType.LeftSideInLine:
                    case HamburgerType.LeftSideCompactInLine:
                        break;
                    case HamburgerType.RightSide:                    
                    case HamburgerType.RightSideCompact:                    
                    case HamburgerType.RightSideInLine:                    
                    case HamburgerType.RightSideCompactInLine:
                        {
                            ha = HorizontalAlignment.Right;
                            break;
                        }
                    default:
                        break;
                }
                return ha;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }

        class HamburgerTypeToHamburgerPositionColumn : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                HamburgerType ht = (HamburgerType)value;
                int result = 0;
                switch (ht)
                {
                    case HamburgerType.LeftSide:
                    case HamburgerType.LeftSideCompact:
                    case HamburgerType.LeftSideInLine:
                    case HamburgerType.LeftSideCompactInLine:
                        {
                            if(parameter as string == "first")
                            {
                                result = 0;
                            }
                            else
                            {
                                result = 1;
                            }
                            break;
                        }
                    case HamburgerType.RightSide:
                    case HamburgerType.RightSideCompact:
                    case HamburgerType.RightSideInLine:
                    case HamburgerType.RightSideCompactInLine:
                        {
                            if (parameter as string == "first")
                            {
                                result = 1;
                            }
                            else
                            {
                                result = 0;
                            }
                            break;
                        }
                    default:
                        break;
                }
                return result;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }

        class HamburgerTypeToColumnWidth : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                HamburgerType ht = (HamburgerType)value;
                GridLength result = new GridLength(50);
                switch (ht)
                {
                    case HamburgerType.LeftSide:
                    case HamburgerType.LeftSideCompact:
                    case HamburgerType.LeftSideInLine:
                    case HamburgerType.LeftSideCompactInLine:
                        {
                            if (parameter as string != "first")
                            {
                                result = new GridLength(1, GridUnitType.Star);
                            }
                            break;
                        }
                    case HamburgerType.RightSide:
                    case HamburgerType.RightSideCompact:
                    case HamburgerType.RightSideInLine:
                    case HamburgerType.RightSideCompactInLine:
                        {
                            if (parameter as string == "first")
                            {
                                result = new GridLength(1, GridUnitType.Star);
                            }
                            else
                            {
                                result = new GridLength(45);
                            }
                            break;
                        }
                    default:
                        break;
                }
                return result;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
    }
}
