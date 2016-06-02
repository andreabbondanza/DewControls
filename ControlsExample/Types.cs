using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlsExample
{
    class MainMenuItem
    {
        private string glyph;

        public string Glyph
        {
            get { return glyph; }
            set { glyph = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public MainMenuItem(string text, string glyph = null)
        {
            Glyph = glyph;
            Text = text;
        }

    }
}
