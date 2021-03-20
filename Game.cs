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

            public Square(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"{x}, {y}, hasmine={hasMine}, adjacencies={adjacencies}";
            }
        }

        private User user;
        private const int X_ELEMENTS= 10;
        private const int Y_ELEMENTS = 10;
        private const int MINES = 10;
        private Button[,] buttons = new Button[X_ELEMENTS, Y_ELEMENTS];
        // gameBoard is 2 bigger in x and y so as to simplify the adjacencies algorithm
        private bool[,] gameBoard = new bool[X_ELEMENTS+2, Y_ELEMENTS+2];
        private Square[,] squares = new Square[X_ELEMENTS,Y_ELEMENTS];
        Random random = new Random();


        public Game(User user)
        {
            this.user = user;
            InitializeComponent();
            pboxAvatar.Image = user.Avatar;
            generateBoard();
            placeMines();
            updateSquares();
        }
        private void generateBoard()
        {

            for (int x = 0; x < X_ELEMENTS; x++)
            {
                for (int y = 0; y < Y_ELEMENTS; y++)
                {
                    Square square = new Square(x, y);
                    squares[x, y] = square;
                    Point point = new Point(x * 51 + 710, y * 51 + 250);
                    Button button = new Button
                    {
                        Height = 50,
                        Width = 50,
                        Location = point,
                        Tag = square,
                    };
                    button.Click += btnGameButton_Click;
                    this.Controls.Add(button);
                    buttons[x, y] = button;
                }
            }
        }

        private void placeMines()
        {
            // For next time try shuffling
            for (int i = 0; i < MINES; i++)
            {
                int x;
                int y;
                do
                {
                    x = random.Next(Y_ELEMENTS);
                    y = random.Next(X_ELEMENTS);
                }
                while ((gameBoard[x+1, y+1] == true)) ;
                gameBoard[x+1, y+1] = true;
            }
        }
        private void updateSquares()
        {
            for (int x = 0; x < X_ELEMENTS; x++)
            {
                for (int y = 0; y < Y_ELEMENTS; y++)
                {
                    updateSquare(x, y);
                }
            }
        }

        private void updateSquare(int x, int y)
        {
            int noOfMines=0;
            var offsets = new[] { -1, 0, 1 };
            if (gameBoard[x + 1, y + 1])//if the coordinates being checked are a mine
            {
                squares[x, y].hasMine = true;
                buttons[x, y].BackColor = Color.Red;
                buttons[x,y].Text="💣";
            }
            else
            {
                foreach (int xOffset in offsets)
                {
                    foreach (int yOffset in offsets)
                    {

                        if (gameBoard[x + xOffset + 1, y + yOffset + 1])
                        {
                            noOfMines += 1;
                        }
                    }
                }
                squares[x, y].adjacencies = noOfMines;
                buttons[x, y].Text = Convert.ToString(noOfMines);
            }
        }

    private void btnGameButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var square = button.Tag as Square;
        }
    }
}
