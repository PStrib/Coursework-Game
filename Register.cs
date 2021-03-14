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
        public static Dictionary<string, User> Users { get => users; set => users = value; }
        public Register()
        {
            InitializeComponent();
            if (Users==null)
            {
                Users = new Dictionary<string, User>();
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
            if (Users.ContainsKey(userName))
            {
                MessageBox.Show("That username is already in use.");
                return;
            }
            User user = new User();
            string password = txtPassword1.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(bytes);
            user.Username = txtUsername.Text;
            user.Forename = txtForename.Text;
            user.Surname = txtSurname.Text;
            user.PasswordHash = result;
            Users.Add(userName, user);
            MessageBox.Show("New User Created!");
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
        }
    }
}
