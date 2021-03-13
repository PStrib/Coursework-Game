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
        public Login()
        {
            InitializeComponent();
        }

        private void btnBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
        }

        private void btnLogin_click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            User user;
            if(!Register.Users.TryGetValue(userName, out user))
            {
                MessageBox.Show("User Not Found");
                return;
            }
            string password = txtPassword1.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            HashAlgorithm sha = SHA256.Create();
            byte[] attemptPasswordHash = sha.ComputeHash(bytes);
            if (!user.PasswordHash.SequenceEqual (attemptPasswordHash))
            {
                MessageBox.Show("Incorrect Password");
                return;
            }
            MessageBox.Show("Everything is Correct! there is no game.");
        }
    }
}
