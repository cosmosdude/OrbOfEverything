using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace OrbOfEverything.Decorator
{
    class Constants
    {
        public static Image playerOrbInBlue = Properties.Resources.img_player_blue_HQ;
        /*
        {
            get
            {
                return Properties.Resources.img_player_blue_LQ;
            }
        }  
         */

        public static Image playerOrbInPurple = Properties.Resources.img_player_purple_HQ;
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


        public static Image powerUpHealth = Properties.Resources.img_powerup_health_LQ;
    }

    class ColorConstants
    {
        public static Color blueColor = Color.FromArgb(0xff, 97, 178, 251);
        public static Color purpleColor = Color.FromArgb(0xff, 197, 104, 224);
        public static Color greenColor = Color.FromArgb(0xff, 0x41, 0xd8, 0x88);
        public static Color redColor = Color.FromArgb(0xff, 0xdf, 0x3f, 0x3f);
    }
}
