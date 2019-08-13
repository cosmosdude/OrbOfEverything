using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace OrbOfEverything.Decorator
{
    class Constants
    {
        public static Image playerOrbInBlue = new Bitmap(Properties.Resources.img_player_blue_LQ, new Size(50, 50));
        /*
        {
            get
            {
                return Properties.Resources.img_player_blue_LQ;
            }
        }  
         */

        public static Image playerOrbInPurple  = new Bitmap(Properties.Resources.img_player_purple_LQ, new Size(50, 50));
        /*    
        {
            get
            {
                return Properties.Resources.img_player_purple_LQ;
            }
        }
        */


        public static Image enemyOrbInBlue
        {
            get
            {
                return Properties.Resources.img_enemy_blue_LQ;
            }
        }
        public static Image enemyOrbInPurple
        {
            get
            {
                return Properties.Resources.img_enemy_purple_LQ;
            }
        }
    }

    class ColorConstants
    {
        public static Color blueColor = Color.FromArgb(0xff, 97, 178, 251);
        public static Color purpleColor = Color.FromArgb(0xff, 197, 104, 224);
    }
}
