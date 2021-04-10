using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_Game
{
    public partial class Game : Form
    {
        private void gameLost()
        {
            revealAllSquares();
            isGameLost = true;
            gameTimer.Stop();
            gameLostText();
            retry();
        }

        // Reveals all mines and adjacencies
        private void revealAllSquares()
        {
            for (int x = 0; x < X_ELEMENTS; x++)
            {
                for (int y = 0; y < Y_ELEMENTS; y++)
                {
                    revealSquareIfNotRevealedAlready(x, y);
                }
            }
        }

        private void gameLostText()
        {
            var lblgameOver = new Label
            {
                Text = "GAME OVER",
                Font = new Font("Fipps", 50),
                Location = new Point(655, 70),
                AutoSize = true,
            };
            this.Controls.Add(lblgameOver);
            MessageBox.Show("You failed as a mine sweeper.\n\nYour entire platoon was killed in the blast.");
        }

        private void retry()
        {
            var btnRetry = new Button
            {
                Text = "Try Again?",
                Font = new Font("Bahnschrift", 25, FontStyle.Bold),
                Location = new Point(875, 780),
                AutoSize = true,
            };
            btnRetry.Click += btnRetry_Click;
            this.Controls.Add(btnRetry);
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Game game = new Game(user);
            game.ShowDialog();            
        }

        private bool haveIWon()
        {
            return nonMinesRevealed == NON_MINES
                || ((flagsPlacedCorrectly == MINES) && (flagsPlacedIncorrectly == 0));
        }

        private void gameWon()
        {
            gameTimer.Stop();
            Score score = new Score(secondsElapsed, user);
            Scores scores = new Scores();
            scores.Add(score);
            this.Hide();
            this.Close();
            WinScreen winScreen = new WinScreen(score);
            winScreen.ShowDialog();
        }
    }
}
