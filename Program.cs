using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_Game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new SplashScreen()); //Uncomment to run the entire program

            User p = new User();
            Application.Run(new Game(p)); // Uncomment to just run the game

            //Application.Run(new WinScreen()); // Uncomment to just run the win screen
        }
    }
}
