using OrbOfEverything.Game.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrbOfEverything.Game.Graphics.Measurement;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Windows.Forms;

using OrbOfEverything.Decorator;
using OrbOfEverything.Engine.Animation;
using OrbOfEverything.Engine.Animation.Interpolation;

namespace OrbOfEverything.Game.Logic.Player
{

    public delegate void PlayerStatusTextOnAnimationComplete();
    public sealed class PlayerStatusText : OOEGraphicsItem
    {
        private static readonly Brush redBrush = new SolidBrush(ColorConstants.redColor);
        private static readonly Brush greenBrush = new SolidBrush(ColorConstants.greenColor);



        public PlayerStatusTextOnAnimationComplete completion = null;

        
        private CGPoint point = CGPoint.Zero;
        private Brush brush = null;
        private string content = "0";

        private Color color = Color.White;

        // private TextRenderer renderer = TextRenderer.

        private OOEAnimating animation = null;

        private static Font font = new Font(SystemFonts.CaptionFont.FontFamily, 20, FontStyle.Bold);

        public override void DrawIn(CGRect bounds, System.Drawing.Graphics ctx)
        {
            // if (brush == null) return;
            // ctx.DrawString(content, font, brush, frame.origin.x, frame.origin.y);

            if (color == null) return;
            TextRenderer.DrawText(ctx, content, font, new Point((int)frame.origin.x, (int)frame.origin.y), color);
        }

        private PlayerStatusText() { }

        public static PlayerStatusText MakeOneAt(CGPoint center, int value)
        {
            PlayerStatusText item = new PlayerStatusText();
            // item.frame.origin.x;
            item.frame.origin.x = center.x; // - 50;
            item.frame.origin.y = center.y; // - 25;
            item.point = item.frame.origin;
            item.content = "" + value;

            if (value < 0)
            {
                item.color = ColorConstants.redColor;
                item.brush = redBrush;
            }
            else
            {
                item.color = ColorConstants.greenColor;
                item.brush = greenBrush;
            }
            return item;
        }


        public void StartAnimation()
        {
            if (animation == null)
            {
                animation = new OOEValueAnimator().Duration(1.0f).From(0).To(30).Interpolation(OOEInterpolation.easeOut);
                animation.OnValueChange = (value) =>
                {
                    frame.origin.y = point.y - value;
                };
                animation.OnFinish = () => { 

                    if (completion != null) completion();

                    animation.Stop();
                    animation.Dispose();
                    animation = null;
                };
                animation.Start();
            }
        }
    }
}
