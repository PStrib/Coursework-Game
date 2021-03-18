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
        private class Square 
        {
            public int x, y;
            public bool hasMine = false;
            public int adjacencies;
            public override string ToString()
            {
                return $"{x}, {y}, {hasMine}";
            }
        }

        private User user;
        private const int X_ELEMENTS= 10;
        private const int Y_ELEMENTS = 10;
        private const int MINES = 10;
        private bool[,] gameboard = new bool[X_ELEMENTS+2, Y_ELEMENTS+2];
        private List<int[]>mines = new List<int[]>();
        Random random = new Random();


        public Game(User user)
        {
            this.user = user;
            InitializeComponent();
            pboxAvatar.Image = user.Avatar;
            generateBoard();
            placeMines();
            //foreach (int[] i in mines)
            //{
            //    for (int x = 0; x < X_ELEMENTS; x++)
            //    {
            //        for (int j = 0; j < Y_ELEMENTS; j++)
            //        {
            //            if (x == i[0] && j == i[1])
            //            {
            //                squares[x, j].BackColor = Color.Red;
            //                squares[x, j].Tag = "Mine";
            //            }
            //        }
            //    }
            //}
        }

        private void placeMines()
        {
            for (int i = 0; i < 10; i++)
            {
                int row = random.Next(Y_ELEMENTS);
                int column = random.Next(X_ELEMENTS);
                int[] chosenValues = new int[2] { row, column };
                while (mines.Contains(chosenValues))
                {
                    row = random.Next(Y_ELEMENTS);
                    column = random.Next(X_ELEMENTS);
                    chosenValues = new int[2] { row, column };
                }
                mines.Add(new int[] { row, column });
            }
        }

        private void generateBoard()
        {
            Button[,] squares = new Button[X_ELEMENTS, Y_ELEMENTS];
            for (int i = 0; i < X_ELEMENTS; i++)
            {
                for (int j = 0; j < Y_ELEMENTS; j++)
                {
                    Square square = new Square { x = i, y = j };
                    Point point = new Point(i * 51 + 710, j * 51 + 250);
                    Button button = new Button
                    {
                        Height = 50,
                        Width = 50,
                        Location = point,
                        Tag = square,
                    };
                    button.Click += btnGameButton_Click;
                    this.Controls.Add(button);
                    squares[i, j] = button;
                }
            }
        }

        //private int howManyMimes()
        //{
        //    int noOfMines = 0;
        //    for (int column = 0; column < X_ELEMENTS; column++)
        //    {
        //        for (int row = 0; row < Y_ELEMENTS; row++)
        //        {
        //            noOfMines = adjacentMines(noOfMines, column, row);
        //        }
        //    }
        //    return noOfMines;
        //}

        private int adjacentMines(int noOfMines, int column, int row)
        {
             adjacentSquares=new Square { }

            return noOfMines;
        }

    private void btnGameButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var square = button.Tag as Square;
            MessageBox.Show(Convert.ToString(square));
        }
    }
}
