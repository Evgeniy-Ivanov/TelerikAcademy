using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class ScoreBoard
    {
        public ScoreBoard(string name, int points)
        {
            this.PlayerName = name;
            this.PlayerPoints = points;
        }

        public string PlayerName { get; set; }

        public int PlayerPoints { get; set; }
    }
}
