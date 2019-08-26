using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Drawing2D;

using OrbOfEverything.Decorator;

using OrbOfEverything.Engine.Animation;
using OrbOfEverything.Engine.Animation.Interpolation;

using OrbOfEverything.Game.Graphics;
using OrbOfEverything.Game.Graphics.Measurement;

using OrbOfEverything.Game.Logic.Core;
using System.Windows.Forms;

namespace OrbOfEverything.Game.Logic.Player
{
    class PlayerOrb : Orb
    {

        private float targetDuration = 1.0f;

        public PlayerOrb()
        {
            texture = Constants.playerOrbInBlue;
        }

        public override void DrawIn(CGRect bounds, System.Drawing.Graphics ctx)
        {
            if (texture == null) return;

            ctx.DrawImage(texture, (int)frame.origin.x, (int)frame.origin.y, (int)frame.size.width, (int)frame.size.height);
        }




        // MARK:- Color Information
        public OrbStyle Style = OrbStyle.blue;

        public void ChangeOrbStyle()
        {
            if (Style == OrbStyle.blue)
            {
                Style = OrbStyle.purple;
                texture = Constants.playerOrbInPurple;
            }
            else
            {
                Style = OrbStyle.blue;
                texture = Constants.playerOrbInBlue;
            }
        }

        public void SetDefaultOrbStyle ()
        {
            Style = OrbStyle.purple;
            ChangeOrbStyle();
        }
        

        private OOEAnimating playerOrbAnimator = null;
        private float playerStartX = 0;
        private float playerStartY = 0;
        private float playerTotalX = 1;
        private float playerTotalY = 1;

        public float RelativeDiagonalTimeLine = 1;


        public bool CanMove = true;
        public void MoveTo(CGPoint point)
        {
            if (CanMove == false) return;
            CanMove = false;

            playerStartX = this.frame.origin.x;
            playerStartY = this.frame.origin.y;

            float x = point.x;
            float y = point.y;

            x -= this.frame.size.width / 2;
            y -= this.frame.size.height / 2;

            playerTotalX = x - playerStartX;
            playerTotalY = y - playerStartY;


            float duration = targetDuration;
            // float rd_2 = 1;
            float d_2 = 1;
            if (RelativeDiagonalTimeLine != 0)
            {
                // rd_2 = (float)Math.Sqrt(Math.Pow(RelativeDiagonalTimeLine, 2));
                d_2 = (float)Math.Sqrt((Math.Pow(playerTotalX, 2) + Math.Pow(playerTotalY, 2)));

                duration = targetDuration * (d_2 / RelativeDiagonalTimeLine);
                if (duration > targetDuration)
                {
                    duration = targetDuration;
                }
            }

            /*
            MessageBox.Show("Relative : " + RelativeDiagonalTimeLine + 
                "\nrd_2 : " + rd_2 +
                "\nd_2 : " + d_2 +
                "\npercent : " + d_2 / rd_2 +
                "\nduration:" + duration);
            */


            playerOrbAnimator = new OOEValueAnimator().From(0).To(1.0f).Duration(duration).Interpolation(OOEInterpolation.linear);
            playerOrbAnimator.OnValueChange = (value) =>
            {
                int cx = (int)(((float)playerTotalX * value) + playerStartX);
                int cy = (int)(((float)playerTotalY * value) + playerStartY);
                // playerOrb.Location = new Point(cx, cy);
                this.frame.origin.x = cx;
                this.frame.origin.y = cy;
                // playerOrb.Update();
                // this.Invalidate();
            };

            playerOrbAnimator.OnFinish = () => {
                CanMove = true;
                playerOrbAnimator.Dispose();
                playerOrbAnimator = null;
            };

            playerOrbAnimator.Start();
        }



        public override void Dispose()
        {
            if(playerOrbAnimator != null)
            {
                playerOrbAnimator.Stop();
                playerOrbAnimator.Dispose();
                playerOrbAnimator = null;
            }
        }

        

        public void IncreaseSize()
        {
            // MessageBox.Show("Increased");
            // if (frame.size.width >= 100) return;

            int incLen = 10;
            int incLen_2 = incLen / 2;

            playerStartX -= incLen_2;
            frame.size.width += incLen;
            playerTotalX -= incLen_2;

            playerStartY -= incLen_2;
            frame.size.height += incLen;
            playerTotalY -= incLen_2;
        }
        public void DecreaseSize()
        {
            if (frame.size.width <= 50)
            {
                frame.size.width = 50;
                frame.size.height = 50;
                return;
            }
            int incLen = 10;
            int incLen_2 = incLen / 2;

            playerStartX += incLen_2;
            frame.size.width -= incLen;
            playerTotalX += incLen_2;

            playerStartY += incLen_2;
            frame.size.height -= incLen;
            playerTotalY += incLen_2;
        }
    }
}
