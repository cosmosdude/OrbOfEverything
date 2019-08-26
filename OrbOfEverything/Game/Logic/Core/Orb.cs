using OrbOfEverything.Game.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbOfEverything.Game.Logic.Core
{
    public abstract class Orb: OOEGraphicsItem, IDisposable
    {
        public System.Drawing.Image texture;

        public abstract void Dispose();

        public bool IsInCollisionRangeOf(Orb anotherOrb)
        {
            float x = frame.origin.x - anotherOrb.frame.origin.x;
            float y = frame.origin.y - anotherOrb.frame.origin.y;
            float rPlayer = frame.size.width / 2;
            float rEnemy = frame.size.width / 2;

            return (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(rPlayer + rEnemy, 2));
        }

        public bool IsInCollisionRangeOf(OOEGraphicsItem anotherOrb)
        {
            float x = frame.origin.x - anotherOrb.frame.origin.x;
            float y = frame.origin.y - anotherOrb.frame.origin.y;
            float rPlayer = frame.size.width / 2;
            float rEnemy = frame.size.width / 2;

            return (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(rPlayer + rEnemy, 2));
        }
    }
}
