using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_hands_checker_CSharp
{
    class Card
    {
        public string Value { get; set; }
        public string Suite { get; set; }

        public Card(string value, string suite)
        {
            Value = value;
            Suite = suite;
        }
    }
}
