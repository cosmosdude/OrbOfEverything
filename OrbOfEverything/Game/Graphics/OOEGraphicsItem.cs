using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Drawing2D;

using OrbOfEverything.Game.Graphics.Measurement;

namespace OrbOfEverything.Game.Graphics
{
    
    public abstract class OOEGraphicsItem
    {

        
        // MARK:- Graphics Item therotical frame configurations.
        public CGRect frame = new CGRect();


        /// <summary>
        /// Called when the graphics item should update its context during frame update interval.
        /// </summary>
        /// <param name="bounds">Bounds of the graphics canvas.</param>
        /// <param name="ctx">Graphics Context for drawing.</param>
        public abstract void DrawIn(CGRect bounds, System.Drawing.Graphics ctx);
        

    }
}
