
namespace Coursework_Game
{
    partial class HighScores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighScores));
            this.Background = new System.Windows.Forms.PictureBox();
            this.btnBackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.BackgroundImage = global::Coursework_Game.Properties.Resources.BookCase;
            this.Background.Location = new System.Drawing.Point(-9, -29);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(500, 700);
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // btnBackButton
            // 
            this.btnBackButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackButton.Location = new System.Drawing.Point(44, 582);
            this.btnBackButton.Name = "btnBackButton";
            this.btnBackButton.Size = new System.Drawing.Size(400, 40);
            this.btnBackButton.TabIndex = 1;
            this.btnBackButton.Text = "Go Back";
            this.btnBackButton.UseVisualStyleBackColor = true;
            this.btnBackButton.Click += new System.EventHandler(this.btnBackButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 63);
            this.label1.TabIndex = 2;
            this.label1.Text = "HighScores";
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBackButton);
            this.Controls.Add(this.Background);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HighScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HighScores";
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Button btnBackButton;
        private System.Windows.Forms.Label label1;
    }
}