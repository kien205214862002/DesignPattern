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
    class DashLine : System.Windows.Forms.Panel
    {
        Color color = Color.Gold;
        float width = 3;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Data")]
        public Color DashColor
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
        public float DashWidth
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                Size = new Size(Size.Width, (int)width + 2);
                Invalidate();
            }
        }

        public DashLine()
        {
            Paint += (s, e) =>
            {
                Graphics gfx = e.Graphics;
                Pen p = new Pen(color, width);
                p.DashStyle = DashStyle.Dash;
                gfx.DrawLine(p, 0, 0, Size.Width, 0);
            };
        }
    }
}
