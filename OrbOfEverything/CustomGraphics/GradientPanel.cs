using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OrbOfEverything.CustomGraphics
{
    class GradientPanel: Panel
    {

        public Color startColor { get; set; }// = new Color();
        public Color endColor { get; set; }// = new Color();
        

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush gradient = new LinearGradientBrush(this.ClientRectangle, startColor, endColor, 90f);
            e.Graphics.FillRectangle(gradient, this.ClientRectangle);
            base.OnPaint(e);
        }

    }
}
