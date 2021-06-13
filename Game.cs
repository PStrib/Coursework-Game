using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            public bool hasFlag = false;
            public bool revealed = false;
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

        // Controls the positioning on the screen of the button panel
        private const int ELEMENT_SIZE = 50;
        private const int X_START = 710;
        private const int Y_START = 250;

        private const int X_ELEMENTS = 10;
        private const int Y_ELEMENTS = 10;
        private const int MINES = 10;
        private const int NON_MINES = (X_ELEMENTS * Y_ELEMENTS) - MINES;

        private User user;

        private int secondsElapsed = 0;
        
        private int nonMinesRevealed = 0;
        private int flagsPlacedCorrectly = 0;
        private int flagsPlacedIncorrectly = 0;
        // isGameLost is only true if the user left clicks an unflagged mine.
        private bool isGameLost = false;

        // Buttons are placed on the form for the user to see and squares are just info about the buttons
        private Button[,] buttons = new Button[X_ELEMENTS, Y_ELEMENTS];
        private Square[,] squares = new Square[X_ELEMENTS, Y_ELEMENTS];
        // gameBoard is 2 bigger in x and y so as to simplify the adjacencies algorithm
        private bool[,] gameBoard = new bool[X_ELEMENTS+2, Y_ELEMENTS+2];

        Random random = new Random();

        public Game()
        {
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

                    // ELEMENT_SIZE + 1 because there's a 1 pixel gap between buttons.
                    Point point = new Point(x * (ELEMENT_SIZE+1) + X_START, y * (ELEMENT_SIZE + 1) + Y_START);
                    Button button = new Button
                    {
                        Height = ELEMENT_SIZE,
                        Width = ELEMENT_SIZE,
                        Location = point,
                        Tag = square,
                        Font=new Font("Bahnschrift", 24)
                    };
                    // TODO: support keyboard navigation (up=up etc)
                    button.MouseDown += btnGameButton_Click;
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
                int x, y;
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
                    setSquareInfo(x, y);
                }
            }
        }

        private void setSquareInfo(int x, int y)
        {
            if (gameBoard[x + 1, y + 1]) // If the coordinates being checked are a mine
            {
                Square square = squares[x, y];
                square.hasMine = true;
                //buttons[x, y].BackColor = Color.Blue; // Uncomment to cheat and make the mines blue
            }
            else
            {
                squares[x, y].adjacencies = countAdjacencies(x, y);
            }
        }

        private int countAdjacencies(int x, int y)
        {
            int noOfMines = 0;
            var offsets = new[] { -1, 0, 1 };
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
            return noOfMines;
        }

        private void floodFill(int x, int y)
        {
            if (x < 0 || y < 0 || x >= X_ELEMENTS || y >= Y_ELEMENTS)
                return;
            Button button = buttons[x, y];
            var square = squares[x, y];
            if (square.revealed || square.hasMine)
            {
                return;
            }

            revealSquareIfNotRevealedAlready(x, y);
            if (square.adjacencies != 0)
            {
                return;
            }
            floodFill(x, y + 1); // flood fill south
            floodFill(x, y - 1); // flood fill north
            floodFill(x + 1, y); // flood fill east
            floodFill(x - 1, y); // flood fill west
        }

        private void revealSquareIfNotRevealedAlready(int x, int y)
        {
            Button button = buttons[x, y];
            Square square = squares[x, y];
            if (square.revealed)
            {
                return;
            }

            if (square.hasMine)
            {
                button.BackColor = Color.Red;
                button.Text = "💣";
            }
            else
            {
                button.Text = Convert.ToString(square.adjacencies);
                nonMinesRevealed += 1;
            }
            button.ForeColor = Color.Black;
            square.revealed = true;
        }



        private void btnGameButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var mouse = e as MouseEventArgs;

            switch (mouse.Button)
            {
                case MouseButtons.Right:
                    gameButtonRightClick(button);
                    break;
                default:
                    gameButtonLeftClick(button);
                    break;
            }

            if (isGameLost)
            {
                return; // If user has been exploded, we don't want them to be able trigger a win state
            }

            if (haveIWon())
            {
                gameWon();
            }
        }

        private void gameButtonRightClick(Button button)
        {
            var square = button.Tag as Square;
            if (square.revealed)
            {
                return;
            }
            square.hasFlag = !(square.hasFlag);
            if (square.hasFlag)
            {
                placeFlag(button, square);
            }
            else
            {
                unplaceFlag(button, square);
            }
        }

        private void placeFlag(Button button, Square square)
        {
            button.Text = "🚩";
            button.ForeColor = Color.Red;
            if (square.hasMine)
            {
                flagsPlacedCorrectly += 1;
            }
            else
            {
                flagsPlacedIncorrectly += 1;
            }
        }

        private void unplaceFlag(Button button, Square square)
        {
            button.Text = "";
            if (square.hasMine)
            {
                flagsPlacedCorrectly -= 1;
            }
            else
            {
                flagsPlacedIncorrectly -= 1;
            }
        }

        private void gameButtonLeftClick(Button button)
        {
            var square = button.Tag as Square;
            int x = square.x;
            int y = square.y;

            if (square.hasFlag)
            {
                return; // If square has a flag, we don't want the mine under to explode.
            }

            if (square.hasMine)
            {
                gameLost();
                return;
            }

            if (square.adjacencies != 0)
            {
                revealSquareIfNotRevealedAlready(x, y);
                return;
            }
            
            floodFill(x, y);     
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            secondsElapsed += 1;
            refreshTime();            
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            secondsElapsed += 5;
            refreshTime();
        }

        private void refreshTime()
        {
            TimeSpan timeElapsed = new TimeSpan(0, 0, secondsElapsed);
            lblTimer.Text = $"{timeElapsed:mm\\:ss}";
        }
    }
}
