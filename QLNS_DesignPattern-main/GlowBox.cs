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
    class GlowBox : System.Windows.Forms.Panel
    {
        Color color = Color.PowderBlue;
        bool glow = false;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Data")]
        public Color GlowColor
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
        public bool GlowOn
        {
            get
            {
                return glow;
            }
            set
            {
                glow = value;
                Invalidate();
            }
        }

        public GlowBox()
        {
            Paint += (s, e) =>
            {
                if (GlowOn)
                {
                    if (Controls.Count > 0)
                    {
                        Size = new Size(Controls[0].Width + 10, Controls[0].Height + 10);
                        Controls[0].Location = new Point(5, 5);
                    }
                    int alpha = 100;
                    GraphicsPath gp = new GraphicsPath();
                    Rectangle rect = DisplayRectangle;
                    rect.Inflate(-5, -5);
                    gp.AddRectangle(rect);
                    for (int i = 1; i <= 10; i++)
                    {
                        Pen pen = new Pen(Color.FromArgb(alpha, GlowColor), i);
                        pen.LineJoin = LineJoin.Round;
                        e.Graphics.DrawPath(pen, gp);
                        alpha -= alpha / 10;
                    }
                    gp.Dispose();
                }
            };
            Layout += (s, e) =>
            {
                if (Controls.Count > 0)
                {
                    Size = new Size(Controls[0].Width + 10, Controls[0].Height + 10);
                    Controls[0].Location = new Point(5, 5);
                    Invalidate();
                }
            };
            ControlAdded += (s, e) =>
            {
                Size = new Size(Controls[0].Width + 10, Controls[0].Height + 10);
                Controls[0].Location = new Point(5, 5);
                e.Control.GotFocus += (ss, ee) =>
                {
                    if (e.Control is TextBox)
                    {
                        TextBox tb = (TextBox)e.Control;
                        if (!tb.ReadOnly)
                            GlowOn = true;
                    }
                    else
                        GlowOn = true; 
                };
                e.Control.LostFocus += (ss, ee) => { GlowOn = false; };
            };
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if(Parent != null)
                e.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), e.ClipRectangle);
        }

        /*protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }*/
    }
}
