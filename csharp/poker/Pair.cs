using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Pair : IHand
    {

        public Pair( IList<Card> cards ) {
            Cards = cards;
        }
        public IList<Card> Cards { get; }
        public IHand PrimaryPartialHand => new Pair( Cards );
        public IHand SecondaryPartialHand => new None( Cards );
        public Rank Rank => Rank.Pair;

    }
}
