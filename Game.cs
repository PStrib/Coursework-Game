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
    public partial class Game : Form
    {
        private User user;
        private const int X_ELEMENTS= 3;
        private const int Y_ELEMENTS = 3;
        private int[,] gameboard = new int [12, 12];


        public Game(User user)
        {
            this.user = user;
            InitializeComponent();
            pboxAvatar.Image = user.Avatar;
            Button[,] squares = new Button[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int[] tagArray = new int[] { i, j };
                    Point point = new Point(i * 51 + 710, j * 51 + 250);
                    Button button = new Button
                    {
                        Height = 50,
                        Width = 50,
                        Tag = tagArray,
                        Location = point,
                    };
                    button.Click+=btnGameButton_Click;
                    this.Controls.Add(button);
                    squares[i, j] = button;
                }
            }

            var rand = new Random();
        }
        private void btnGameButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tagArray = button.Tag as int[];
            MessageBox.Show($"{tagArray[0]},{tagArray[1]}");
        }
    }
}
