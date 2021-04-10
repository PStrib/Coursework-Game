using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Coursework_Game
{
    public partial class Login : Form
    {
        private Users users;
        public Login()
        {
            InitializeComponent();
            users = new Users();
        }

        private void btnBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
            this.Hide();
        }

        private void btnLogin_click(object sender, EventArgs e)
        {
            User user;
            try
            {
                string userName = txtUsername.Text;
                string password = txtPassword1.Text;
                user = users.GetUser(userName, password);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.Hide();
            MessageBox.Show("You are logged in successfully!");
            Game game = new Game(user);
            game.ShowDialog();
            this.Close();
        }
    }
}
