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
    public partial class WinScreen : Form
    {
        private Score score;
        
        public WinScreen(Score score)
        {
            InitializeComponent();
            lblTimeDisplay.Text = score.ticks + " Seconds";
            this.score = score;
        }
        
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.Hide();            
            Game game = new Game(score.user);
            game.ShowDialog();
            this.Close();
        }

        private void btnQuitToDesktop_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit to desktop?", "This will close the program", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                this.Close();
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
