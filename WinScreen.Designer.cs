
namespace Coursework_Game
{
    partial class WinScreen
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
            this.lblWin = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWin
            // 
            this.lblWin.AutoSize = true;
            this.lblWin.BackColor = System.Drawing.Color.Transparent;
            this.lblWin.Font = new System.Drawing.Font("Gazelle", 80F);
            this.lblWin.Location = new System.Drawing.Point(89, 31);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(630, 166);
            this.lblWin.TabIndex = 0;
            this.lblWin.Text = "You Win!";
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnRestart.Font = new System.Drawing.Font("Gazelle", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRestart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRestart.Location = new System.Drawing.Point(117, 621);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(220, 54);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "Play Again?";
            this.btnRestart.UseVisualStyleBackColor = false;
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chartreuse;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblWin);
            this.ForeColor = System.Drawing.Color.Purple;
            this.Name = "WinScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "You Win!";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.Button btnRestart;
    }
}