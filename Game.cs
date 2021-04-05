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

        private User user;
        private int ticks = 0;
        private const int X_ELEMENTS= 10;
        private const int Y_ELEMENTS = 10;
        private const int MINES = 10;
        private const int SECONDS_IN_MINUTE = 60;
        private int nonMines = (X_ELEMENTS * Y_ELEMENTS) - MINES;
        private int nonMinesRevealed = 0;
        private int flagsPlacedCorrectly = 0;
        private int flagsPlacedIncorrectly = 0;
        private bool isGameLost = false;

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
                buttons[x, y].BackColor = Color.Blue; // Uncomment to cheat and make the mines blue
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
            }
        }
        private void floodFill(int x, int y)
        {
            if (x < 0 || y < 0 || x >= X_ELEMENTS || y >= Y_ELEMENTS)
                return;
            Button button = buttons[x, y];
            if (button.Text != "")
            {
                return;
            }
            var square = squares[x, y];
            if (squares[x, y].hasMine)
            {
                return;
            }
            revealSquare(x, y);
            if (square.adjacencies != 0)
            {
                return;
            }
            floodFill(x, y + 1); // flood fill south
            floodFill(x, y - 1); // flood fill north
            floodFill(x + 1, y); // flood fill east
            floodFill(x - 1, y); // flood fill west
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
                nonMinesRevealed += 1;
            }
            button.ForeColor = Color.Black;
            square.revealed = true;
        }



        private void btnGameButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var me = e as MouseEventArgs;
 
            if (me.Button == MouseButtons.Right)
            {
                gameButtonRightClick(button);
            }
            else
            {
                gameButtonLeftClick(button);
            }

            if (isGameLost)
            {
                return; // If user has been exploded, we don't want them to be able trigger a win state
            }

            haveIWon(); // Still runs haveIWon despite having returned on line 245
        }

        private void gameButtonRightClick(Button button)
        {
            var square = button.Tag as Square;
            if (square.revealed==true)
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
                revealSquare(x, y);
                return;
            }
            
            floodFill(x, y);     
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ticks += 1;
            //gameTimer.Interval = random.Next(1, 1000); // Sets the tick interval to a random value
            refreshTime();            
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            ticks += 5;
            refreshTime();
        }

        private void refreshTime()
        {
            TimeSpan timeElapsed = new TimeSpan(0, 0, ticks);
            var s = timeElapsed.ToString(@"mm\:ss");
            lblTimer.Text = $"{s}";
        }
    }
}
