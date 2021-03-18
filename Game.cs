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
    using Tag = Tuple<int, int>;
    public partial class Game : Form
    {

        private User user;
        private const int X_ELEMENTS= 10;
        private const int Y_ELEMENTS = 10;
        private int[,] gameboard = new int [X_ELEMENTS+2, Y_ELEMENTS+2];
        private List<int[]>mines = new List<int[]>();
        Random random = new Random();


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
                    Tag tagArray = new Tag ( i, j );
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

            for (int i = 0; i < 10; i++)
            { 
                int row = random.Next(10);
                int column = random.Next(10);
                int[] chosenValues = new int[2] { row, column };
                while (mines.Contains(chosenValues)){
                    row = random.Next(10);
                    column = random.Next(10);
                    chosenValues = new int[2] { row, column };
                }
                mines.Add(new int[] { row, column }); 
            }
            foreach(int[] i in mines)
            {
                for(int x = 0; x < X_ELEMENTS; x++)
                {
                    for(int j = 0; j < Y_ELEMENTS; j++)
                    {
                        if (x == i[0] && j == i[1])
                        {
                            squares[x,j].BackColor = Color.Red;
                            squares[x, j].Tag = "Mine";
                        }
                    }
                }
                {

                }
            }

            

        }
        private void btnGameButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tagArray = button.Tag as Tag;
            MessageBox.Show($"{tagArray.Item1},{tagArray.Item2}");
        }
    }
}
