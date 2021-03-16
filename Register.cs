using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Coursework_Game
{

    public partial class Register : Form
    {
        private Users users;

        public Register()
        {
            InitializeComponent();
            users = new Users();
        }



        private void btnBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string password = txtPassword1.Text;
            if (password != txtPassword2.Text)
            {
                MessageBox.Show("Passwords Do Not Match!");
                return;
            }
            User user = new User();

            if (txtUsername.TextLength < 4)
            {
                MessageBox.Show("Invalid Username:\n\nUsername must be at least 3 characters long");
                return;
            }

            if (txtForename.TextLength==0 || txtSurname.TextLength==0)
            {
                MessageBox.Show("Please give us your name and surname for no good reason.");
                return;
            }
            bool hasPunctuation = password.Any(char.IsPunctuation);
            if (txtPassword1.TextLength < 6)
            {
                MessageBox.Show("Invalid Password:\n\nPassword must be at least 5 characters");
                return;
            }

            if (!hasPunctuation)
            {
                MessageBox.Show("Password must have a punctuation");
                return;
            }

            user.Username = txtUsername.Text;
            user.Forename = txtForename.Text;
            user.Surname = txtSurname.Text;
            try
            {
                users.AddUser(user, password);
            }
            catch
            {
                MessageBox.Show("That username is taken, please try another one.");
                return;
            }
            MessageBox.Show("New User Created!");
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
        }
    }
}
