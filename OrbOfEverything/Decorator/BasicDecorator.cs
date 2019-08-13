using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace OrbOfEverything.Decorator
{
    class BasicDecorator
    {
        public static void clearFlatBackColor(Button btn)
        {
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }
    }
}
