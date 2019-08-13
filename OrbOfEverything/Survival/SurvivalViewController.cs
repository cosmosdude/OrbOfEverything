using OrbOfEverything.Engine;
using OrbOfEverything.Engine.Animation;
using OrbOfEverything.Engine.Animation.Interpolation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

using OrbOfEverything.Game.Graphics;
using OrbOfEverything.Game.Graphics.Measurement;
using OrbOfEverything.Game.Logic.Player;
using OrbOfEverything.Decorator;
using OrbOfEverything.Game.Logic.Enemy;

using OrbOfEverything.GameDefeatDialog;

namespace OrbOfEverything.Survival
{
    public partial class SurvivalViewController : Form, OOEEngineObserving
    {
        private List<OOEGraphicsItem> graphicsItems = new List<OOEGraphicsItem>();

        // MARK:- Player Information
        private PlayerContext playerContext = new PlayerContext();
        private PlayerOrb player = new PlayerOrb();

        private void OnPlayerHealthChange(int count)
        {
            playerHealth.Size = new Size( (int)(playerContext.HealthPercent * 150) , 30);
            labelForHealthNumber.Text = "" + playerContext.healthPoint;
        }

        GameDefeatDialog.GameDefeatDialog dialog = null;

        private void OnPlayerDeath()
        {
            if (dialog != null) return;
            OOEEngine.Shared.Remove(this, OOEEngineObserverType.graphics);


            // MessageBox.Show("You are dead.");
            // OOEEngine.Shared.IsPaused = true;
            // ClearWave();

            dialog = new GameDefeatDialog.GameDefeatDialog(playerContext.HighestSteak, playerContext.Score, playerContext.Wave);
            dialog.OnPlayAgain = () =>
            {
                OOEEngine.Shared.Clear();
                SurvivalViewController vc = new SurvivalViewController();
                vc.parentViewController = parentViewController;
                vc.Show();
                this.Close();
            };
            dialog.OnMainMenu = () =>
            {

                this.Close();

                this.parentViewController.Show();
            };
            

            Point location = new Point();
            location.X = (Screen.PrimaryScreen.Bounds.Size.Width / 2) - (dialog.ClientSize.Width / 2);
            location.Y = (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (dialog.ClientSize.Width / 2);
            dialog.Location = location;

            dialog.ShowDialog();
        }

        private void OnPlayerWin()
        {
            playerContext.Wave += 1;
            MakeWaveOfEnemies();
            labelForWaveNumber.Text = "" + playerContext.Wave;
        }

        private void MovePlayerToCenter()
        {
            CGPoint p = new CGPoint();
            p.x = (ClientSize.Width / 2);// - (player.frame.size.width / 2);
            p.y = (ClientSize.Height / 2);// - (player.frame.size.height / 2);
            player.frame.origin = p;

            // MessageBox.Show("width:" + ClientSize.Width + " height:" + ClientSize.Height + " x,y: " + p.x + ", " + p.y );
        }


        // MARK:- Enemy Information
        private void MakeWaveOfEnemies()
        {
            int wave = this.playerContext.Wave;
            if (wave > 10)
            {
                wave = 10;
            }
            for (int i = 0; i < wave; i++)
            {
                EnemyOrb orb = EnemyOrb.MakeRandom(//Game.Logic.Core.OrbStyle.blue ,
                    new CGSize(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                graphicsItems.Add(orb);
                orb.MoveRandom();

                /*
                orb = EnemyOrb.Make(Game.Logic.Core.OrbStyle.purple,
                    new CGSize(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                graphicsItems.Add(orb);
                orb.MoveRandom();
                */
            }
        }

        // private bool IsCleaning = false;
        private void ClearWave()
        {
            // IsCleaning = true;
            List<OOEGraphicsItem> items = new List<OOEGraphicsItem>(graphicsItems);
            foreach (OOEGraphicsItem item in items)
            {
                (item as EnemyOrb).Dispose();
                graphicsItems.Remove(item);
            }
            // graphicsItems.Clear();
            // IsCleaning = false;
        }


        private void ResetGameState()
        {
            playerContext.ResetContext();
            OnPlayerHealthChange(0);
            MovePlayerToCenter();
            OnOrbCollision();
            labelForWaveNumber.Text = "" + playerContext.Wave;
            // OOEEngine.Shared.IsPaused = false;

            OOEEngine.Shared.Add(this, OOEEngineObserverType.graphics);
        }

        private void OnOrbCollision()
        {
            labelForScore.Text = "" + playerContext.Score;
            labelForSteakNumber.Text = "" + playerContext.Steak;


        }




        // MARK:- Form
        public Form parentViewController;
        
        public SurvivalViewController()
        {
            DoubleBuffered = true;
            InitializeComponent();


            // this.graphicsItems.Add(player);

            OOEEngine.Shared.FPS = 30;

            playerContext.maxHealth = 5;
            playerContext.healthPoint = playerContext.maxHealth;


            player.SetDefaultOrbStyle();
            player.frame.size = new CGSize(50, 50);

            

            playerContext.OnHealthChange = OnPlayerHealthChange;
            playerContext.OnDeath = OnPlayerDeath;
        }

        private void SurvivalViewController_Load(object sender, EventArgs e)
        {
            labelForHealthNumber.Text = "" + playerContext.healthPoint;

            MakeWaveOfEnemies();

            Point loc = new Point();
            loc.X = ClientSize.Width - (panelForStats.Width + playerHealth.Location.X);
            loc.Y = playerHealth.Location.Y;
            panelForStats.Location = loc;

            MovePlayerToCenter();

            // animator.Start();
            // playerOrb.BackgroundImage = playerContext.GetOrbImage();
            player.RelativeDiagonalTimeLine = (float)Math.Sqrt(Math.Pow(ClientSize.Width, 2) + Math.Pow(ClientSize.Height, 2));
            OOEEngine.Shared.Add(this, type: OOEEngineObserverType.graphics);
        }

        private void SurvivalViewController_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                
                if (parentViewController != null)
                {
                    parentViewController.Show();
                }
                this.Close();
            }
        }

        
        private void SurvivalViewController_FormClosed(object sender, FormClosedEventArgs e)
        {
            OOEEngine.Shared.Remove(this, type: OOEEngineObserverType.graphics);
        }

        
        private void SurvivalViewController_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                player.ChangeOrbStyle();
                // playerOrb
                return;
            }

