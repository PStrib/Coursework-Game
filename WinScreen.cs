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
        private User user;
        private int ticks;
        public WinScreen(User user, int ticks)
        {
            InitializeComponent();
            this.user = user;
            this.ticks = ticks;
            //TimeSpan timeElapsed = new TimeSpan(0, 0, this.ticks);
            //var s = timeElapsed.ToString(@"mm\:ss");
            lblTimeDisplay.Text = (ticks+" Seconds");
        }
        

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.Hide();            
            Game game = new Game(this.user);
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
