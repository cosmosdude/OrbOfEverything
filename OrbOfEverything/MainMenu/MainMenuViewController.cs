using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OrbOfEverything.Decorator;
using OrbOfEverything.Survival;

using OrbOfEverything.Engine.Animation;
using OrbOfEverything.Engine.Animation.Interpolation;

namespace OrbOfEverything
{
    public partial class MainMenuViewController : Form
    {
        public MainMenuViewController()
        {
            DoubleBuffered = true;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private Point Center {
            get {
                return new Point(ClientSize.Width / 2, ClientSize.Height / 2);
            }
        }

        private void MainMenuViewController_Load(object sender, EventArgs e)
        {
            /*
            Gameplay.GameplayViewController vc = new Gameplay.GameplayViewController();
            vc.parent = this;
            vc.Show();
            this.Hide();
            */
            // BasicDecorator.clearFlatBackColor(buttonForPlay);
            // BasicDecorator.clearFlatBackColor(buttonForSurvival);
            // BasicDecorator.clearFlatBackColor(buttonForQuit);


            LayoutSubviews();

            // MakeForwardAnimator();
        }

        private void MainMenuViewController_Resize(object sender, EventArgs e)
        {
            LayoutSubviews();
            gradientView.Invalidate();
        }

        private void LayoutSubviews()
        {
            gradientView.Size = this.ClientSize;
            gradientView.Location = Point.Empty;

            contentContainer.Location = new Point(Center.X - (contentContainer.Size.Width / 2), Center.Y - (contentContainer.Size.Height / 2));
        }

        private void buttonForPlay_Click(object sender, EventArgs e)
        {

        }

        private void buttonForSurvival_Click(object sender, EventArgs e)
        {
            SurvivalViewController vc = new SurvivalViewController();
            vc.parentViewController = this;
            vc.Show();
            this.Hide();

            
        }

        
        private void buttonForQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }







        private OOEAnimating bgAnimator = null;
        
        private void MakeForwardAnimator()
        {
            bgAnimator = new OOEValueAnimator().Duration(3).From(0x51ff94).To(0xffd941).Interpolation(OOEInterpolation.easeInOut);
            bgAnimator.OnValueChange = (value) =>
            {
                var color = (int)value;
                this.gradientView.BackColor = Color.FromArgb(0xff, 
                    (color >> 16) & 0xff,
                    (color >> 8) & 0xff,
                    color & 0xff);
                Console.WriteLine("Color is" + color);
            };
            bgAnimator.Start();
            bgAnimator.OnFinish = () =>
            {
                bgAnimator.Dispose();
                MakeBackwardAnimator();
            };

            Console.WriteLine("This method is called");
        }

        private void MakeBackwardAnimator()
        {
            bgAnimator = new OOEValueAnimator().Duration(3).To(0x51ff94).From(0xffd941).Interpolation(OOEInterpolation.easeInOut);
            bgAnimator.OnValueChange = (value) =>
            {
                var color = (int)value;
                this.gradientView.BackColor = Color.FromArgb(0xff,
                    (color >> 16) & 0xff,
                    (color >> 8) & 0xff,
                    color & 0xff);
            };
            bgAnimator.Start();
            bgAnimator.OnFinish = () =>
            {
                bgAnimator.Dispose();
                MakeForwardAnimator();
            };
        }
    }
}
