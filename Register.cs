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
        private int avatar;
        private const int NUM_AVATARS = 5;
        private Image[] avatars;

        public Register()
        {
            InitializeComponent();
            users = new Users();
            populateAvatars();
            avatar = 0;
            setAvatar();
        }
        private void populateAvatars()
        {
            avatars = new Image[NUM_AVATARS];
            avatars[0] = Properties.Resources.Thumbnail1;
            avatars[1] = Properties.Resources.Thumbnail2;
            avatars[2] = Properties.Resources.Thumbnail3;
            avatars[3] = Properties.Resources.Thumbnail4;
            avatars[4] = Properties.Resources.Thumbnail5;
        }

        private void setAvatar()
        {
            pBoxAvatar.Image = avatars[avatar];
        }

        private void btnBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreen splashscreen = new SplashScreen();
            splashscreen.ShowDialog();
            this.Close();
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
            user.Avatar = avatars[avatar];
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
            this.Close();
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tagstr=button.Tag as string;
            int direction = Convert.ToInt32(tagstr);
            avatar += direction;
            if (avatar == 5)
            {
                avatar = 0;
            }
            if (avatar == -1)
            {
                avatar = 4;
            }


            setAvatar();
        }
    }
}
