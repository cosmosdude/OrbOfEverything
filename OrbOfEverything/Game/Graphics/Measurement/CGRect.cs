using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Game.Graphics.Measurement
{
    public struct CGRect
    {
        public CGPoint origin;
        public CGSize size;

        public CGRect(CGPoint origin, CGSize size)
        {
            this.origin = origin;
            this.size = size;
        }
        public CGRect(float x, float y, float width, float height): this(new CGPoint(x, y), new CGSize(width, height))
        { }

        public CGRect(int x, int y, int width, int height) : this(new CGPoint(x, y), new CGSize(width, height)) { }
    }
}
