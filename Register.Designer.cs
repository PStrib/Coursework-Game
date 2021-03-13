
namespace Coursework_Game
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.SplashBackground2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SplashBackground2)).BeginInit();
            this.SuspendLayout();
            // 
            // SplashBackground2
            // 
            this.SplashBackground2.BackgroundImage = global::Coursework_Game.Properties.Resources.BookCase;
            this.SplashBackground2.Location = new System.Drawing.Point(-6, -4);
            this.SplashBackground2.Name = "SplashBackground2";
            this.SplashBackground2.Size = new System.Drawing.Size(636, 449);
            this.SplashBackground2.TabIndex = 0;
            this.SplashBackground2.TabStop = false;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 436);
            this.Controls.Add(this.SplashBackground2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.Text = "Create Account";
            ((System.ComponentModel.ISupportInitialize)(this.SplashBackground2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SplashBackground2;
    }
}