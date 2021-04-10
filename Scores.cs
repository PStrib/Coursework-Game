using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Coursework_Game
{
    class Scores
    {
        private static SortedSet<Score> ss;
        private const string FILENAME = "Highscores.txt";

        public Scores()
        {
            if (ss == null)
            {
                ss = new SortedSet<Score>();
                readHighscoresFromFile();
            }
        }
        // The Highscores.txt file is formatted "user ticks"
        private void readHighscoresFromFile()
        {
            Users users = new Users();
            if (!File.Exists(FILENAME)) { return; }
            string[] lines = File.ReadAllLines(FILENAME);
            foreach (string line in lines)
            {
                string[] fields = line.Split(' '); // Splits by a space
                string username = fields[0];
                User user = users.GetUser(username);
                int secondsTaken = Convert.ToInt32(fields[1]);
                Score score = new Score(secondsTaken, user);
                ss.Add(score);
            }
        }
        public List<Score> ListAll()
        {
            var l = new List<Score> { };
            foreach (Score s in ss)
            {
                l.Add(s);
            }
            return l;
        }

        private void addScoresToFile()
        {
            using (StreamWriter file = new StreamWriter(FILENAME))
            {
                foreach (Score score in ss)
                {
                    string line = $"{score.user.Username} {score.seconds}";
                    file.WriteLine(line);
                }
            }
        }
        public void Add(Score score)
        {
            ss.Add(score);
            addScoresToFile();
        }
    }
}
