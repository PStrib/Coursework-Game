using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_Game
{
    class Scores
    {
        private SortedSet<Score> ss;

        public Scores()
        {
            ss = new SortedSet<Score>();
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
