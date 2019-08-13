namespace OrbOfEverything.Settings
{
    partial class SettingsViewController
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
            this.gradientView.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientView
            // 
            this.gradientView.Controls.Add(this.contentContainer);
            this.gradientView.endColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(65)))));
            this.gradientView.Location = new System.Drawing.Point(41, 4);
            this.gradientView.Name = "gradientView";
            this.gradientView.Size = new System.Drawing.Size(895, 494);
            this.gradientView.startColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(255)))), ((int)(((byte)(148)))));
            this.gradientView.TabIndex = 1;
            // 
            // contentContainer
            // 
            this.contentContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.contentContainer.Location = new System.Drawing.Point(220, 34);
            this.contentContainer.Name = "contentContainer";
            this.contentContainer.Size = new System.Drawing.Size(422, 408);
            this.contentContainer.TabIndex = 1;
            // 
            // SettingsViewController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 503);
            this.Controls.Add(this.gradientView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsViewController";
            this.Text = "SettingsViewController";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SettingsViewController_Load);
            this.Resize += new System.EventHandler(this.SettingsViewController_Resize);
            this.gradientView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomGraphics.GradientPanel gradientView;
        private System.Windows.Forms.Panel contentContainer;
    }
}