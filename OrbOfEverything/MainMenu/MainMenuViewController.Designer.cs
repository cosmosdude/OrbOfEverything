namespace OrbOfEverything
{
    partial class MainMenuViewController
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
            this.gradientView = new OrbOfEverything.CustomGraphics.GradientPanel();
            this.contentContainer = new System.Windows.Forms.Panel();
            this.buttonForSurvival = new System.Windows.Forms.Button();
            this.buttonForQuit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gradientView.SuspendLayout();
            this.contentContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientView
            // 
            this.gradientView.BackColor = System.Drawing.Color.White;
            this.gradientView.Controls.Add(this.contentContainer);
            this.gradientView.endColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(65)))));
            this.gradientView.Location = new System.Drawing.Point(2, 2);
            this.gradientView.Name = "gradientView";
            this.gradientView.Size = new System.Drawing.Size(895, 494);
            this.gradientView.startColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(255)))), ((int)(((byte)(148)))));
            this.gradientView.TabIndex = 0;
            // 
            // contentContainer
            // 
            this.contentContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.contentContainer.Controls.Add(this.buttonForSurvival);
            this.contentContainer.Controls.Add(this.buttonForQuit);
            this.contentContainer.Controls.Add(this.pictureBox1);
            this.contentContainer.Location = new System.Drawing.Point(74, 34);
            this.contentContainer.Name = "contentContainer";
            this.contentContainer.Size = new System.Drawing.Size(568, 345);
            this.contentContainer.TabIndex = 1;
            // 
            // buttonForSurvival
            // 
            this.buttonForSurvival.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonForSurvival.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonForSurvival.FlatAppearance.BorderSize = 0;
            this.buttonForSurvival.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonForSurvival.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonForSurvival.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForSurvival.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonForSurvival.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(178)))), ((int)(((byte)(251)))));
            this.buttonForSurvival.Location = new System.Drawing.Point(107, 199);
            this.buttonForSurvival.Name = "buttonForSurvival";
            this.buttonForSurvival.Size = new System.Drawing.Size(348, 66);
            this.buttonForSurvival.TabIndex = 3;
            this.buttonForSurvival.Text = "Play";
            this.buttonForSurvival.UseVisualStyleBackColor = false;
            this.buttonForSurvival.Click += new System.EventHandler(this.buttonForSurvival_Click);
            // 
            // buttonForQuit
            // 
            this.buttonForQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonForQuit.CausesValidation = false;
            this.buttonForQuit.FlatAppearance.BorderSize = 0;
            this.buttonForQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonForQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonForQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForQuit.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonForQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(104)))), ((int)(((byte)(224)))));
            this.buttonForQuit.Location = new System.Drawing.Point(107, 283);
            this.buttonForQuit.Name = "buttonForQuit";
            this.buttonForQuit.Size = new System.Drawing.Size(348, 59);
            this.buttonForQuit.TabIndex = 1;
            this.buttonForQuit.Text = "Quit";
            this.buttonForQuit.UseVisualStyleBackColor = false;
            this.buttonForQuit.Click += new System.EventHandler(this.buttonForQuit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::OrbOfEverything.Properties.Resources.interface_title;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(562, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenuViewController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 508);
            this.Controls.Add(this.gradientView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenuViewController";
            this.Text = "Orb of Everything";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenuViewController_Load);
            this.Resize += new System.EventHandler(this.MainMenuViewController_Resize);
            this.gradientView.ResumeLayout(false);
            this.contentContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private CustomGraphics.GradientPanel gradientView;
        private System.Windows.Forms.Panel contentContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonForSurvival;
        private System.Windows.Forms.Button buttonForQuit;
    }
}

