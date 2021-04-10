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
        private const int MAX_SCORES = 20;

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
            Scores scores = new Scores();
            List<string> text = new List<string>();
            text.Add("User:\tTime(S):\r\n");
            int index = 1;
            foreach(Score score in scores.ListAll())
            {
                if(index> MAX_SCORES) { break; }
                string timeTaken = score.seconds.ToString("000");
                string line = $"{score.user.Username}\t {timeTaken}\r\n";
                text.Add(line);
                index += 1;
            }
            string textString = string.Join("\n", text);

            TextBox textBox1 = new TextBox
            {
                Text = textString,
                Font = new Font("Gazelle", 15),
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
