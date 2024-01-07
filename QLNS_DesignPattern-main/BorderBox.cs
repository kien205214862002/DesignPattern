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
    class BorderBox : System.Windows.Forms.GroupBox
    {
        Color color = Color.Gray;
        float width = 2;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Data")]
        public Color BorderColor
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Invalidate();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Data")]
        public float BorderWidth
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                Invalidate();
            }
        }

        public BorderBox()
        {
            Paint += (s, e) =>
            {
                Graphics gfx = e.Graphics;
                Pen p = new Pen(color, width);
                float text_width = gfx.MeasureString(Text, Font).Width;
                float text_height = gfx.MeasureString(Text, Font).Height/2;
                float rect_width = Size.Width - 1;
                float rect_height = Size.Height - 2;
                gfx.DrawLine(new Pen(p.Color, p.Width + 1), 0, text_height, 0, rect_height);
                gfx.DrawLine(p, 0, text_height, 9, text_height);
                gfx.DrawLine(p, text_width, text_height, rect_width, text_height);
                gfx.DrawLine(p, rect_width, text_height, rect_width, rect_height);
                gfx.DrawLine(p, 0, rect_height, rect_width, rect_height);
            };
        }
    }
}
