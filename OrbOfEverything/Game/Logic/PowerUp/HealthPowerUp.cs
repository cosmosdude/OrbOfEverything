using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using OrbOfEverything.Game.Graphics.Measurement;
using OrbOfEverything.Decorator;

namespace OrbOfEverything.Game.Logic.PowerUp
{
    public sealed class HealthPowerUp : PowerUp
    {
        public HealthPowerUp()
        {
            texture = Constants.powerUpHealth;
        }
        public override void DrawIn(CGRect bounds, System.Drawing.Graphics ctx)
        {
            ctx.DrawImageUnscaled(texture, (int)frame.origin.x, (int)frame.origin.y, (int) frame.size.width, (int)frame.size.height);
        }
    }
}
