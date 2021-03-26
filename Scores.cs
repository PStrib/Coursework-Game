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
        public void readHighscoresFromFile()
        {
            var lines = File.ReadAllLines(FILENAME);

            for (int i = 0; i < lines.Length; i++)
            {
                var fields = lines[i].Split(' ');
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

        public void Add(Score score)
        {
            ss.Add(score);
        }
    }
}
