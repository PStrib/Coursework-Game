using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_Game
{
    public partial class HighScores : Form
    {
        public HighScores()
        {
            InitializeComponent();
            createTextBox();
        }

        private void btnBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
            this.Close();
        }

        private void createTextBox()
        {
            TextBox textBox1 = new TextBox
            {
                Text = "User:\tTime:",
                Font = new Font("Gazelle", 19),
                Location = new Point(150, 150),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                AcceptsReturn = true,
                AcceptsTab = true,
                WordWrap = true,
                AutoSize = false,
                Size=new System.Drawing.Size(200, 400),
            };
            this.Controls.Add(textBox1);
            textBox1.BringToFront();
        }
    }
}
