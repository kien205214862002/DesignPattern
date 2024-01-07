using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace CNPM
{
    class NumberInput : System.Windows.Forms.TextBox
    {
        public NumberInput()
        {
            Margin = new Padding(0);
            KeyPress += (s, e) =>
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                    e.Handled = true;
            };
        }
    }
}
