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
                Square square = squares[x, y];
                square.hasMine = true;
                square.adjacencies = 9;
                
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
                //buttons[x, y].Text = Convert.ToString(noOfMines);
            }
        }
        private void floodFill(int x, int y)
        {
            if (x < 0 || y < 0 || x >= X_ELEMENTS || y >= Y_ELEMENTS)
                return;
            Button button = buttons[x, y];
            if (button.Text == "0")
                return;
            var square = squares[x, y];
            if (square.adjacencies != 0)
                return;
            reveal3x3(square);
            floodFill(x, y + 2); // flood fill south
            floodFill(x, y - 2); // flood fill north
            floodFill(x + 2, y); // flood fill east
            floodFill(x - 2, y); // flood fill west
        }

        private void reveal3x3(Square square)
        {
 
            var offsets = new[] { -1, 0, 1 };
            foreach (int xOffset in offsets)
            {
                foreach (int yOffset in offsets)
                {
                    int x = square.x + xOffset;
                    int y = square.y + yOffset;
                    if (x < 0 || y < 0 || x >= X_ELEMENTS || y >= Y_ELEMENTS)
                        continue;
                    revealSquare(x, y);
                }
            }
        }

        private void revealSquare(int x, int y)
        {
            Button button = buttons[x, y];
            Square square = squares[x, y];
            if (square.hasMine)
            {
                button.BackColor = Color.Red;
                button.Text = "💣";
            }
            else
            {
                button.Text = Convert.ToString(square.adjacencies);
            }             
        }

        private void gameOver()
        {
            // TODO: nested for loops and reveal bombs
            MessageBox.Show("Game Over!"); // Placeholder
        }

        private void btnGameButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var square = button.Tag as Square;
            if (square.adjacencies != 0)
            {
                revealSquare(square.x, square.y);
            }
            else if (square.hasMine)
            {
                gameOver();
            }
            else
            {
                floodFill(square.x, square.y);
            }             
        }
    }
}
