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
        public WinScreen()
        {
            InitializeComponent();
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.Hide();
            User user = new User();
            Game game = new Game(user);
            game.ShowDialog();
            this.Close();
        }

        private void btnQuitToDesktop_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
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
