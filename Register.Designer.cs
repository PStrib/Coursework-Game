
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
            this.btnBackButton = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword1 = new System.Windows.Forms.Label();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtForename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnNextAvatar = new System.Windows.Forms.Button();
            this.btnPreviousIcon = new System.Windows.Forms.Button();
            this.SplashBackground2 = new System.Windows.Forms.PictureBox();
            this.pBoxAvatar = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SplashBackground2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackButton
            // 
            this.btnBackButton.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackButton.Location = new System.Drawing.Point(40, 12);
            this.btnBackButton.Name = "btnBackButton";
            this.btnBackButton.Size = new System.Drawing.Size(400, 40);
            this.btnBackButton.TabIndex = 6;
            this.btnBackButton.Text = "Go Back";
            this.btnBackButton.UseVisualStyleBackColor = true;
            this.btnBackButton.Click += new System.EventHandler(this.btnBackButton_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(92, 83);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(312, 27);
            this.txtUsername.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(45, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(87, 25);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword1
            // 
            this.lblPassword1.AutoSize = true;
            this.lblPassword1.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F);
            this.lblPassword1.Location = new System.Drawing.Point(45, 263);
            this.lblPassword1.Name = "lblPassword1";
            this.lblPassword1.Size = new System.Drawing.Size(87, 27);
            this.lblPassword1.TabIndex = 4;
            this.lblPassword1.Text = "Password:";
            // 
            // txtPassword1
            // 
            this.txtPassword1.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword1.Location = new System.Drawing.Point(93, 293);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(313, 31);
            this.txtPassword1.TabIndex = 3;
            // 
            // txtPassword2
            // 
            this.txtPassword2.Font = new System.Drawing.Font("Bauhaus 93", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword2.Location = new System.Drawing.Point(94, 366);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(312, 31);
            this.txtPassword2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F);
            this.label1.Location = new System.Drawing.Point(45, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Retype Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F);
            this.label2.Location = new System.Drawing.Point(45, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "Forename:";
            // 
            // txtForename
            // 
            this.txtForename.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtForename.Location = new System.Drawing.Point(94, 154);
            this.txtForename.Name = "txtForename";
            this.txtForename.Size = new System.Drawing.Size(312, 27);
            this.txtForename.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 16F);
            this.label3.Location = new System.Drawing.Point(50, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 27);
            this.label3.TabIndex = 11;
            this.label3.Text = "Surname:";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurname.Location = new System.Drawing.Point(94, 223);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(312, 27);
            this.txtSurname.TabIndex = 2;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccount.Location = new System.Drawing.Point(40, 593);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(400, 40);
            this.btnCreateAccount.TabIndex = 5;
            this.btnCreateAccount.Text = "Register";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnNextAvatar
            // 
            this.btnNextAvatar.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextAvatar.Location = new System.Drawing.Point(328, 512);
            this.btnNextAvatar.Name = "btnNextAvatar";
            this.btnNextAvatar.Size = new System.Drawing.Size(103, 40);
            this.btnNextAvatar.TabIndex = 13;
            this.btnNextAvatar.Text = "Next";
            this.btnNextAvatar.UseVisualStyleBackColor = true;
            this.btnNextAvatar.Click += new System.EventHandler(this.btnNextAvatar_Click);
            // 
            // btnPreviousIcon
            // 
            this.btnPreviousIcon.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousIcon.Location = new System.Drawing.Point(40, 512);
            this.btnPreviousIcon.Name = "btnPreviousIcon";
            this.btnPreviousIcon.Size = new System.Drawing.Size(92, 40);
            this.btnPreviousIcon.TabIndex = 14;
            this.btnPreviousIcon.Text = "Previous";
            this.btnPreviousIcon.UseVisualStyleBackColor = true;
            this.btnPreviousIcon.Click += new System.EventHandler(this.btnPreviousAvatar_Click);
            // 
            // SplashBackground2
            // 
            this.SplashBackground2.BackgroundImage = global::Coursework_Game.Properties.Resources.BookCase;
            this.SplashBackground2.Location = new System.Drawing.Point(-11, -5);
            this.SplashBackground2.Name = "SplashBackground2";
            this.SplashBackground2.Size = new System.Drawing.Size(494, 671);
            this.SplashBackground2.TabIndex = 0;
            this.SplashBackground2.TabStop = false;
            // 
            // pBoxAvatar
            // 
            this.pBoxAvatar.Image = global::Coursework_Game.Properties.Resources.Thumbnail4;
            this.pBoxAvatar.Location = new System.Drawing.Point(180, 473);
            this.pBoxAvatar.Name = "pBoxAvatar";
            this.pBoxAvatar.Size = new System.Drawing.Size(100, 100);
            this.pBoxAvatar.TabIndex = 15;
            this.pBoxAvatar.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(129, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 31);
            this.label4.TabIndex = 16;
            this.label4.Text = "Choose Your Thumbnail:";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pBoxAvatar);
            this.Controls.Add(this.btnPreviousIcon);
            this.Controls.Add(this.btnNextAvatar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPassword1);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtForename);
            this.Controls.Add(this.txtPassword1);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnBackButton);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.SplashBackground2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Account";
            ((System.ComponentModel.ISupportInitialize)(this.SplashBackground2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SplashBackground2;
        private System.Windows.Forms.Button btnBackButton;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword1;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtForename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Button btnNextAvatar;
        private System.Windows.Forms.Button btnPreviousIcon;
        private System.Windows.Forms.PictureBox pBoxAvatar;
        private System.Windows.Forms.Label label4;
    }
}