using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DewUserControls.Common.Presentation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DewUserControls.DewListSelectorPresentation
{
    namespace Types
    {
        /// <summary>
        /// List selector item
        /// </summary>
        public class DewListSelectorItem : NotifyPropertyChanged
        {
            private bool? isChecked = false;
            /// <summary>
            /// Indicate if the item is checked
            /// </summary>
            public bool? IsChecked
            {
                get
                {
                    return isChecked;
                }
                set
                {
                    isChecked = value;
                    OnPropertyChanged("IsChecked");
                }
            }
            private string text = "";
            /// <summary>
            /// The item text
            /// </summary>
            public string Text
            {
                get
                {
                    return text;
                }
                set
                {
                    text = value;
                    OnPropertyChanged("Text");
                }
            }
            private string id = "";
            /// <summary>
            /// The item id
            /// </summary>
            public string Id
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
            /// <summary>
            /// Default constructor
            /// </summary>
            public DewListSelectorItem() { }
            /// <summary>
            /// Constructor
            /// </summary>
            public DewListSelectorItem(string id, string text)
            {
                this.Text = text;
                this.Id = id;
            }
        }

    }

}
