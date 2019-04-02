using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_hands_checker_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck MyCards = new Deck();

            List<Player> Players = new List<Player>();

            List<string> Values = new List<string> { "King", "Queen", "Jack", "10", "9", "8", "7", "6", "5", "4", "3", "2", "Ace" };

            List<string> Suites = new List<string> { "Hearts", "Clubs", "Diamonds", "Spades" };

            Console.WriteLine("Welcome To Poker Hands Checker");
            Console.WriteLine();


            string number = "r";
            int num;
            Console.WriteLine();

            while (!int.TryParse(number, out num))
            {
                Console.WriteLine("Please enter the number of players playing this game.");
                Console.WriteLine();
                Console.WriteLine("Enter a Number");
                Console.WriteLine();
                number = Console.ReadLine();
                Console.WriteLine();
            }

            Console.WriteLine("The number of players playing are " + num);
            Console.WriteLine();

            for (int i = 1; i < num + 1; i++)
            {
                Player player = new Player(i);

                Players.Add(player);

                Console.WriteLine("Player " + i);
                Console.WriteLine();

                Console.WriteLine("Please Enter the Value and Suite of Five Cards.");
                Console.WriteLine();
                Console.WriteLine("Please Note the Value entered must be one out of these:-");
                Console.WriteLine("King," + " Queen," + " Jack," + " 10," + " 9," + " 8," + " 7," + " 6," + " 5," + " 4," + " 3," + " 2," + " Ace");
                Console.WriteLine();
                Console.WriteLine("Please Note the Suite entered must be one out of these:-");
                Console.WriteLine("Hearts," + " Clubs," + " Diamonds," + " Spades");
                Console.WriteLine();

                for (int j = 1; j < 6; j++)
                {
                    string value = "";
                    while (!Values.Contains(value))
                    {
                        Console.WriteLine("Enter the Value for " + j + " Card.");
                        value = Console.ReadLine();
                        Console.WriteLine();
                    }

                    Console.WriteLine("The Value entered is " + value);


                    string suite = "";
                    while (!Suites.Contains(suite))
                    {
                        Console.WriteLine("Enter the Suite for " + j + " Card.");
                        suite = Console.ReadLine();
                    }

                    Console.WriteLine("The Suite entered is " + suite);

                    player.Cards.Add(new Card(value, suite));
                }

                Console.WriteLine("The Cards for the Player are:-");

                foreach (var card in player.Cards)
                {
                    Console.WriteLine(card.Value + " of " + card.Suite);
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Let's see Who is the winner?");

            Console.WriteLine(CheckHands(Players));

            Console.ReadLine();
        }

        private static string CheckHands(List<Player> players)
        {
            foreach (Player player in players)
            {
                if (IsStraight(player) && IsFlush(player))
                {
                    return player.Id + "Won with Straight Flush";
                }
            }

            foreach (Player player in players)
            {

                if (IsFourOfAKind(player))
                {
                    return player.Id + "Won with Four of a Kind";
                }
            }

            foreach (Player player in players)
            {

                if (IsOnePair(player) && IsThreeOfAKind(player))
                {
                    return player.Id + "Won with Full House";
                }
            }

            foreach (Player player in players)
            {
                if (IsFlush(player))
                {
                    return player.Id + "Won with Flush";
                }
            }

            foreach (Player player in players)
            {
                if (IsStraight(player))
                {
                    return player.Id + "Won with Straight";
                }
            }

            foreach (Player player in players)
            {
                if (IsThreeOfAKind(player))
                {
                    return player.Id + "Won with Three of a Kind";
                }
            }

            foreach (Player player in players)
            {
                if (IsTwoPair(player))
                {
                    return player.Id + "Won with Two Pair";
                }
            }

            foreach (Player player in players)
            {
                if (IsOnePair(player))
                {
                    return player.Id + "Won with One Pair";
                }
            }

            //foreach (Player player in players)
            //{
            //    if (IsHighCard(player))
            //    {
            //        return player.Id + "Won with One Pair";
            //    }
            //}

            return "";
        }

        private static bool IsFourOfAKind(Player player)
        {
            return player.Cards.GroupBy(p => p.Value).Any(p => p.ToList().Count == 4) ? true : false;
        }

        private static bool IsFlush(Player player)
        {
            return player.Cards.All(p => p.Suite == player.Cards[0].Suite) ? true : false;
        }

        private static bool IsStraight(Player player)
        {
            List<Card> cards = player.Cards.OrderBy(p => p.Value).ToList();

            return (player.Cards.Where(p => p.Value == "Ace").ToList().Count == 1 && player.Cards.Where(p => p.Value == "King").ToList().Count == 1 && player.Cards.Where(p => p.Value == "Queen").ToList().Count == 1 && player.Cards.Where(p => p.Value == "Jack").ToList().Count == 1 && player.Cards.Where(p => p.Value == "10").ToList().Count == 1) || (player.Cards.Where(p => p.Value == "Ace").ToList().Count == 1 && player.Cards.Where(p => p.Value == "2").ToList().Count == 1 && player.Cards.Where(p => p.Value == "3").ToList().Count == 1 && player.Cards.Where(p => p.Value == "4").ToList().Count == 1 && player.Cards.Where(p => p.Value == "5").ToList().Count == 1)
                ? true
                : false;
        }

        private static bool IsThreeOfAKind(Player player)
        {
            return player.Cards.GroupBy(p => p.Value).Any(p => p.ToList().Count == 3) ? true : false;
        }

        private static bool IsTwoPair(Player player)
        {
            return player.Cards.GroupBy(p => p.Value).OrderBy(p => p.Count()).Take(2).All(p => p.ToList().Count == 2) ? true : false;
        }

        private static bool IsOnePair(Player player)
        {
            return player.Cards.GroupBy(p => p.Value).OrderBy(p => p.Count()).Take(1).All(p => p.ToList().Count == 2) ? true : false;
        }

        //private static bool IsHighCard(Player player)
        //{
        //    return player.Cards.OrderBy(p => p.Value) ? true : false;
        //}
    }
}
