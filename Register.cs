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
