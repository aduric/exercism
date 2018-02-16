using System.Collections.Generic;
using System.Linq;
using Poker.Deck;

namespace Poker.Hand
{
    internal class Triple : IHand {

        public Triple( IEnumerable<Card> triple, IEnumerable<Card> rest ) {
            PrimaryPartialHand = this;
            SecondaryPartialHand = new None( rest );
            Cards = triple.Concat( rest );
        }
        public IEnumerable<Card> Cards { get; }
        public IHand PrimaryPartialHand { get; }
        public IHand SecondaryPartialHand { get; }
        public Rank Rank => Rank.Triple;

    }
}
