using System;
using System.Collections.Generic;
using System.Text;

namespace Games
{
    class Player
    {
        private string playername;

        public string PlayerName
        {
            get { return playername; }
            set { playername = value; }
        }

        private int points;

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Player (string name, int points)
        {
            playername = name;
            this.points = points;
        }

        protected Player()
        {

        }
    }
}
