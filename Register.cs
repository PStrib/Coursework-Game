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
    public partial class Register : Form
    {
        private static Dictionary<string,User> users;
        public Register()
        {
            InitializeComponent();
            if (users==null)
            {
                users = new Dictionary<string, User>();
            }
        }

        private void btnBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (txtPassword1.Text != txtPassword2.Text)
            {
                MessageBox.Show("Passwords Do Not Match!");
                return;
            }

            string userName = txtUsername.Text;
            if (users.ContainsKey(userName))
            {
                MessageBox.Show("That username is already in use.");
                return;
            }
            User user = new User();
            string password = txtPassword1.Text;
            byte[] bytes = Encoding.ASCII.GetBytes(password);
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(bytes);
            MessageBox.Show(Convert.ToString(result));

            user.Username = txtUsername.Text;
            user.Forename = txtForename.Text;
            user.Surname = txtSurname.Text;
            user.Password = txtPassword1.Text;
            users.Add(userName, user);
            MessageBox.Show("New User Created!");
            MessageBox.Show(Convert.ToString(users.Count));
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
        }
    }
}
