using System;
using System.Collections.Generic;
using System.Text;

namespace ShutTheBox
{
    class GameBoard
    {
        private bool felt1;
 

        public bool Felt1
        {
            get { return felt1; }
            set { felt1 = value; }
        }

        private bool felt2;

        public bool Felt2
        {
            get { return felt2; }
            set { felt2 = value; }
        }

        private bool felt3;

        public bool Felt3
        {
            get { return felt3; }
            set { felt3 = value; }
        }

        private bool felt4;

        public bool Felt4
        {
            get { return felt4; }
            set { felt4 = value; }
        }

        private bool felt5;

        public bool Felt5
        {
            get { return felt5; }
            set { felt5 = value; }
        }

        private bool felt6;

        public bool Felt6
        {
            get { return felt6; }
            set { felt6 = value; }
        }

        private bool felt7;

        public bool Felt7
        {
            get { return felt7; }
            set { felt7 = value; }
        }

        private bool felt8;

        public bool Felt8
        {
            get { return felt8; }
            set { felt8 = value; }
        }

        private bool felt9;

        public bool Felt9
        {
            get { return felt9; }
            set { felt9 = value; }
        }

        public GameBoard()
        {
            felt1 = false;
            felt2 = false;
            felt3 = false;
            felt4 = false;
            felt5 = false;
            felt6 = false;
            felt7 = false;
            felt8 = false;
            felt9 = false;
        }

        public bool isOneDiceAllowed()
        {
            if (felt9 == true && felt8 == true && felt7 == true)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool isFinished()
        {
            if (felt1 == true && felt2 == true && felt3 == true && felt4 == true && felt5 == true && felt6 == true && felt7 == true && felt8 == true)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
