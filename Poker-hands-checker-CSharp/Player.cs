using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_hands_checker_CSharp
{
    class Player
    {
        public int Id { get; set; }
        public List<Card> Cards = new List<Card>();
        public string HighCard { get; set; }

        public Player(int id)
        {
            Id = id;
        }
    }
}
