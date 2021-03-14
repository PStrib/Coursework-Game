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
        public Game(User user)
        {
            this.user = user;
            InitializeComponent();
        }
    }
}
