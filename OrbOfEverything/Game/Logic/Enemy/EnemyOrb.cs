using OrbOfEverything.Game.Logic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrbOfEverything.Game.Graphics.Measurement;
using System.Drawing;
using OrbOfEverything.Decorator;
using OrbOfEverything.Engine.Animation;
using OrbOfEverything.Engine.Animation.Interpolation;

namespace OrbOfEverything.Game.Logic.Enemy
{
    class EnemyOrb : Orb
    {
        public OrbStyle Style = OrbStyle.blue;
        private CGSize playgroundSize = CGSize.Zero;

        private CGPoint previousLocation = CGPoint.Zero;
        private CGPoint destination = CGPoint.Zero;

        private OOEAnimating animator;

        // private Color color;
        private SolidBrush brush = null;

        private static TextureBrush _blueTexture = null;
        private static TextureBrush _purpleTexture = null;
        private static TextureBrush blueTexture
        {
            get
            {
                if (_blueTexture == null) _blueTexture = new TextureBrush(Constants.enemyOrbInBlue);
                return _blueTexture;
            }
        }
        private static TextureBrush purpleTexture
        {
            get
            {
                if (_purpleTexture == null) _purpleTexture = new TextureBrush(Constants.enemyOrbInBlue);
                return _purpleTexture;
            }
        }
        

        private TextureBrush characterTexture = null;

        public override void DrawIn(CGRect bounds, System.Drawing.Graphics ctx)
        {
            if (texture == null) return;

            // ctx.DrawImage(texture, frame.origin.x, frame.origin.y, frame.size.width, frame.size.height);
            ctx.DrawImageUnscaled(texture, new Rectangle((int)frame.origin.x, (int)frame.origin.y, (int)frame.size.width, (int)frame.size.height));
            // ctx.DrawImageUnscaledAndClipped(texture, new Rectangle((int)frame.origin.x, (int)frame.origin.y, (int)frame.size.width, (int)frame.size.height));
            
            
            
            // if(characterTexture == null) return;

            // ctx.FillRectangle(characterTexture, frame.origin.x, frame.origin.y, frame.size.width, frame.size.height);

            // if (brush == null) return;
            // ctx.FillEllipse(brush, frame.origin.x, frame.origin.y, frame.size.width, frame.size.height);
        }


        private static float[] durations = new float[] { 1.0f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f };
        private OOEInterpolation[] interpolations = new OOEInterpolation[] { OOEInterpolation.linear, OOEInterpolation.easeIn, OOEInterpolation.easeOut, OOEInterpolation.easeInOut };
        public void MoveRandom()
        {
            if (animator != null) return;

            float duration = 1;
            duration = durations[randomizer.Next(0, durations.Length)];

            OOEInterpolation interpolation = interpolations[randomizer.Next(0, interpolations.Length)];


            animator = new OOEValueAnimator().Duration(duration).From(0).To(1).Interpolation(interpolation);

            previousLocation = frame.origin;

            destination.x = ((float)randomizer.NextDouble() * playgroundSize.width) - frame.origin.x;
            destination.y = ((float)randomizer.NextDouble() * playgroundSize.height) - frame.origin.y;

            animator.OnValueChange = (value) =>
            {
                frame.origin.x = previousLocation.x + (destination.x * value);
                frame.origin.y = previousLocation.y + (destination.y * value);
            };
            animator.OnFinish = () => 
            {
                animator.Dispose();
                animator = null;
                MoveRandom();
            };

            animator.Start();
        }

        
        public static readonly Random randomizer = new Random();
        public static EnemyOrb Make(OrbStyle style, CGSize playgroundSize)
        {
            EnemyOrb orb = new EnemyOrb();
            orb.Style = style;
            orb.playgroundSize = playgroundSize;

            if (style == OrbStyle.blue)
            {
                // orb.color = ColorConstants.blueColor;
                orb.brush = new SolidBrush(ColorConstants.blueColor);
                orb.characterTexture = blueTexture;
                orb.texture = Constants.enemyOrbInBlue;
            }
            else
            {
                // orb.color = ColorConstants.purpleColor;
                orb.brush = new SolidBrush(ColorConstants.purpleColor);
                orb.characterTexture = purpleTexture;
                orb.texture = Constants.enemyOrbInPurple;
            }

            orb.frame.size = new CGSize(50, 50);

            orb.frame.origin.x = (float)(randomizer.NextDouble() * playgroundSize.width);
            orb.frame.origin.y = (float)(randomizer.NextDouble() * playgroundSize.height);

            orb.destination = orb.frame.origin;

            return orb;
        }


        public static EnemyOrb MakeRandom(CGSize playgroundSize)
        {
            OrbStyle style = OrbStyle.blue;
            if(randomizer.NextDouble() > 0.5)
            {
                style = OrbStyle.purple;
            }

            return Make(style, playgroundSize);
        }




        public override void Dispose()
        {
            if(animator != null)
            {
                animator.Stop();
                animator.Dispose();
            }
        }
    }
}
