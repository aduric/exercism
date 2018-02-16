using System.Collections.Generic;
using System.Linq;
using Poker.Deck;

namespace Poker.Hand
{
    internal class Pair : IHand
    {

        public Pair( IEnumerable<Card> pair, IEnumerable<Card> rest ) {
            PrimaryPartialHand = this;
            SecondaryPartialHand = new None( rest );
            Cards = pair.Concat( rest );
        }
        public IEnumerable<Card> Cards { get; }
        public IHand PrimaryPartialHand { get; }
        public IHand SecondaryPartialHand { get; }
        public Rank Rank => Rank.Pair;

    }
}
