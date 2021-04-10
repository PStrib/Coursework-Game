using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_Game
{
    public class Score : IComparable<Score>
    {
        public int seconds { get; }
        public User user { get; }

        public Score(int seconds, User user)
        {
            this.seconds = seconds;
            this.user = user;
        }

        public int CompareTo(Score that)
        {
            return this.seconds.CompareTo(that.seconds);
        }

        public override string ToString()
        {
            return $"{{{user}, {seconds}}}";
        }
    }
}
