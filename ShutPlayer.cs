using System;
using System.Collections.Generic;
using System.Text;

namespace ShutTheBox
{
    class ShutPlayer : Games.Player
    {
        public GameBoard board;
        private bool myturn;

        private int currentminuspoints;

        public int CurrentMinusPoints
        {
            get { return currentminuspoints; }
            set { currentminuspoints = value; }
        }


        public bool MyTurn
        {
            get { return myturn; }
            set { myturn = value; }
        }

        public ShutPlayer(string name, int points) : base(name, points)
        {
            board = new GameBoard();
            currentminuspoints = -45;
            MyTurn = true;
        }

        public void endTurn()
        {
            MyTurn = false;
            Points = Points + CurrentMinusPoints;
        }

        public void playField(int field)
        {
            currentminuspoints = currentminuspoints + field;
            if (field == 1)
                board.Felt1 = true;
            if (field == 2)
                board.Felt2 = true;
            if (field == 3)
                board.Felt3 = true;
            if (field == 4)
                board.Felt4 = true;
            if (field == 5)
                board.Felt5 = true;
            if (field == 6)
                board.Felt6 = true;
            if (field == 7)
                board.Felt7 = true;
            if (field == 8)
                board.Felt8 = true;
            if (field == 9)
                board.Felt9 = true;
        }

        public void undoField(int field)
        {
            currentminuspoints = currentminuspoints - field;
            if (field == 1)
                board.Felt1 = false;
            if (field == 2)
                board.Felt2 = false;
            if (field == 3)
                board.Felt3 = false;
            if (field == 4)
                board.Felt4 = false;
            if (field == 5)
                board.Felt5 = false;
            if (field == 6)
                board.Felt6 = false;
            if (field == 7)
                board.Felt7 = false;
            if (field == 8)
                board.Felt8 = false;
            if (field == 9)
                board.Felt9 = false;
        }

        public bool checkDice2(int value)
        {
            if (value == 1 && !board.Felt1)
            {
                playField(1);
                return true;
            } else if (value == 2 && !board.Felt2)
            {
                playField(2);
                return true;
            } else if (value == 3 && !board.Felt3)
            {
                playField(3);
                return true;
            } else if (value == 4 && !board.Felt4)
            {
                playField(4);
                return true;
            } else if (value == 5 && !board.Felt5)
            {
                playField(5);
                return true;
            } else if (value == 6 && !board.Felt6)
            {
                playField(6);
                return true;
            } else
            {
                return false;
            }
        }

        public bool isFinished()
        {
            if (board.Felt1 && board.Felt2 && board.Felt3 && board.Felt4 && board.Felt5 && board.Felt6 && board.Felt7 && board.Felt8 && board.Felt9)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
