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
            public int x, y, z;
            public bool hasMine = false;
            public int adjacencies;
            public bool hasFlag = false;
            public bool revealed = false;
            public Square(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public override string ToString()
            {
                return $"Square({x}, {y}, {z}, hasmine={hasMine}, adjacencies={adjacencies})";
            }
        }

        // Controls the positioning on the screen of the button panel
        private const int ELEMENT_SIZE = 50;
        private const int X_START = 710;
        private const int Y_START = 250;

        private const int X_ELEMENTS = 10;
        private const int Y_ELEMENTS = 10;
        private const int Z_ELEMENTS = 10;
        private const int MINES = 50;
        private const int NON_MINES = (X_ELEMENTS * Y_ELEMENTS * Z_ELEMENTS) - MINES;

        private User user;

        private int secondsElapsed = 0;
        
        private int nonMinesRevealed = 0;
        private int flagsPlacedCorrectly = 0;
        private int flagsPlacedIncorrectly = 0;
        // isGameLost is only true if the user left clicks an unflagged mine.
        private bool isGameLost = false;

        // Buttons are placed on the form for the user to see and squares are just info about the buttons
        private Button[,] buttons = new Button[X_ELEMENTS, Y_ELEMENTS];
        private Square[,,] squares = new Square[X_ELEMENTS, Y_ELEMENTS, Z_ELEMENTS];
        private int currentZ = Z_ELEMENTS - 1;
        // gameBoard is 2 bigger in all dimensions so as to simplify the adjacencies algorithm
        private bool[,,] gameBoard = new bool[X_ELEMENTS+2, Y_ELEMENTS+2, Z_ELEMENTS+2];

        Random random = new Random();

        public Game(User user)
        {
            this.user = user;
            InitializeComponent();
            pboxAvatar.Image = user.Avatar;
            placeMines();
            forAllSquares(generateSquare);
            forAllButtons(generateButton);
            updateLayer();
        }

        private void updateLayer()
        {
            forAllButtons((int x, int y) => { buttons[x, y].Tag = squares[x, y, currentZ]; });
            forAllButtons(paintButton);
            maybeGreyZButtons();
        }

        private void generateButton(int x, int y)
        {
            // ELEMENT_SIZE + 1 because there's a 1 pixel gap between buttons.
            Button button = new Button
            {
                Height = ELEMENT_SIZE,
                Width = ELEMENT_SIZE,
                Location = new Point(x * (ELEMENT_SIZE + 1) + X_START, y * (ELEMENT_SIZE + 1) + Y_START),
                Font = new Font("Bahnschrift", 24)
            };            
            // TODO: support keyboard navigation (up=up etc)
            button.MouseDown += btnGameButton_Click;
            this.Controls.Add(button);
            buttons[x, y] = button;           
        }

        private void forAllButtons(Action<int, int> action)
        {
            for (int x = 0; x < X_ELEMENTS; x++)
            {
                for (int y = 0; y < Y_ELEMENTS; y++)
                {
                    action(x,y);
                }
            }
        }

        private void placeMines()
        {
            // For next time try shuffling
            for (int i = 0; i < MINES; i++)
            {
                int x, y, z;
                do
                {
                    x = random.Next(Y_ELEMENTS);
                    y = random.Next(X_ELEMENTS);
                    z = random.Next(Z_ELEMENTS);
                }
                while (gameBoard[x+1, y+1, z+1] == true);
                gameBoard[x+1, y+1, z+1] = true;
            }
        }

        private void forAllSquares(Action<int, int, int> action)
        {
            for (int x = 0; x < X_ELEMENTS; x++)
            {
                for (int y = 0; y < Y_ELEMENTS; y++)
                {
                    for (int z = 0; z < Z_ELEMENTS; z++)
                    {
                        action(x, y, z);
                    }
                }
            }
        }

        private void generateSquare(int x, int y, int z)
        {
            Square square = new Square(x,y,z);
            squares[x, y, z] = square;
            if (gameBoard[x + 1, y + 1, z+1]) // If the coordinates being checked are a mine
            {
                square.hasMine = true;
            }
            else
            {
                square.adjacencies = countAdjacencies(x, y, z);
            }
        }

        private int countAdjacencies(int x, int y, int z)
        {
            int noOfMines = 0;
            var offsets = new[] { -1, 0, 1 };
            foreach (int xOffset in offsets)
            {
                foreach (int yOffset in offsets)
                {
                    foreach (int zOffset in offsets)
                    {
                        if (gameBoard[x + xOffset + 1, y + yOffset + 1, z + zOffset + 1])
                        {
                            noOfMines += 1;
                        }
                    }

                }
            }
            return noOfMines;
        }

        private void floodFill(int x, int y, int z)
        {
            if (x < 0 || y < 0 || z < 0 || x >= X_ELEMENTS || y >= Y_ELEMENTS || z >= Z_ELEMENTS)
            {
                return;
            }                
            var square = squares[x, y, z];
            if (square.revealed || square.hasMine)
            {
                return;
            }

            revealSquareIfNotRevealedAlready(square);
            if (square.adjacencies != 0)
            {
                return;
            }
            floodFill(x, y, z + 1); // flood fill up
            floodFill(x, y, z - 1); // flood fill down
            floodFill(x, y + 1, z); // flood fill south
            floodFill(x, y - 1, z); // flood fill north
            floodFill(x + 1, y, z); // flood fill east
            floodFill(x - 1, y, z); // flood fill west
        }

        private void revealSquareIfNotRevealedAlready(int x, int y, int z)
        {
            revealSquareIfNotRevealedAlready(squares[x, y, z]);
        }

        private void revealSquareIfNotRevealedAlready(Square square)
        {
            
            Button button = buttons[square.x, square.y];
            if (square.revealed)
            {
                return;
            }

            if(!square.hasMine)
            {
                nonMinesRevealed += 1;
            }

            square.revealed = true;
            paintButton(button);
        }

        private void paintButton(int x, int y)
        {
            paintButton(buttons[x, y]);
        }

        private void paintButton(Button button)
        {
            Color backColour = defaultBackground();
            Square square = button.Tag as Square;
            if (square.hasFlag)
            {
                paintButtonWith(button, defaultBackground(), Color.Red, "🚩");
                return;
            }

            if (square.hasMine)
            {
                //backColour = Color.Blue; // Uncomment to cheat and make the mines blue
            }           

            if (!square.revealed)
            {
                paintButtonWith(button, backColour, Color.Black, "");
                return;
            }

            if (square.hasMine)
            {
                paintButtonWith(button, Color.Red, Color.Black, "💣");
            }

            else
            {
                Color foreColour;
                switch (square.adjacencies)
                {
                    case 0: paintButtonWith(button, Color.LightGray, Color.DarkGray, "0"); return;
                    case 1: foreColour = Color.Blue; break;
                    case 2: foreColour = Color.Green; break;
                    case 3: foreColour = Color.Red; break;
                    case 4: foreColour = Color.Navy; break;
                    case 5: foreColour = Color.Brown; break;
                    case 6: foreColour = Color.DarkCyan; break;
                    case 7: foreColour = Color.Black; break;
                    case 8: foreColour = Color.Gray; break;
                    default: foreColour = Color.MediumPurple; break;
                }
                paintButtonWith(button, backColour, foreColour, $"{square.adjacencies}");
            }
        }

        private static Color defaultBackground()
        {
            return SystemColors.Control;
        }

        private void paintButtonWith(Button button, Color backColour, Color foreColour, string text)
        {
            button.ForeColor = foreColour;
            button.BackColor = backColour;
            button.Text = text;
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
            if (square.hasMine)
            {
                flagsPlacedCorrectly += 1;
            }
            else
            {
                flagsPlacedIncorrectly += 1;
            }
            paintButton(button);
        }

        private void unplaceFlag(Button button, Square square)
        {
            if (square.hasMine)
            {
                flagsPlacedCorrectly -= 1;
            }
            else
            {
                flagsPlacedIncorrectly -= 1;
            }
            paintButton(button);
        }

        private void gameButtonLeftClick(Button button)
        {
            var square = button.Tag as Square;
            int x = square.x;
            int y = square.y;
            int z = square.z;

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
                revealSquareIfNotRevealedAlready(square);
                return;
            }           
            floodFill(x, y, z);     
        }

        //private void keyPressed(object o, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (Char)Keys.Down && btnDown.Enabled)
        //    {
        //        // Call btnZ_Click and send that it was the down button triggered.
        //        MessageBox.Show("You pressed the Down arrow");
        //    }
        //    if (e.KeyChar == (Char)Keys.Up && btnUp.Enabled)
        //    {
        //        // Call btnZ_Click and send that it was the up button triggered
        //        MessageBox.Show("You pressed the up arrow");
        //    }
        //}

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

        private void btnZ_Click(object sender, EventArgs e)
        {
            int step;
            Button button = sender as Button;
            if (button == btnUp)
            {
                step = 1;
            }
            else
            {
                step = -1;
            }
            currentZ += step;
            maybeGreyZButtons();
            updateLayer();
        }

        private void maybeGreyZButtons()
        {
            switch (currentZ)
            {
                case 0:
                    btnDown.Enabled = false;
                    break;
                case Z_ELEMENTS - 1:
                    btnUp.Enabled = false;
                    break;
                default:
                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                    break; 
            }
        }
    }
}
