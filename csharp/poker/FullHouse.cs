using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class FullHouse : IHand
    {
        public FullHouse( IList<Card> cards ) {
            Cards = cards;
        }

        public IList<Card> Cards { get; }
        public IHand PrimaryPartialHand => new Triple(Cards);
        public IHand SecondaryPartialHand => new Pair(Cards);
        public Rank Rank => Rank.FullHouse;

    }
}
