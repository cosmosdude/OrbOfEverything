using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OrbOfEverything.Game.Logic.Core;
using System.Drawing;

using System.Windows.Forms;

namespace OrbOfEverything.Game.Logic.Player
{

    public delegate void PlayerContextPlayerDeathEvent();
    // public delegate void PlayerContextPlayerDamageEvent();
    // public delegate void PlayerContextPlayerHealEvent();
    public delegate void PlayerContextPlayerHealthChangeEvent(int changeInHealth);

    public sealed class PlayerContext: IDisposable
    {
        // MARK:- Last Eaten orb.
        public OrbStyle LastEatenOrb = OrbStyle.none;


        // MARK:- Health Information
        public int healthPoint = 10;
        public int maxHealth = 10;

        public float HealthPercent
        {
            get
            {
                if (maxHealth == 0) { return 0; }
                return (float)healthPoint / (float)maxHealth;
            }
        }

        public PlayerContextPlayerDeathEvent OnDeath = null;
        public PlayerContextPlayerHealthChangeEvent OnHealthChange = null;
        
        public void ResetHealth()
        {
            this.healthPoint = maxHealth;
        }

        public void Injur(int hp = 1)
        {
            if (IsVulnerable == false) return;
            healthPoint -= hp;

            MakeInvulnerable();

            if (healthPoint <= 0)
            {
                healthPoint = 0;
                if (OnHealthChange != null) OnHealthChange(-hp);
                if (OnDeath != null) OnDeath();
            } else
            {
                if (OnHealthChange != null) OnHealthChange(-hp);
            }
        }

        public void Heal(int hp = 1)
        {
            if (IsHealable == false) return;
            MakeUnhealable();
            // MessageBox.Show("This is called.");
            int hpDiff = healthPoint;
            healthPoint += hp;
            if (healthPoint >= maxHealth)
            {
                healthPoint = maxHealth;
                hpDiff = healthPoint - hpDiff;

                if (hpDiff != 0 && OnHealthChange != null) OnHealthChange(hp);

            } else
            {
                if (OnHealthChange != null) OnHealthChange(hp);
            }
        }




        // MARK:- Vulnerability information
        public bool IsVulnerable = true;
        Timer vulTimer = null;
        public void MakeInvulnerable()
        {
            if (IsVulnerable == false) return;
            IsVulnerable = false;
            vulTimer = new Timer();
            vulTimer.Interval = 1000;
            vulTimer.Tick += MakeVulnerable;
            vulTimer.Start();
        }

        private void MakeVulnerable(Object sender, EventArgs e)
        {
            IsVulnerable = true;
            if (vulTimer == null) return;
            vulTimer.Stop();
            vulTimer.Dispose();
            vulTimer = null;
        }



        // MARK:- Vulnerability information
        public bool IsHealable = true;
        Timer healTimer = null;
        public void MakeUnhealable()
        {
            if (IsHealable == false) return;
            IsHealable = false;
            healTimer = new Timer();
            healTimer.Interval = 1000;
            healTimer.Tick += MakeHealable;
            healTimer.Start();
        }

        private void MakeHealable(Object sender, EventArgs e)
        {
            IsHealable = true;
            if (healTimer == null) return;
            healTimer.Stop();
            healTimer.Dispose();
            healTimer = null;
        }

        public int HighestSteak = 0;
        public int Wave = 1;
        public int Steak = 0;
        public int Score = 0;
        private int previousScore = 0;
        public int ChangeInScore = 0;

        // MARK:- Score information
        public void ResetContext()
        {
            healthPoint = maxHealth;
            Wave = 0;
            Steak = 0;
            Score = 0;
            HighestSteak = 0;
            previousScore = 0;
            ChangeInScore = 0;
        }

        public void ResetSteak()
        {
            if (Steak > HighestSteak)
            {
                HighestSteak = Steak;
            }

            Steak = 0;
        }
        public void IncreaseScore()
        {
            previousScore = Score;
            Score = Score + (10 * (Steak + 1));
            Steak += 1;

            ChangeInScore = Score - previousScore;
        }


        public void Dispose()
        {
            if(vulTimer != null)
            {
                vulTimer.Stop();
                vulTimer.Dispose();
                vulTimer = null;
            }
        }
    }
}
