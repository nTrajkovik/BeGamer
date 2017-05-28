using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGamer
{
    [Serializable]
    public class LeaderBoard
    {
        public List<Score> scores { get; set; }
        public List<Score> GetOrderedLeaderBoard()
        {
            scores.Sort((a, b) => a.Points - b.Points);
            return scores;
        }

    }
    [Serializable]
    public class Score
    {
        public string PlayerName { get; set; }
        public int Points { get; set; }
        public Score(string PlayerName, int Points)
        {
            this.Points = Points;
            this.PlayerName = PlayerName;
        }
    }
}
