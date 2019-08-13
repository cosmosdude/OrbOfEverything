using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrbOfEverything.GameDefeatDialog
{

    public delegate void GameDefeatDialogAction();

    public partial class GameDefeatDialog : Form
    {
        public GameDefeatDialogAction OnMainMenu = () => { };
        public GameDefeatDialogAction OnPlayAgain = () => { };

        public int highestSteak = 0;
        public int score = 0;
        public int wave = 0;

        public GameDefeatDialog(int highestSteak, int score, int wave)
        {
            InitializeComponent();
            this.highestSteak = highestSteak;
            this.score = score;
            this.wave = wave;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnMainMenu != null) OnMainMenu();
            // Main Menu
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OnPlayAgain != null) OnPlayAgain();
            // Play Again
            this.Close();
        }

        private void GameDefeatDialog_Load(object sender, EventArgs e)
        {
            containerPanel.Location = new Point( (ClientSize.Width / 2) - (containerPanel.Size.Width / 2) , (ClientSize.Height /2 ) - (containerPanel.Size.Height / 2) );

            labelForScore.Text = "" + score;
            labelForHighStreak.Text = "" + highestSteak;
            labelForWaveNumber.Text = "" + wave;


        }
    }
}
