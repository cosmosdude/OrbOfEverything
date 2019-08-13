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
    }
}
