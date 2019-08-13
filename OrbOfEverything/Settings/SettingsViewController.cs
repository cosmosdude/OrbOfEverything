using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrbOfEverything.Settings
{
    public partial class SettingsViewController : Form
    {

        public Form parent;

        private Point Center
        {
            get
            {
                return new Point(ClientSize.Width / 2, ClientSize.Height / 2);
            }
        }

        public SettingsViewController()
        {
            InitializeComponent();

            LayoutSubviews();
        }

        private void SettingsViewController_Load(object sender, EventArgs e)
        {

        }

        private void SettingsViewController_Resize(object sender, EventArgs e)
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
    }
}