            if (player.CanMove)
            {
                player.MoveTo(new CGPoint(e.Location.X, e.Location.Y));
            }
        }




        private bool IsGraphicsQualitySet = false;
        private void SurvivalViewController_Paint(object sender, PaintEventArgs e)
        {
            Graphics gctx = e.Graphics;
            if (IsGraphicsQualitySet == false)
            {
                IsGraphicsQualitySet = true;

                gctx.CompositingQuality = CompositingQuality.HighSpeed;
                gctx.PixelOffsetMode = PixelOffsetMode.None;
                gctx.SmoothingMode = SmoothingMode.None;
                gctx.InterpolationMode = InterpolationMode.Default;
            }
            
            
            

            gctx.Clear(Color.White);

            CGRect bounds = new CGRect(0, 0, ClientSize.Width, ClientSize.Height);

            List<OOEGraphicsItem> graphicsItems = new List<OOEGraphicsItem>(this.graphicsItems);
            foreach (OOEGraphicsItem item in graphicsItems)
            {
                if (item is EnemyOrb)
                {
                    EnemyOrb enemy = item as EnemyOrb;

                    float x = player.frame.origin.x - enemy.frame.origin.x;
                    float y = player.frame.origin.y - enemy.frame.origin.y;
                    float rPlayer = player.frame.size.width / 2;
                    float rEnemy = player.frame.size.width / 2;

                    if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(rPlayer+rEnemy,2))
                    {
                        if (enemy.Style != player.Style)
                        {
                            // Decrease Health
                            playerContext.Injur();
                            playerContext.ResetSteak();
                        } else
                        {
                            enemy.Dispose();
                            this.graphicsItems.Remove(enemy);
                            playerContext.IncreaseScore();
                        }

                        OnOrbCollision();
                        
                    }
                }
                item.DrawIn(bounds, gctx);
            }
            player.DrawIn(bounds, gctx);

            if (graphicsItems.Count == 0)
            {
                OnPlayerWin();
            }
        }







        // MARK:- Graphics Object Painting Implementation
        private bool _IsPaused = false;
        public bool IsPaused { get { return _IsPaused; } set { _IsPaused = value; } }
        public void FPSChanged(OOEEngine sender)
        {
            // Does not care about FPS change.
        }

        public void FixedUpdate()
        {
            this.Invalidate();
        }
    }
}
