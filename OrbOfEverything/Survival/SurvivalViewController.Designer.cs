namespace OrbOfEverything.Survival
{
    partial class SurvivalViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurvivalViewController));
            this.playerHealth = new System.Windows.Forms.Panel();
            this.heartBox4 = new System.Windows.Forms.PictureBox();
            this.heartBox5 = new System.Windows.Forms.PictureBox();
            this.heartBox1 = new System.Windows.Forms.PictureBox();
            this.heartBox2 = new System.Windows.Forms.PictureBox();
            this.heartBox3 = new System.Windows.Forms.PictureBox();
            this.labelForHealthTitle = new System.Windows.Forms.Label();
            this.labelForHealthNumber = new System.Windows.Forms.Label();
            this.panelForStats = new System.Windows.Forms.Panel();
            this.labelForScore = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelForSteakNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelForWaveNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelForCountDown = new System.Windows.Forms.Panel();
            this.labelForCountDown = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.playerHealth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox3)).BeginInit();
            this.panelForStats.SuspendLayout();
            this.panelForCountDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerHealth
            // 
            this.playerHealth.Controls.Add(this.heartBox4);
            this.playerHealth.Controls.Add(this.heartBox5);
            this.playerHealth.Controls.Add(this.heartBox1);
            this.playerHealth.Controls.Add(this.heartBox2);
            this.playerHealth.Controls.Add(this.heartBox3);
            this.playerHealth.Enabled = false;
            this.playerHealth.Location = new System.Drawing.Point(12, 12);
            this.playerHealth.Name = "playerHealth";
            this.playerHealth.Size = new System.Drawing.Size(150, 36);
            this.playerHealth.TabIndex = 7;
            // 
            // heartBox4
            // 
            this.heartBox4.BackColor = System.Drawing.Color.Transparent;
            this.heartBox4.BackgroundImage = global::OrbOfEverything.Properties.Resources.img_health_full_MQ;
            this.heartBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heartBox4.Location = new System.Drawing.Point(91, 1);
            this.heartBox4.Name = "heartBox4";
            this.heartBox4.Size = new System.Drawing.Size(30, 30);
            this.heartBox4.TabIndex = 4;
            this.heartBox4.TabStop = false;
            // 
            // heartBox5
            // 
            this.heartBox5.BackColor = System.Drawing.Color.Transparent;
            this.heartBox5.BackgroundImage = global::OrbOfEverything.Properties.Resources.img_health_full_MQ;
            this.heartBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heartBox5.Location = new System.Drawing.Point(121, 1);
            this.heartBox5.Name = "heartBox5";
            this.heartBox5.Size = new System.Drawing.Size(30, 30);
            this.heartBox5.TabIndex = 5;
            this.heartBox5.TabStop = false;
            // 
            // heartBox1
            // 
            this.heartBox1.BackColor = System.Drawing.Color.Transparent;
            this.heartBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("heartBox1.BackgroundImage")));
            this.heartBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heartBox1.Location = new System.Drawing.Point(1, 1);
            this.heartBox1.Name = "heartBox1";
            this.heartBox1.Size = new System.Drawing.Size(30, 30);
            this.heartBox1.TabIndex = 1;
            this.heartBox1.TabStop = false;
            // 
            // heartBox2
            // 
            this.heartBox2.BackColor = System.Drawing.Color.Transparent;
            this.heartBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("heartBox2.BackgroundImage")));
            this.heartBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heartBox2.Location = new System.Drawing.Point(31, 1);
            this.heartBox2.Name = "heartBox2";
            this.heartBox2.Size = new System.Drawing.Size(30, 30);
            this.heartBox2.TabIndex = 2;
            this.heartBox2.TabStop = false;
            // 
            // heartBox3
            // 
            this.heartBox3.BackColor = System.Drawing.Color.Transparent;
            this.heartBox3.BackgroundImage = global::OrbOfEverything.Properties.Resources.img_health_full_LQ;
            this.heartBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heartBox3.Location = new System.Drawing.Point(61, 1);
            this.heartBox3.Name = "heartBox3";
            this.heartBox3.Size = new System.Drawing.Size(30, 30);
            this.heartBox3.TabIndex = 3;
            this.heartBox3.TabStop = false;
            // 
            // labelForHealthTitle
            // 
            this.labelForHealthTitle.AutoSize = true;
            this.labelForHealthTitle.Enabled = false;
            this.labelForHealthTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForHealthTitle.ForeColor = System.Drawing.Color.Red;
            this.labelForHealthTitle.Location = new System.Drawing.Point(10, 46);
            this.labelForHealthTitle.Name = "labelForHealthTitle";
            this.labelForHealthTitle.Size = new System.Drawing.Size(47, 16);
            this.labelForHealthTitle.TabIndex = 8;
            this.labelForHealthTitle.Text = "Health";
            // 
            // labelForHealthNumber
            // 
            this.labelForHealthNumber.Enabled = false;
            this.labelForHealthNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForHealthNumber.ForeColor = System.Drawing.Color.Red;
            this.labelForHealthNumber.Location = new System.Drawing.Point(95, 46);
            this.labelForHealthNumber.Name = "labelForHealthNumber";
            this.labelForHealthNumber.Size = new System.Drawing.Size(67, 16);
            this.labelForHealthNumber.TabIndex = 9;
            this.labelForHealthNumber.Text = "10";
            this.labelForHealthNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelForStats
            // 
            this.panelForStats.Controls.Add(this.labelForScore);
            this.panelForStats.Controls.Add(this.label5);
            this.panelForStats.Controls.Add(this.labelForSteakNumber);
            this.panelForStats.Controls.Add(this.label3);
            this.panelForStats.Controls.Add(this.labelForWaveNumber);
            this.panelForStats.Controls.Add(this.label1);
            this.panelForStats.Enabled = false;
            this.panelForStats.Location = new System.Drawing.Point(590, 12);
            this.panelForStats.Name = "panelForStats";
            this.panelForStats.Size = new System.Drawing.Size(150, 68);
            this.panelForStats.TabIndex = 8;
            // 
            // labelForScore
            // 
            this.labelForScore.Enabled = false;
            this.labelForScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForScore.ForeColor = System.Drawing.Color.Red;
            this.labelForScore.Location = new System.Drawing.Point(50, 46);
            this.labelForScore.Name = "labelForScore";
            this.labelForScore.Size = new System.Drawing.Size(91, 13);
            this.labelForScore.TabIndex = 14;
            this.labelForScore.Text = "0";
            this.labelForScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(7, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Score";
            // 
            // labelForSteakNumber
            // 
            this.labelForSteakNumber.Enabled = false;
            this.labelForSteakNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForSteakNumber.ForeColor = System.Drawing.Color.Red;
            this.labelForSteakNumber.Location = new System.Drawing.Point(56, 26);
            this.labelForSteakNumber.Name = "labelForSteakNumber";
            this.labelForSteakNumber.Size = new System.Drawing.Size(85, 16);
            this.labelForSteakNumber.TabIndex = 12;
            this.labelForSteakNumber.Text = "0";
            this.labelForSteakNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(7, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Steak";
            // 
            // labelForWaveNumber
            // 
            this.labelForWaveNumber.Enabled = false;
            this.labelForWaveNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForWaveNumber.ForeColor = System.Drawing.Color.Red;
            this.labelForWaveNumber.Location = new System.Drawing.Point(57, 7);
            this.labelForWaveNumber.Name = "labelForWaveNumber";
            this.labelForWaveNumber.Size = new System.Drawing.Size(84, 16);
            this.labelForWaveNumber.TabIndex = 10;
            this.labelForWaveNumber.Text = "1";
            this.labelForWaveNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wave";
            // 
            // panelForCountDown
            // 
            this.panelForCountDown.Controls.Add(this.label4);
            this.panelForCountDown.Controls.Add(this.labelForCountDown);
            this.panelForCountDown.Enabled = false;
            this.panelForCountDown.Location = new System.Drawing.Point(378, 219);
            this.panelForCountDown.Name = "panelForCountDown";
            this.panelForCountDown.Size = new System.Drawing.Size(94, 49);
            this.panelForCountDown.TabIndex = 10;
            // 
            // labelForCountDown
            // 
            this.labelForCountDown.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForCountDown.Location = new System.Drawing.Point(24, 16);
            this.labelForCountDown.Name = "labelForCountDown";
            this.labelForCountDown.Size = new System.Drawing.Size(50, 33);
            this.labelForCountDown.TabIndex = 0;
            this.labelForCountDown.Text = "3";
            this.labelForCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Next Wave In";
            // 
            // SurvivalViewController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 510);
            this.Controls.Add(this.panelForCountDown);
            this.Controls.Add(this.panelForStats);
            this.Controls.Add(this.labelForHealthNumber);
            this.Controls.Add(this.labelForHealthTitle);
            this.Controls.Add(this.playerHealth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SurvivalViewController";
            this.Text = "Orb of Everything";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SurvivalViewController_FormClosed);
            this.Load += new System.EventHandler(this.SurvivalViewController_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SurvivalViewController_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SurvivalViewController_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SurvivalViewController_MouseClick);
            this.playerHealth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heartBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartBox3)).EndInit();
            this.panelForStats.ResumeLayout(false);
            this.panelForStats.PerformLayout();
            this.panelForCountDown.ResumeLayout(false);
            this.panelForCountDown.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel playerHealth;
        private System.Windows.Forms.PictureBox heartBox4;
        private System.Windows.Forms.PictureBox heartBox5;
        private System.Windows.Forms.PictureBox heartBox1;
        private System.Windows.Forms.PictureBox heartBox2;
        private System.Windows.Forms.PictureBox heartBox3;
        private System.Windows.Forms.Label labelForHealthTitle;
        private System.Windows.Forms.Label labelForHealthNumber;
        private System.Windows.Forms.Panel panelForStats;
        private System.Windows.Forms.Label labelForScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelForSteakNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelForWaveNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelForCountDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelForCountDown;
    }
}