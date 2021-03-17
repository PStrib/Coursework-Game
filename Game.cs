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
                    squares[i, j] = new Button();
                    squares[i, j].Height = 50;
                    squares[i, j].Width = 50;
                    int [] tagArray = new int[] { i, j };
                    squares[i, j].Tag = tagArray;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    squares[i, j].Location = new Point(i * 51+710, j * 51+250);
                    this.Controls.Add(squares[i, j]);
                }
            }
            var rand = new Random();
        }
    }
}
