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
using OrbOfEverything.Game.Logic.PowerUp;

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
            
            AddStatusText(new CGPoint(player.frame.origin.x, player.frame.origin.y - player.frame.size.height), count);
        }

        private void AddStatusText(CGPoint point, int value)
        {
            PlayerStatusText st = PlayerStatusText.MakeOneAt(point, value);
            st.StartAnimation();
            graphicsItems.Add(st);
            st.completion = () =>
            {
                graphicsItems.Remove(st);
            };
        }
        
        GameDefeatDialog.GameDefeatDialog dialog = null;

        private void OnPlayerDeath()
        {
            if (dialog != null) return;
            OOEEngine.Shared.Remove(this, OOEEngineObserverType.graphics);


            // MessageBox.Show("You are dead.");
            // OOEEngine.Shared.IsPaused = true;
            // ClearWave();
            this.Hide();
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
            StartNextWaveCountDown();
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

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            OOEEngine.Shared.FPS = 30;

            playerContext.maxHealth = 5;
            playerContext.healthPoint = playerContext.maxHealth;


            player.SetDefaultOrbStyle();
            player.frame.size = new CGSize(50, 50);

            

            playerContext.OnHealthChange = OnPlayerHealthChange;
            playerContext.OnDeath = OnPlayerDeath;

            powerupSpawnTimer = new Timer();
            powerupSpawnTimer.Interval = 15 * 1000;
            powerupSpawnTimer.Tick += PowerUpSpawnTick;
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

            powerupSpawnTimer.Start();

            // animator.Start();
            // playerOrb.BackgroundImage = playerContext.GetOrbImage();
            player.RelativeDiagonalTimeLine = (float)Math.Sqrt(Math.Pow(ClientSize.Width, 2) + Math.Pow(ClientSize.Height, 2));
            OOEEngine.Shared.Add(this, type: OOEEngineObserverType.graphics);

            panelForCountDown.Location = new Point((ClientSize.Width / 2) - (panelForCountDown.Size.Width / 2), (ClientSize.Height / 2) - (panelForCountDown.Size.Height / 2));
            panelForCountDown.Hide();
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
            if (countDownTimer != null)
            {
                countDownTimer.Stop();
                countDownTimer.Dispose();
                countDownTimer = null;
            }

            if (powerupSpawnTimer != null)
            {
                powerupSpawnTimer.Stop();
                powerupSpawnTimer.Dispose();
                powerupSpawnTimer = null;
            }

            playerContext.Dispose();

            this.Dispose();
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

            int orbCount = 0;

            List<OOEGraphicsItem> graphicsItems = new List<OOEGraphicsItem>(this.graphicsItems);
            foreach (OOEGraphicsItem item in graphicsItems)
            {
                
                if (item is PowerUp)
                {
                    PowerUp targetPowerUp = item as PowerUp;
                    if (targetPowerUp == healthPowerup)
                    {
                        if (player.IsInCollisionRangeOf(targetPowerUp))
                        {
                            playerContext.Heal();

                            this.graphicsItems.Remove(targetPowerUp);
                            healthPowerup = null;
                        }
                    }
                }

                if (item is EnemyOrb)
                {
                    EnemyOrb enemy = item as EnemyOrb;
                    orbCount += 1;
                    /*
                    float x = player.frame.origin.x - enemy.frame.origin.x;
                    float y = player.frame.origin.y - enemy.frame.origin.y;
                    float rPlayer = player.frame.size.width / 2;
                    float rEnemy = player.frame.size.width / 2;
                    */
                    
                    if (player.IsInCollisionRangeOf(enemy) /*Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(rPlayer+rEnemy,2)*/)
                    {
                        
                        if (enemy.Style != player.Style)
                        {
                            // Decrease Health
                            playerContext.Injur();
                            playerContext.ResetSteak();

                            player.DecreaseSize();
                            playerContext.LastEatenOrb = Game.Logic.Core.OrbStyle.none;
                        } else
                        {
                            orbCount -= 1;
                            enemy.Dispose();
                            this.graphicsItems.Remove(enemy);
                            playerContext.IncreaseScore();

                            AddStatusText(new CGPoint(player.frame.origin.x, player.frame.origin.y - player.frame.size.height), playerContext.ChangeInScore);


                            if (playerContext.LastEatenOrb == enemy.Style)
                            {
                                player.IncreaseSize();
                            }
                            else
                            {
                                player.DecreaseSize();
                                playerContext.LastEatenOrb = enemy.Style;
                            }

                            
                        }

                        OnOrbCollision();
                        
                    }
                }
                item.DrawIn(bounds, gctx);
            }
            player.DrawIn(bounds, gctx);

            
            if (orbCount == 0)
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






        private int countDownCount = 2;
        private Timer countDownTimer = null;
        private void CountDownTick(object t, EventArgs e)
        {
            if (countDownCount == 0)
            {
                if (countDownTimer != null)
                {
                    countDownCount = 2;
                    labelForCountDown.Text = "3";
                    panelForCountDown.Hide();
                    countDownTimer.Stop();
                    countDownTimer.Dispose();
                    countDownTimer = null;

                    playerContext.Wave += 1;
                    MakeWaveOfEnemies();
                    labelForWaveNumber.Text = "" + playerContext.Wave;
                }
            } else
            {
                countDownCount -= 1;
                labelForCountDown.Text = "" + (countDownCount + 1);
            }
        }

        private void StartNextWaveCountDown()
        {
            if (countDownTimer != null) return;
            panelForCountDown.Show();
            countDownTimer = new Timer();
            countDownTimer.Tick += CountDownTick;
            countDownTimer.Interval = 1000;
            countDownTimer.Start();
        }







        private Timer powerupSpawnTimer = null;
        private PowerUp healthPowerup = null;
        private Random powerUpRandomizer = new Random();
        private void PowerUpSpawnTick(object sender, EventArgs e)
        {
            
            if (healthPowerup == null)
            {
                double randValue = powerUpRandomizer.NextDouble();
                if (randValue < (1 - 0.5)) return;

                healthPowerup = new HealthPowerUp();
                healthPowerup.frame.size = new CGSize(50, 50);
                graphicsItems.Add(healthPowerup);

                // MessageBox.Show("Frame is +", healthPowerup.frame.origin.x + ", " + healthPowerup.frame.origin.y );
            }

            healthPowerup.frame.origin.x = powerUpRandomizer.Next(0, ClientSize.Width - 50);
            healthPowerup.frame.origin.y = powerUpRandomizer.Next(0, ClientSize.Height - 50);
        }
    }
}
