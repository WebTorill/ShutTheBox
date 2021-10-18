using System;
using Games;

namespace ShutTheBox
{
    class ShutTheBox
    {

        static void Main(string[] args)
        {
            PairOfDice dices = new PairOfDice();
            Dice dice = new Dice();
            Console.WriteLine("Hvor mange spillere?");
            int numPlayers = Int32.Parse(Console.ReadLine());
            ShutPlayer[] players = new ShutPlayer[numPlayers];
            for (int i = 0; i < numPlayers; i++)
            {
                ShutPlayer player = new ShutPlayer("player" + (i + 1), 0);
                players[i] = player;
            }
            bool gameInPlay = true;
            while (gameInPlay)
            {
                foreach (ShutPlayer player in players)
                {
                    while (player.MyTurn == true)
                    {
                        Console.WriteLine("Det er " + player.PlayerName + "'s tur, som lige nu står til " + player.CurrentMinusPoints + " minuspoints denne runde.");
                        if (player.board.isOneDiceAllowed())
                        {
                            dice.Throw();
                            checkOneDice(dice, player);
                            System.Threading.Thread.Sleep(2000);
                        } else {
                            dices.ThrowDices();
                            checkTwoDices(dices, player);
                        }
                        
                    }

                }
                gameInPlay = prepareNewRound(players);
            }
        }
        public static void checkOneDice(Dice dice, ShutPlayer player)
        {
            Console.WriteLine("Du slog " + dice.show() + ".");
            if (dice.show() == 1)
                checkNumber(dice.show(), dice, player, player.board.Felt1);
            else if (dice.show() == 2)
                checkNumber(dice.show(), dice, player, player.board.Felt2);
            else if (dice.show() == 3)
                checkNumber(dice.show(), dice, player, player.board.Felt3);
            else if (dice.show() == 4)
                checkNumber(dice.show(), dice, player, player.board.Felt4);
            else if (dice.show() == 5)
                checkNumber(dice.show(), dice, player, player.board.Felt5);
            else if (dice.show() == 6)
                checkNumber(dice.show(), dice, player, player.board.Felt6);
        }
        public static void checkTwoDices(PairOfDice dices, ShutPlayer player)
        {
            if (dices.addedValue() > 9)
            {
                Console.WriteLine(player.PlayerName + " slog højere end 9 og mistede dermed sin tur.");
                player.endTurn();
            }
            else
            {
                Console.WriteLine("Du slog " + dices.Dice1.show() + " og " + dices.Dice2.show() + ". Skriv et tal mellem 1 og 9 efter hvor du vil placere en terning. Hvis du skriver et tal hvor feltet allerede er optaget, mister du din tur.");
                int tal = Int32.Parse(Console.ReadLine());
                if (tal == 9)
                {
                    if (dices.addedValue() == 9 && !player.board.Felt9)
                    {
                        player.playField(9);
                    }
                    else
                    {
                        Console.WriteLine(player.PlayerName + " valgte felt 9, men feltet er allerede optaget og turen går videre.");
                        player.endTurn();
                    }
                }
                else if (tal == 8)
                {
                    if (dices.addedValue() == 8 && !player.board.Felt8)
                    {
                        player.playField(8);
                    }
                    else
                    {
                        Console.WriteLine(player.PlayerName + " valgte felt 8, men feltet er allerede optaget og turen går videre.");
                        player.endTurn();
                    }
                }
                else if (tal == 7)
                {
                    if (dices.addedValue() == 7 && !player.board.Felt7)
                    {
                        player.playField(7);
                    }
                    else
                    {
                        Console.WriteLine(player.PlayerName + " valgte felt 7, men feltet er allerede optaget og turen går videre.");
                        player.endTurn();
                    }
                }
                else if (tal == 6)
                {
                    checkNumber(6, dices, player, player.board.Felt6);
                }
                else if (tal == 5)
                {
                    checkNumber(5, dices, player, player.board.Felt5);
                }
                else if (tal == 4)
                {
                    checkNumber(4, dices, player, player.board.Felt4);
                }
                else if (tal == 3)
                {
                    checkNumber(3, dices, player, player.board.Felt3);
                }
                else if (tal == 2)
                {
                    checkNumber(2, dices, player, player.board.Felt2);
                }
                else if (tal == 1)
                {
                    checkNumber(1, dices, player, player.board.Felt1);
                }
            }
        }
        public static bool prepareNewRound(ShutPlayer[] players)
        {
            bool gameInPlay = true;
            int noOfFinished = 0;
            foreach (ShutPlayer player in players)
            {
                if (player.isFinished())
                {
                    player.MyTurn = false;
                    noOfFinished++;
                    Console.WriteLine(player.PlayerName + " er færdig og står med " + player.Points + " points.");
                }
                else
                {
                    player.MyTurn = true;
                }
            }
            if (noOfFinished == players.Length)
            {
                gameInPlay = false;
                Console.WriteLine("Spillet er slut.");
            }
            return gameInPlay;
        }

        public static void checkNumber(int value, Dice dice, ShutPlayer player, bool felt)
        {
            if (felt)
            {
                Console.WriteLine("Feltet " + value + " er desværre optaget. Turen går videre.");
                player.endTurn();
            } else
            {
                player.playField(value);
            }
        }

        public static void checkNumber(int value, PairOfDice dices, ShutPlayer player, bool felt)
        {
            if (dices.addedValue() == value && !felt)
            {
                player.playField(value);
            }
            else if (dices.Dice1.show() == value && !felt)
            {
                player.playField(value);
                if (!player.checkDice2(dices.Dice2.show()))
                {
                    player.undoField(value);
                    Console.WriteLine(player.PlayerName + " valgte felt " + value + ", men feltet til den anden terning er allerede optaget og turen går videre.");
                    player.endTurn();
                } 
            }
            else if (dices.Dice2.show() == value && !felt)
            {
                player.playField(value);
                if (!player.checkDice2(dices.Dice1.show()))
                {
                    player.undoField(value);
                    Console.WriteLine(player.PlayerName + " valgte felt " + value + ", men feltet til den anden terning er allerede optaget og turen går videre.");
                    player.endTurn();
                } 
            } else
            {
                Console.WriteLine(player.PlayerName + " valgte felt " + value + ", men feltet er allerede optaget og turen går videre.");
                player.endTurn();
            }
        }
    }
}
