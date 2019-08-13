using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Game.Graphics.Measurement
{
    public struct CGPoint
    {
        public float x;
        public float y;

        public CGPoint(float x, float y)
        {
            this.x = x;
            this.y = y;
        }


        public CGPoint(int x, int y)
        {
            this.x = (float)x;
            this.y = (float)y;
        }

        public static readonly CGPoint Zero = new CGPoint(0, 0);
    }
}
