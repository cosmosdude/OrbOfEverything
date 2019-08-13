using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Game.Graphics.Measurement
{
    public struct CGSize
    {
        public float width;
        public float height;

        public CGSize(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public CGSize(int width, int height): this((float)width, (float)height)
        { }
        
        public static readonly CGSize Zero = new CGSize(0, 0);
    }
}
