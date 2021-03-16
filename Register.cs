using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (txtPassword1.Text != txtPassword2.Text)
            {
                MessageBox.Show("Passwords Do Not Match!");
                return;
            }

            string userName = txtUsername.Text;

            User user = new User();

            if (txtUsername.TextLength < 4)
            {
                MessageBox.Show("Invalid Username:\n\nUsername must be at least 3 characters long");
                return;
            }

            if (txtForename == null || txtSurname == null)
            {
                MessageBox.Show("Please give us your name and surname for no good reason.");
                return;
            }

            bool punctuation = false;
            foreach (int i in txtPassword1.Text)//-----------------------------------------------
            {
                if(Char.IsPunctuation(txtPassword1.Text, i))
                {
                    punctuation = true;
                    break;
                }
            }
            if (txtPassword1.TextLength < 6||punctuation==false)
            {
                MessageBox.Show("Invalid Password:\n\nPassword must be at least 5 characters and contain a punctuation mark");
                return;
            }

            user.Username = txtUsername.Text;
            user.Forename = txtForename.Text;
            user.Surname = txtSurname.Text;
            string password = txtPassword1.Text;
            users.AddUser(user, password);

            MessageBox.Show("New User Created!");
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
        }
    }
}
