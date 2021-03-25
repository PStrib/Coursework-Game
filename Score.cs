using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_Game
{
    public class Score : IComparable<Score>
    {
        public int ticks { get; }
        public User user { get; }

        public Score(int ticks, User user)
        {
            this.ticks = ticks;
            this.user = user;
        }

        public int CompareTo(Score other)
        {
            return this.ticks.CompareTo(other.ticks);
        }

        public override string ToString()
        {
            return $"{{{user}, {ticks}}}";
        }
    }
}
