using System;
using System.Collections.Generic;
using System.Text;

namespace Games
{
    class PairOfDice
    {
        private Random randomPick = new Random();
        
        /**
         * Properties
         */
        
        private Dice dice1;

        public Dice Dice1
        {
            get { return dice1; }
        }

        private Dice dice2;

        public Dice Dice2
        {
            get { return dice2; }
        }

        /**
         * Constructor
         */
        public PairOfDice()
        {
            dice1 = new Dice();
            dice2 = new Dice();
        }

        /**
         * Methods
         */

        //ThrowDices is a method with no parameters that throws both dices in a random way
        public void ThrowDices()
        {
            InitializeRandomRoll(10);
            dice1.Throw(randomPick);
            InitializeRandomRoll(900000000);
            dice2.Throw(randomPick);
        }

        //InitializeRandomRoll takes an int seed as parameter, and helps randomizing the rolls
        public void InitializeRandomRoll(int nSeed)
        {
            DateTime aTime = new DateTime(1000);
            aTime = DateTime.Now;
            nSeed += (int)(aTime.Millisecond);
            randomPick = new Random(nSeed);
        }

        //addedValue takes no parameters and returns the added value of both the dices 
        public int addedValue()
        {
            int samlet = dice1.show() + dice2.show();
            return samlet;
        }

    }
}
